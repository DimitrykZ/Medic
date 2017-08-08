using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medic.Models
{
    public class User  //Класс пользователя
    {   [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FIO { get; set; }
        public int OrganizationId { get; set; }
        public int PermissionId { get; set; }
    }
}