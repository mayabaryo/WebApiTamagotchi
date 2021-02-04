using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiBL.Models
{
    public partial class ActionOption
    {
        public ActionOption()
        {
            Histories = new HashSet<History>();
        }

        [Key]
        [Column("OptionID")]
        public int OptionId { get; set; }
        [StringLength(20)]
        public string OptioName { get; set; }
        public int? OptionEffect { get; set; }
        [Column("ActionTypeID")]
        public int? ActionTypeId { get; set; }

        [ForeignKey(nameof(ActionTypeId))]
        [InverseProperty("ActionOptions")]
        public virtual ActionType ActionType { get; set; }
        [InverseProperty(nameof(History.Option))]
        public virtual ICollection<History> Histories { get; set; }
    }
}
