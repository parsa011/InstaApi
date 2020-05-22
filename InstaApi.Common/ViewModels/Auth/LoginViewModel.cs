using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InstaApi.Common.ViewModels.Auth
{
    public class LoginViewModel
    {
        [DisplayName("نام کاربری")]       
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("گذرواژه")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public string Password { get; set; }
    }
}