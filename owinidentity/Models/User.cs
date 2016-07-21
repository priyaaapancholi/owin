using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace owinidentity.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { set; get; }
        [EmailAddress]
        public string Email{ get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}