using System;
using System.Collections.Generic;

namespace NutritionUI.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Item
    {
        public double Sugar_g { get; set; }
        public double Fiber_g { get; set; }
        public double Serving_size_g { get; set; }
        public int Sodium_mg { get; set; }
        public string Name { get; set; }
        public int Potassium_mg { get; set; }
        public double Fat_saturated_g { get; set; }
        public double Fat_total_g { get; set; }
        public double Calories { get; set; }
        public int Cholesterol_mg { get; set; }
        public double Protein_g { get; set; }
        public double Carbohydrates_total_g { get; set; }
    }

    public class Root
    {
        public List<Item> Items { get; set; }
    }


}
