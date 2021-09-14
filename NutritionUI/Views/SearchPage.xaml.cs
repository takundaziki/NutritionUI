using System;
using System.Collections.Generic;
using System.Linq;
using NutritionUI.Services;
using Refit;
using Xamarin.Forms;
using NutritionUI.ViewModels;

namespace NutritionUI.Views
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
            
        }

        
        
    }
}
