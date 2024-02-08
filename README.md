# House Price Prediction System

## Overview
The House Price Prediction System is a  project that combines machine learning with web and mobile technologies to predict housing prices based on various parameters. The system comprises three main components: the House Price Prediction Model, the Flask API, and the .NET MAUI Mobile App.

<div style="display:flex;">
  <img src="https://github.com/OliverNagy10/HousePricePredictor/blob/main/Resources/Images/starting_page.png" alt="Image 1" style="width:30%; margin-right:5px;">
  <img src="https://github.com/OliverNagy10/HousePricePredictor/blob/main/Resources/Images/predict_page.png" alt="Image 2" style="width:30%; margin-right:5px;">
  <img src="https://github.com/OliverNagy10/HousePricePredictor/blob/main/Resources/Images/prediciton.png" alt="Image 3" style="width:30%;">
</div>

### The Model:
#### Dataset
The dataset used for training the model contains information on UK house prices, including features like:
- Year: The year of construction
- Town/City: The town or city where the property is located
- County: The county where the property is located
- Property_Type: The type of property (e.g., flat, detached house, semi-detached house)
- New_Build: A binary indicator for whether the property is newly built or not
- Price: The price of the property

#### Model Development
The model development process involves several steps:
1. Data Preprocessing: The dataset is preprocessed to handle missing values and categorical features. Numeric features are scaled using StandardScaler, and categorical features are encoded using OneHotEncoder.
2. Model Selection: Various regression algorithms are considered for training the model, including Ridge Regression, ElasticNet, Random Forest Regression, Gradient Boosting Regression, and XGBoost Regression. These algorithms are evaluated based on performance metrics such as Mean Squared Error, Mean Absolute Error, R-squared Score, and Explained Variance Score.
3. Model Training: The chosen algorithm, Ridge Regression, is trained on the entire dataset using the preprocessed features.
4. Model Evaluation: The trained model is evaluated on a test dataset to assess its performance. Performance metrics are calculated, including Mean Squared Error, Mean Absolute Error, R-squared Score, and Explained Variance Score.
5. Model Deployment: The trained model is saved to a file using the joblib library.

R^2 Score: 0.7067 (Testing)
Explained Variance Score: 0.7067 (Testing)

### Flask API
The Flask API serves as the backend of the House Price Prediction System, responsible for handling prediction requests and returning results. Key features of the Flask API include:

- Endpoint: Exposes a /predict endpoint for making predictions.
- Input Data: Accepts JSON-formatted input data containing parameters such as year, town/city, county, property type, new build indicator, and current price.
- Prediction: Utilizes the trained House Price Prediction Model to predict housing prices based on the input data.
- Response: Returns JSON-formatted prediction results, including predicted prices and growth rates for the next three years.

### .NET MAUI Mobile App
The .NET MAUI Mobile App serves as the frontend of the House Price Prediction System, allowing users to input parameters and visualize predicted prices and growth rates. Key features of the .NET MAUI Mobile App include:

- Cross-Platform Development: Developed using the .NET MAUI framework for targeting iOS, Android, and Windows platforms.
- User Interface: Utilizes Xamarin.Forms for creating the user interface components, including input fields, buttons, and charts.
- HTTP Communication: Uses HttpClient to communicate with the Flask API for making predictions and retrieving results.
- Visualization: Displays predicted prices and growth rates using charts and graphical representations, allowing users to explore the data interactively.
- 

### Demo Video 
  <img src="https://github.com/OliverNagy10/HousePricePredictor/blob/main/Resources/Images/Demo.gif" alt="Image 3" >
