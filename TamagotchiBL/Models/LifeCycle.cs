using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TAMAGOTCHI.Models
{
    [Table("LifeCycle")]
    public partial class LifeCycle
    {
        public LifeCycle()
        {
            Histories = new HashSet<History>();
            Pets = new HashSet<Pet>();
        }

        [Key]
        [Column("LifeCycleID")]
        public int LifeCycleId { get; set; }
        [Required]
        [StringLength(15)]
        public string LifeCycleName { get; set; }

        [InverseProperty(nameof(History.LifeCycle))]
        public virtual ICollection<History> Histories { get; set; }
        [InverseProperty(nameof(Pet.LifeCycle))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
