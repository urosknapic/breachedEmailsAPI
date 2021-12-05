using BreachedEmailsAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BreachedEmailsAPI.Controllers
{
  [ApiController]
  [Route("api/breachedEmails")]
  public class BreachedEmailController : ControllerBase
  {
    private IEmailStorageService _storageService;
    public BreachedEmailController(IEmailStorageService storageService)
    {
      _storageService = storageService;
    }

    [HttpPost("{email}")]
    public IActionResult AddNewBreachedEmail(string email)
    {
      try
      {
        if (_storageService.AddEmail(email))
        {
          return CreatedAtRoute("GetBreachedEmail", new { email }, email);
        }

        return Conflict("Email already exist. Can't add it again");
      } 
      catch (Exception ex)
      {
        return BadRequest("Email in wrong format");
      }
    }

    [HttpGet("{email}", Name = "GetBreachedEmail")]
    public IActionResult GetBreachedEmail(string email)
    {
      if (string.IsNullOrEmpty(_storageService.GetEmail(email)))
      {
        return NotFound();
      }

      return Ok("Email found");
    }

    [HttpDelete("{email}")]
    public IActionResult DeleteBreachedEmail(string email)
    {
      if (_storageService.DeleteEmail(email))
      {
        return Ok();
      }

      return NotFound("Email not found");
    }
  }
}
