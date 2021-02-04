using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TAMAGOTCHI.Models
{
    [Table("LifeStatus")]
    public partial class LifeStatus
    {
        public LifeStatus()
        {
            Histories = new HashSet<History>();
            Pets = new HashSet<Pet>();
        }

        [Key]
        [Column("LifeStatusID")]
        public int LifeStatusId { get; set; }
        [Required]
        [StringLength(20)]
        public string LifeStatusName { get; set; }

        [InverseProperty(nameof(History.LifeStatus))]
        public virtual ICollection<History> Histories { get; set; }
        [InverseProperty(nameof(Pet.LifeStatus))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
