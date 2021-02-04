using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TAMAGOTCHI.Models
{
    [Table("ActionType")]
    public partial class ActionType
    {
        public ActionType()
        {
            ActionOptions = new HashSet<ActionOption>();
        }

        [Key]
        [Column("ActionTypeID")]
        public int ActionTypeId { get; set; }
        [StringLength(20)]
        public string ActionTypeName { get; set; }

        [InverseProperty(nameof(ActionOption.ActionType))]
        public virtual ICollection<ActionOption> ActionOptions { get; set; }
    }
}
