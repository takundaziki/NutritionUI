using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NutritionUI.ViewModels;
using NutritionUI.Views;
using Plugin.XamarinFormsSaveOpenPDFPackage;
using Xamarin.Forms;

namespace NutritionUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MealPlansViewModel();
        }

        //navigation to search meals page when user arrow button is clicked
        private async void OnButton_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new NavigationPage(new SearchPage()));
            await Navigation.PushModalAsync(new NavigationPage(new SearchPage()));
        }

        //button when clicked opens pdf file in app
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            //retrieving pdf that is hosted online from a request URI
            var httpClient = new HttpClient();
            var stream = await httpClient.GetStreamAsync("https://documents.hants.gov.uk/hms/HealthyEatingontheRun-28dayEatingPlan.pdf");

            //memory stream which is how to download a file from the internet
            //making use of using so memory is cleaned up well

            using (var memoryStream = new MemoryStream())
            {
                //copy contents to memory stream
                await stream.CopyToAsync(memoryStream);

                //API we are making use of that is invoked the save and view is done on the current. File name saved on disk.
                //Memory stream hold actual file contents
                await CrossXamarinFormsSaveOpenPDFPackage.Current.SaveAndView("myfile.pdf", "application/pdf", memoryStream, PDFOpenContext.InApp);
            }

            

        }
    }
}

            