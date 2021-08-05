using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repository
{
    public class MenuItem
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }
        public MenuItem() { }
        public MenuItem(int number, string name, string description, List<string> ingredients, decimal price)
        {
            Number = number;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }


    }

}
