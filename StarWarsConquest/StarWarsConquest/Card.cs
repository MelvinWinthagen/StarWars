using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsConquest
{
    public class Card
    {
        public int ID;
        public string LinkedButton;
        public string Name;
        public string Class;
        public int Cost;
        public int Health;
        public int Damage;
        public string Photo;

        public Card()
        {
            ID = 0;
            LinkedButton = "[MISSING]";
            Name = "[MISSING]";
            Class = "[MISSING]";
            Cost = 0;
            Health = 0;
            Damage = 0;
            Photo = "[MISSING]";
        }
    }
}
