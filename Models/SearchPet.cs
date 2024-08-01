using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetSearch.Models
{
    public partial class SearchPet
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        public string AnimalName { get; set; } = null!;
        public string Breed { get; set; } = null!;
        public string LastSeenAddress { get; set; } = null!;
        public string Color { get; set; } = null!;
        [DataType(DataType.PhoneNumber)]
        public int Cellphone { get; set; }
        public string Message { get; set; } = null!;
        public string ImagePet { get; set; } = null!;
        public DateTime? RegisteraDate { get; set; }
        public byte? Status { get; set; }
        public DateTime? LastUpdate { get; set; }
        public short UserId { get; set; }
    }
}
