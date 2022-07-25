using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSourcer.AuthPer
{
    public class UserRegister
    {
        [Required,MaxLength(20)]
        public string LoginProp { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password)),DataType(DataType.Password)]
        public string CheckPassword { get; set; }
    }
}
