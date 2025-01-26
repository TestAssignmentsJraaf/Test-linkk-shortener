using BLL.DTO;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortenerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LinkController(ILinkService _service) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var data = await _service.GetAllAsync();
            if (data != null)
            {
                return Ok(data);
            }
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        return NoContent();
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var data = await _service.GetAsync(id);
            if (data != null)
            {
                return Ok(data);
            }
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception)
        {
            throw;
        }

        return NoContent();
    }
    [HttpPost("add")]
    public async Task<IActionResult> Post(CreateLinkDTO model)
    {
        var data = await _service.AddAsync(model);
        return Ok(data);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
    [HttpPut("Update")]
    public async Task<IActionResult> Update(int id, CreateLinkDTO DTO)
    {
        var data = await _service.UpdateByIdAsync(id, DTO);
        return Ok(data);
    }
}
