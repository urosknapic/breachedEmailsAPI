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

    /*
    * CREATE
    - HTTP POST https://my.site/brechedemails/  
    - Expected responses: Created or Conflict
    */

    /*
     * READ
     Query for breached emails:
      - HTTP GET https://my.site/ brechedemails/user@geneplanet.com
      - Expected responses: NotFound or OK
     */
    [HttpGet("{email}")]
    public ActionResult GetBreachedEmail(string email)
    {
      var result = _storageService.GetEmail(email);

      if (string.IsNullOrEmpty(result))
      {
        return NotFound();
      }

      return Ok();
    }
    /*
     * DELETE
      HTTP DELETE https://my.site/brechedemails/user@geneplanet.com
      - Expected responses: Ok
      - 404 if email not found
     */
  }
}
