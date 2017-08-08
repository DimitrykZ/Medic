using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medic.Models
{
    public class Organization //Класс для организаций
    {   [Key]
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public int TerritoryId { get; set; }

    }
}