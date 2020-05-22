using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InstaApi.Common.ViewModels.Auth
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نمیباشد")]
        [DisplayName("ایمیل")]       
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("گذرواژه")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public string Password { get; set; }
    }
}