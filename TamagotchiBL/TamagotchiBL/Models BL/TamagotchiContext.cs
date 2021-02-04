using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Collections.Generic;

namespace TamagotchiBL.Models
{
    public partial class TamagotchiContext : DbContext
    {
        public Player Login(string email, string pswd)
        {
            Player p = this.Players.Where(p => p.PlayerEmail == email && p.PlayerPassword == pswd).FirstOrDefault();
            return p;
        }

        public List<ActionOption> GetAllGames()
        {
            const int OPTION_PLAY = 3;
            List<ActionOption> list = this.ActionOptions.Where(a => a.ActionTypeId == OPTION_PLAY).ToList();
            return list;
        }

        public void AddPlayer(Player p)
        {
            this.Players.Add(p);
            this.SaveChanges();
        }

        public void AddHistory(History h)
        {
            this.Histories.Add(h);
            this.SaveChanges();
        }

        public List<ActionOption> GetAllActions()
        {
            List<ActionOption> list = this.ActionOptions.ToList();
            return list;
        }
       
        public List<ActionOption> GetFoodList()
        {
            const int foodID = 1;
            List<ActionOption> list = this.ActionOptions.Where(a => a.ActionTypeId == foodID).ToList();
            return list;
        }

        public void DoActionPlay(ActionOption actionOption, int playerId)
        {
            Player p = this.Players.Where(pp => pp.PlayerId == playerId).FirstOrDefault();
            List<Pet> pets = this.Pets.Where(ppp => ppp.PlayerId == p.PlayerId).ToList();
            const int DEAD_STATUS_ID = 4;
            Pet pet = pets.Where(p => p.LifeStatusId != DEAD_STATUS_ID).FirstOrDefault();
            pet.HappyLevel += actionOption.OptionEffect;
            if (pet.HappyLevel > 100)
                pet.HappyLevel = 100;
            History h = new History()
            {
                PetId = pet.PetId,
                TimeOfAction = DateTime.Now,
                OptionId = actionOption.OptionId,
                LifeCycleId = pet.LifeCycleId,
                LifeStatusId = pet.LifeStatusId
            };
            this.AddHistory(h);
            this.SaveChanges();
        }

        public void feed(ActionOption actionOption, int playerId)
        {
            Player p = this.Players.Where(pp => pp.PlayerId == playerId).FirstOrDefault();
            List<Pet> pets = this.Pets.Where(ppp => ppp.PlayerId == p.PlayerId).ToList();
            const int DEAD_STATUS_ID = 4;
            Pet pet = pets.Where(p => p.LifeStatusId != DEAD_STATUS_ID).FirstOrDefault();
            pet.HungerLevel += actionOption.OptionEffect;
            if (pet.HungerLevel > 100)
                pet.HungerLevel = 100;
            History h = new History()
            {
                PetId = pet.PetId,
                TimeOfAction = DateTime.Now,
                OptionId = actionOption.OptionId,
                LifeCycleId = pet.LifeCycleId,
                LifeStatusId = pet.LifeStatusId
            };
            this.AddHistory(h);
            pet.CleaningLevel = pet.CleaningLevel - (actionOption.OptionEffect / 2);
            if (pet.CleaningLevel < 0)
                pet.CleaningLevel = 0;
            this.SaveChanges();
        }


    }
}
