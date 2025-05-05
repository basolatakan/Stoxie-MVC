using Microsoft.AspNetCore.Mvc;
using Stoxie.Models.ModelMetadataTypes;
using System.ComponentModel.DataAnnotations;

namespace Stoxie.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
