using System;
using System.Net.Http;
using System.Text;

namespace HousePricePredictorUK
{
    public partial class MainPage : ContentPage
    {
        private const string ApiUrl = "http://127.0.0.1:5000/predict"; // Replace this with your actual API endpoint

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPredictClicked(object sender, EventArgs e)
        {
            try
            {
                // Construct the JSON data to send to the API
                string jsonData = "{" +
                    $"\"Year\": {YearEntry.Text}," +
                    $"\"Town/City\": \"{TownCityEntry.Text}\"," +
                    $"\"County\": \"{CountyEntry.Text}\"," +
                    $"\"Property_Type\": \"{PropertyTypeEntry.Text}\"," +
                    $"\"New_Build\": {NewBuildSwitch.IsToggled.ToString().ToLower()}," + // Convert bool to lowercase string
                    $"\"Current_Price\": {CurrentPriceEntry.Text}" +
                    "}";

                // Create HttpClient instance
                HttpClient client = new HttpClient();

                // Create StringContent with JSON data
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Send POST request to the API
                HttpResponseMessage response = await client.PostAsync(ApiUrl, content);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response to get the prediction
                    dynamic predictionData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);

                    // Get the predicted prices and growth rates from the response
                    dynamic predictions = predictionData.predictions;
                    dynamic growthRates = predictionData.growth_rates;

                    // Display the predictions and growth rates
                    PredictionLabel.Text = "Predictions and Growth Rates:";
                    for (int i = 0; i < predictions.Count; i++)
                    {
                        double predictedPrice = Convert.ToDouble(predictions[i]);
                        double growthRate = Convert.ToDouble(growthRates[i]);

                        // Update the UI with the prediction and growth rate
                        PredictionLabel.Text += $"\nYear {i + 1}: Predicted Price: {predictedPrice:C}, Growth Rate: {growthRate * 100:F2}%";
                    }
                }
                else
                {
                    // Display error message if the response is not successful
                    PredictionLabel.Text = "Error: Failed to get predictions";
                }
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs
                PredictionLabel.Text = $"Error: {ex.Message}";
            }
        }
    }
}
