using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Codebase.Website.Models
{
    public class AgentLoginViewModel
    {
                
        [Required(ErrorMessage = "*")]        
        public string txtUserID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "*")]        
        [DataType(DataType.Password)]        
        public string txtPwd
        {
            get;
            set;
        }
    }
}