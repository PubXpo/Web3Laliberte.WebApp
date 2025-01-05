using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web3Laliberte.OperationsAPI.Service.Orders;
using Web3Laliberte.OperationsAPI.ViewModel.Orders;

namespace Web3Laliberte.OperationsAPI.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Returns all transactions.
        /// </summary>
        [HttpGet]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _service.GetAllAsync();
            return Ok(transactions);
        }

        /// <summary>
        ///     Returns a transaction by ID.
        /// </summary>
        /// <param name="id">The ID of the transaction.</param>
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

        // <summary>
        ///     Creates a new transaction.
        /// </summary>
        /// <param name="transaction">The transaction view model.</param>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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

        /// <summary>
        ///     Updates a transaction by ID.
        /// </summary>
        /// <param name="id">The ID of the transaction.</param>
        /// <param name="transaction">The transaction view model.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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
        
        /// <summary>
        ///     Updates the inventory amount of a gift by gift ID.
        /// </summary>
        /// <param name="giftId">The ID of the gift.</param>
        /// <param name="inventoryAmount">The new inventory amount.</param>
        [HttpPut("gift/{giftId}/inventory")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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
        
        /// <summary>
        ///     Fulfills a transaction by ID.
        /// </summary>
        /// <param name="transactionId">The ID of the transaction.</param>
        [HttpPut("{transactionId}/fulfill")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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

        /// <summary>
        ///     Deletes a transaction by ID.
        /// </summary>
        /// <param name="id">The ID of the transaction.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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