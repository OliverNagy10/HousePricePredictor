using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HousePricePredictorUK
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            PredictHousePriceAsync(2024, "LEEDS", "LEEDS", "WEST YORKSHIRE", "CARR BRIDGE DRIVE", "F", 1);
        }

        private async void PredictHousePriceAsync(int year, string townCity, string district, string county, string street, string propertyType, int newBuild)
        {
            try
            {
                // Prepare the data
                var data = new Dictionary<string, object>
                {
                    { "Year", year },
                    { "Town/City", townCity },
                    { "Disctrict ", district },
                    { "County", county },
                    { "Street", street },
                    { "Property_Type", propertyType },
                    { "New_Build", newBuild }
                };

                // Serialize the data to JSON
                var jsonContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                // Define the API endpoint URL
                var apiUrl = "http://localhost:5000/predict"; // Update with your API endpoint URL

                // Create a new HttpClient instance
                using (var client = new HttpClient())
                {
                    // Send a POST request to the API endpoint
                    var response = await client.PostAsync(apiUrl, jsonContent);

                    // Ensure a successful response
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content
                        var responseContent = await response.Content.ReadAsStringAsync();

                        // Display the predicted prices in a message box or update UI
                        await DisplayAlert("Predicted Prices", responseContent, "OK");
                    }
                    else
                    {
                        // Handle unsuccessful response
                        await DisplayAlert("Error", $"Failed to call API: {response.StatusCode}", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}

