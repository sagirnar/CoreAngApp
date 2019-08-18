using System.ComponentModel.DataAnnotations;

namespace DattingApp.API.DTO
{
    public class UserForRegisterDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}