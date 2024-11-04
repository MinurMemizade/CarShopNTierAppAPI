using NTierApp.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Core.Entities
{
    public class Car : BaseEntity
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Year { get; set; }
        public bool IsNew { get; set; }
        public string Description { get; set; }
        public double Engine { get; set; }
        public double HorsePower { get; set; }
        public double Mileage { get; set; }
    }
}
