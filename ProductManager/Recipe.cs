using System.Collections.Generic;

namespace MealPlanner
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Instructions { get; set; }
        public int Calories { get; set; }

        public Recipe(string name, string description, List<string> ingredients, List<string> instructions, int calories)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Instructions = instructions;
            Calories = calories;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
