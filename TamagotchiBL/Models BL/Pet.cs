using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TAMAGOTCHI.UI;

namespace TAMAGOTCHI.Models
{
    public partial class Pet
    {
        public void DoActionPlay(ActionOption actionOption)
        {
            this.HappyLevel += actionOption.OptionEffect;
            History h = new History()
            {
                PetId = this.PetId,
                TimeOfAction = DateTime.Now,
                OptionId = actionOption.OptionId,
                LifeCycleId = this.LifeCycleId,
                LifeStatusId = this.LifeStatusId
            };
            UIMain.db.AddHistory(h);
            UIMain.db.SaveChanges();
        }

        public void DoActionClean(ActionOption actionOption)
        {
            this.CleaningLevel += actionOption.OptionEffect;
            History h = new History()
            {
                PetId = this.PetId,
                TimeOfAction = DateTime.Now,
                OptionId = actionOption.OptionId,
                LifeCycleId = this.LifeCycleId,
                LifeStatusId = this.LifeStatusId
            };
            UIMain.db.AddHistory(h);
            UIMain.db.SaveChanges();
        }

        public void feed(ActionOption a)
        {
            this.HungerLevel += a.OptionEffect;
            History h = new History()
            {
                PetId = this.PetId,
                TimeOfAction = DateTime.Now,
                OptionId = a.OptionId,
                LifeCycleId = this.LifeCycleId,
                LifeStatusId = this.LifeStatusId
            };
            UIMain.db.AddHistory(h);
            this.CleaningLevel = this.CleaningLevel - (a.OptionEffect / 2);
            UIMain.db.SaveChanges();
        }

        public string levels(int? level, string option)
        {
            string str = "";

            if (level < 40)
            {
                str = $" you should take better care of your pets{option} ";
            }

            if (level > 40 && level < 60)
            {
                str = $"your pets {option} is a bit low...";
            }

            if (level > 60)
            {
                str = $"Good Job! your pets {option} is great!";
            }

            return str;
        }
    }
}
