using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetSearch.Models
{
    public partial class FoundPet
    {
        public int Id { get; set; }
        public string LastSeenAddress { get; set; } = null!;
        [DataType(DataType.PhoneNumber)]
        public int Cellphone { get; set; }
        public string ImagePet { get; set; } = null!;

        public DateTime? RegisterDate { get; set; }
        public byte? Status { get; set; }
        public DateTime? LastUpdate { get; set; } 
        public short UserId { get; set; }
    }
}
