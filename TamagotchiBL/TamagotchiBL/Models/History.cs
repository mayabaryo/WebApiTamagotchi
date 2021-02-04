using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiBL.Models
{
    [Table("History")]
    public partial class History
    {
        [Key]
        [Column("PetID")]
        public int PetId { get; set; }
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime TimeOfAction { get; set; }
        [Column("OptionID")]
        public int OptionId { get; set; }
        [Column("LifeCycleID")]
        public int? LifeCycleId { get; set; }
        [Column("LifeStatusID")]
        public int? LifeStatusId { get; set; }

        [ForeignKey(nameof(LifeCycleId))]
        [InverseProperty("Histories")]
        public virtual LifeCycle LifeCycle { get; set; }
        [ForeignKey(nameof(LifeStatusId))]
        [InverseProperty("Histories")]
        public virtual LifeStatus LifeStatus { get; set; }
        [ForeignKey(nameof(OptionId))]
        [InverseProperty(nameof(ActionOption.Histories))]
        public virtual ActionOption Option { get; set; }
        [ForeignKey(nameof(PetId))]
        [InverseProperty("Histories")]
        public virtual Pet Pet { get; set; }
    }
}
