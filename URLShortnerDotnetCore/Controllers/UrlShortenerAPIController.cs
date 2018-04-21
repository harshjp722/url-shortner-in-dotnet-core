using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URLShortnerDotnetCore.Models;
using URLShortnerDotnetCore.Repository;

namespace URLShortnerDotnetCore.Controllers
{
    [Route("api/urlshortener")]
    public class UrlShortenerAPIController : Controller
    {
        public const string _apiKey = "tRdr9DfkHMHScmF2CGqVkvGYjNUFehCZ8Ts6"; //"dFJkcjlEZmtITUhTY21GMkNHcVZrdkdZak5VRmVoQ1o4VHM2" - base64 encoded token string
        

        [HttpPost]
        public async Task<IActionResult> CreateShortUrl([FromBody]ShortUrllog urlDetails)
        {
            try
            {
                string authHeaderString = Request.Headers["Authorization"];
                string encodedToken = authHeaderString.Substring("Bearer ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                string apiKey = encoding.GetString(Convert.FromBase64String(encodedToken));
                if (!string.IsNullOrWhiteSpace(apiKey) && apiKey == _apiKey)
                {
                    Urlservices _urlservices = new Urlservices();
                    string shortURL = _urlservices.GenerateShortUrlLog(urlDetails.LongUrl);
                    return Ok(shortURL);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
            return BadRequest("Invalid request");
        }

        [Route("~/{code}")]
        [HttpGet]
        public async Task<IActionResult> Index(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return BadRequest("Inaccessible Url");

            Urlservices _urlservices = new Urlservices();
            var Urlcode = _urlservices.Getcodebyurl(code);
            if (Urlcode != null)
                return Redirect(Urlcode.LongUrl);

            return BadRequest("Inaccessible Url");
        }
    }
}