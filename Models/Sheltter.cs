using System;
using System.Collections.Generic;

namespace PetSearch.Models
{
    public partial class Sheltter
    {
        public int Id { get; set; }
        public string NameSheltter { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Cellphone { get; set; }
        public DateTime RegisterDate { get; set; }
        public byte Status { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
