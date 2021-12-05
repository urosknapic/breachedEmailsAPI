using BreachedEmailsAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BreachedEmailsAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class BreachedEmailController : ControllerBase
  {
    private IEmailStorageService _storageService;
    public BreachedEmailController(IEmailStorageService storageService)
    {
      _storageService = storageService;
    }

    [HttpPost("{email}")]
    public ActionResult AddNewBreachedEmail(string email)
    {
      var result = _storageService.AddEmail(email);

      if (result)
      {
        return Created(string.Format("GetBreachedEmail/{0}", email), new { email });
      }

      return Conflict("Email already exist. Can't add it again");
    }

    [HttpGet("{email}", Name = "GetBreachedEmailRoute")]
    public ActionResult GetBreachedEmail(string email)
    {
      var result = _storageService.GetEmail(email);

      if (string.IsNullOrEmpty(result))
      {
        return NotFound();
      }

      return Ok("Email found");
    }
    /*
     * DELETE
      HTTP DELETE https://my.site/brechedemails/user@geneplanet.com
      - Expected responses: Ok
      - 404 if email not found
     */
  }
}
