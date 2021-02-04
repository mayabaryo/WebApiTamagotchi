using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamagotchiBL.Models;

namespace WebApiTamagotchi.DataTransferObjects
{
    public class PetDTO
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public int PlayerId { get; set; }
        public double PetWeight { get; set; }
        public DateTime PetBirthDay { get; set; }
        public int HungerLevel { get; set; }
        public int CleaningLevel { get; set; }
        public int HappyLevel { get; set; }
        public int LifeCycleId { get; set; }
        public int LifeStatusId { get; set; }

        public PetDTO() { }
        public PetDTO(Pet a)
        {
            PetId = a.PetId;
            PetName = a.PetName;
            PlayerId = (int)a.PlayerId;
            PetWeight = a.PetWeight;
            PetBirthDay = a.PetBirthDay;
            HungerLevel = (int)a.HungerLevel;
            CleaningLevel = (int)a.CleaningLevel;
            HappyLevel = (int)a.HappyLevel;
            LifeCycleId = (int)a.LifeCycleId;
            LifeStatusId = (int)a.LifeStatusId;
        }
    }
}
