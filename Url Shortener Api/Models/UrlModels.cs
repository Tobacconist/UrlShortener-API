using System.ComponentModel.DataAnnotations;
namespace Url_Shortener_Api.Models
{
    public class ShortenRequestDto
    {
        [Required(ErrorMessage = "URL alanı zorunludur.")]
        [Url(ErrorMessage = "Geçerli bir web adresi giriniz.")]
        public string OriginalUrl { get; set; }
    }

    public class ShortenResponseDto
    {
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }
        public string Code { get; set; }
    }
}
