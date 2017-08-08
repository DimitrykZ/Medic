using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Medic.Models
{
    public class Territory //Класс областей (территориальных единиц)
    {
        [Key]
        public int TerritoryId { get; set; }
        public string Name { get; set; }
        public int CodeTerritory { get; set; }
    }
}