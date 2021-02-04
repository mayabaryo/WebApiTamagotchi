using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamagotchiBL.Models;

namespace WebApiTamagotchi.DataTransferObjects
{
    public class ActionOptionDTO
    {
        public int OptionId { get; set; }
        public string OptioName { get; set; }
        public int? OptionEffect { get; set; }
        public int? ActionTypeId { get; set; }
        //public virtual ActionType ActionType { get; set; }
        //public virtual ICollection<History> Histories { get; set; }
        public ActionOptionDTO() { }
        public ActionOptionDTO(ActionOption a) 
        {
            this.OptionId = a.OptionId;
            this.OptioName = a.OptioName;
            this.OptionEffect = a.OptionEffect;
            this.ActionTypeId = a.ActionTypeId;
        }
    }
}
