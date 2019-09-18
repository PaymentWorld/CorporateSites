using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security;
using System.ComponentModel.DataAnnotations;

namespace Codebase.Website.Models
{
    public class AccountSetupViewModel
    {
        [Required(ErrorMessage = "*")]       
        public string Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "*")]       
        public string BusinessName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.PhoneNumber)]        
        public string PhoneNumber
        {
            get;
            set;
        }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]         
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$", ErrorMessage = "Invalid Email")]
        public string EmailAddress
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}