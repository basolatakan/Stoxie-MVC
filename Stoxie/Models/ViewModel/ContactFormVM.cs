using System.ComponentModel.DataAnnotations;

namespace Stoxie.Models.ViewModel
{
    public class ContactFormVM
    {
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-posta boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mesaj boş bırakılamaz.")]
        [StringLength(1000)]
        public string Message { get; set; }
    }
}
