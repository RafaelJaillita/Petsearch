using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetSearch.Models
{
    public partial class User
    {
        public short Id { get; set; }
        public string FullName { get; set; } = null!;
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public DateTime RegisterDate { get; set; }
        public byte Status { get; set; }
        public string? Rol { get; set; }
    }
}
