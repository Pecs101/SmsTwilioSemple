using System.ComponentModel.DataAnnotations;

namespace SmsTwilioSemple.Helper.Dtos
{
    public class MessageDto
    {
        [MaxLength(500)]
        [Required]
        public string Message { get; set; }

        [Required]
        public string To { get; set; }
    }
}
