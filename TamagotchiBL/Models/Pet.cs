using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TAMAGOTCHI.Models
{
    public partial class Pet
    {
        public Pet()
        {
            Histories = new HashSet<History>();
        }

        [Key]
        [Column("PetID")]
        public int PetId { get; set; }
        [Column("PlayerID")]
        public int? PlayerId { get; set; }
        [Required]
        [StringLength(25)]
        public string PetName { get; set; }
        public int? HungerLevel { get; set; }
        public int? CleaningLevel { get; set; }
        public int? HappyLevel { get; set; }
        [Column("LifeCycleID")]
        public int? LifeCycleId { get; set; }
        [Column("LifeStatusID")]
        public int? LifeStatusId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PetBirthDay { get; set; }
        public int PetWeight { get; set; }

        [ForeignKey(nameof(LifeCycleId))]
        [InverseProperty("Pets")]
        public virtual LifeCycle LifeCycle { get; set; }
        [ForeignKey(nameof(LifeStatusId))]
        [InverseProperty("Pets")]
        public virtual LifeStatus LifeStatus { get; set; }
        [ForeignKey(nameof(PlayerId))]
        [InverseProperty("Pets")]
        public virtual Player Player { get; set; }
        [InverseProperty(nameof(History.Pet))]
        public virtual ICollection<History> Histories { get; set; }
    }
}
