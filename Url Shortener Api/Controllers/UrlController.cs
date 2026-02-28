using Microsoft.AspNetCore.Mvc;
using Url_Shortener_Api.Models;
using UrlShortener.Api.Services;

namespace UrlShortener.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlShortenerService _urlService;

       
        public UrlController(IUrlShortenerService urlService)
        {
            _urlService = urlService;
        }

        
        [HttpPost("shorten")]
        public IActionResult ShortenUrl([FromBody] ShortenRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shortCode = _urlService.ShortenUrl(request.OriginalUrl);

           
            var baseUrl = $"{Request.Scheme}://{Request.Host}/api/url/";

            var response = new ShortenResponseDto
            {
                OriginalUrl = request.OriginalUrl,
                Code = shortCode,
                ShortUrl = baseUrl + shortCode
            };

            
            return CreatedAtAction(nameof(RedirectToOriginal), new { shortCode = shortCode }, response);
        }

       
        [HttpGet("{shortCode}")]
        public IActionResult RedirectToOriginal(string shortCode)
        {
            var originalUrl = _urlService.GetOriginalUrl(shortCode);

            if (originalUrl == null)
            {
                return NotFound(new { Message = "Link bulunamadı veya süresi dolmuş." });
            }

           
            return Redirect(originalUrl);
        }
    }
}