using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TAMAGOTCHI.Models
{
    public partial class Player
    {
        public void AddPet(Pet p)
        {
            this.Pets.Add(p);
        }
    }
}
