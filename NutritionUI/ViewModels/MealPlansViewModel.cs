using System;
using System.Collections.ObjectModel;
using NutritionUI.Models;

namespace NutritionUI.ViewModels
{
    public class MealPlansViewModel
    {
        public ObservableCollection<MealPlans> mealPlans { get; set; }
        public MealPlansViewModel()
        {
            mealPlans = new ObservableCollection<MealPlans>
            {

            new MealPlans { Name = "Vegan", Picture = "veganm.jpg", Rating = "10/10" },
            new MealPlans { Name = "Balanced", Picture = "balancedm.jpg", Rating = "10/10" },
            new MealPlans { Name = "High Protein", Picture = "ketom.jpg", Rating = "10/10" }
            };
        }

            
            

        
       
    }


}
