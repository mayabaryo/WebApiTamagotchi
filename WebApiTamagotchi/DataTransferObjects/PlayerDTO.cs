using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamagotchiBL.Models;

namespace WebApiTamagotchi.DataTransferObjects
{
    public class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerLastName { get; set; }
        public string PlayerEmail { get; set; }
        public DateTime PlayerBirthDay { get; set; }
        public string PlayerGender { get; set; }
        public string PlayerUsername { get; set; }
        public string PlayerPassword { get; set; }

        public PlayerDTO() { }
        public PlayerDTO(Player p)
        {
            PlayerId = p.PlayerId;
            PlayerName = p.PlayerName;
            PlayerLastName = PlayerLastName;
            PlayerBirthDay = p.PlayerBirthDay;
            PlayerEmail = p.PlayerEmail;
            PlayerGender = p.PlayerGenedr;
            PlayerUsername = p.PlayerUsername;
            PlayerPassword = p.PlayerPassword;

        }
    }
}
