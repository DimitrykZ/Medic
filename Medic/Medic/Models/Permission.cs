using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medic.Models
{
    public class Permission //Класс прав доступа
    {   [Key]
        public int PermissionId { get; set; }
        public int Code { get; set; }
        public string PerName { get; set; }
    }
}