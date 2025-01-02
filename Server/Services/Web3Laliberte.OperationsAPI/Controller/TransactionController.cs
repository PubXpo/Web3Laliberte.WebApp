using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web3Laliberte.OperationsAPI.Service.Orders;
using Web3Laliberte.OperationsAPI.ViewModel.Orders;

namespace Web3Laliberte.OperationsAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _service.GetAllAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var transaction = await _service.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionViewModel transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            transaction.TransactionId = Guid.NewGuid();
            transaction.Status = "Pending";
            transaction.Gifts = await _service.GetGiftsByBandIdAsync(transaction.BandId);
            await _service.AddAsync(transaction);
            return CreatedAtAction(nameof(GetById), new { id = transaction.TransactionId }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TransactionViewModel transaction)
        {
            if (id != transaction.TransactionId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            transaction.Gifts = await _service.GetGiftsByBandIdAsync(transaction.BandId);
            await _service.UpdateAsync(transaction);
            return NoContent();
        }
        
    [HttpPut("gift/{giftId}/inventory")]
    public async Task<IActionResult> UpdateGiftInventoryAmount(Guid giftId, [FromBody] int inventoryAmount)
    {
        if (inventoryAmount < 0)
        {
            return BadRequest("Inventory amount cannot be negative.");
        }

        var result = await _service.UpdateGiftInventoryAmountAsync(giftId, inventoryAmount);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
    
    [HttpPut("{transactionId}/fulfill")]
    public async Task<IActionResult> FulfillTransaction(Guid transactionId)
    {
        var transaction = await _service.GetByIdAsync(transactionId);
        if (transaction == null)
        {
            return NotFound();
        }

        foreach (var gift in transaction.Gifts)
        {
            if (gift.InventoryAmount > 0)
            {
                var result = await _service.UpdateGiftInventoryAmountAsync(gift.GiftId, gift.InventoryAmount - 1);
                if (!result)
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest($"Gift {gift.Name} has no inventory left.");
            }
        }

            transaction.Status = "Fulfilled";
            await _service.UpdateAsync(transaction);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var transaction = await _service.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}