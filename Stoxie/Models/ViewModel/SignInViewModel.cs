using Microsoft.AspNetCore.Mvc;
using Stoxie.Models.ModelMetadataTypes;

namespace Stoxie.Models.ViewModel
{
    [ModelMetadataType(typeof(SignInMetadata))]
    public class SignInViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
