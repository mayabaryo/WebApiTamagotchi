using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Collections.Generic;
using TAMAGOTCHI.UI;

namespace TAMAGOTCHI.Models
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

        public List<ActionOption> GetAllCleans()
        {
            const int OPTION_CLEAN = 2;
            List<ActionOption> list = this.ActionOptions.Where(a => a.ActionTypeId == OPTION_CLEAN).ToList();
            return list;
        }

        public List<History> GetAllHistory()
        {
            const int DEAD_STATUS_ID = 4;
            Pet p = UIMain.CurrentPlayer.Pets.Where(p => p.LifeStatusId != DEAD_STATUS_ID).FirstOrDefault();
            List<History> list = this.Histories.Where(h => h.PetId == p.PetId).ToList();
            return list;
        }

        public void AddPlayer(Player p)
        {
            this.Players.Add(p);
        }

        public void AddHistory(History h)
        {
            this.Histories.Add(h);
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
    }
}
