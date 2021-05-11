using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s00200671_RonnieConlon_OOD_Final
{
    class Game
    {
        // Properties
        public string Name { get; set; }
        public int MetacriticScore { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public decimal Price { get; set; }
        public string Game_Image { get; set; }

        // Constructors
        public Game(string name, int metacriticscore, string description, string platform, decimal price,string game_image = "")
        {
            Name = name;
            MetacriticScore = metacriticscore;
            Description = description;
            Platform = platform;
            Price = price;
            Game_Image = game_image;
        }

        public void DecreasePrice(decimal amount)
        {
            Price -= amount;
        }
    }
}
