using System.ComponentModel.DataAnnotations;

namespace Stoxie.Models.ModelMetadataTypes
{
    public class SignInMetadata
    {
        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        public string Password { get; set; }
    }
}
