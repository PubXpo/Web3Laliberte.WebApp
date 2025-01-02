using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web3Laliberte.OperationsAPI.Service.ContactLog;
using Web3Laliberte.OperationsAPI.ViewModel.ContactLog;

namespace Web3Laliberte.OperationsAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactLogController : ControllerBase
    {
        private readonly IContactLogService _service;

        public ContactLogController(IContactLogService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactLog([FromBody] ContactLogViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _service.AddAsync(viewModel);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactLogById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var contactLog = await _service.GetByIdAsync(id);
                return Ok(contactLog);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactLog([FromRoute] Guid id, [FromBody] ContactLogViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                viewModel.Id = id;
                await _service.UpdateAsync(viewModel);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactLog([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContactLogs()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var contactLogs = await _service.GetAllAsync();
                return Ok(contactLogs);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}