using Microsoft.AspNetCore.Mvc;
using Stoxie.Models.ModelMetadataTypes;
using System.ComponentModel.DataAnnotations;

namespace Stoxie.Models
{
    [ModelMetadataType(typeof(SignUpMetadata))]
    public class SignUp
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public SignUp() { }
    }
}
