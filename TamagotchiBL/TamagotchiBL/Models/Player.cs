using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiBL.Models
{
    public partial class Player
    {
        public Player()
        {
            Pets = new HashSet<Pet>();
        }

        [Key]
        [Column("PlayerID")]
        public int PlayerId { get; set; }
        [Required]
        [StringLength(15)]
        public string PlayerName { get; set; }
        [Required]
        [StringLength(15)]
        public string PlayerLastName { get; set; }
        [Required]
        [StringLength(25)]
        public string PlayerEmail { get; set; }
        [Required]
        [StringLength(20)]
        public string PlayerGenedr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PlayerBirthDay { get; set; }
        [Required]
        [StringLength(30)]
        public string PlayerUsername { get; set; }
        [Required]
        [StringLength(30)]
        public string PlayerPassword { get; set; }

        [InverseProperty(nameof(Pet.Player))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
