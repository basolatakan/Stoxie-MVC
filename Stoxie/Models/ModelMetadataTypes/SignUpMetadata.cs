using System.ComponentModel.DataAnnotations;

namespace Stoxie.Models.ModelMetadataTypes
{
    public class SignUpMetadata
    {

        [Required(ErrorMessage = "Ad boş bırakılamaz")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad boş bırakılamaz")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [StringLength(100, ErrorMessage = "Email en fazla 100 karakter olabilir.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Telefon boş bırakılamaz")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string Phone { get; set; }

    }
}
