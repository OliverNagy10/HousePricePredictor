from flask import Flask, request, jsonify
import joblib
import pandas as pd
import os

app = Flask(__name__)

DEFAULT_MODEL_PATH = r'C:\Users\ocsio\Desktop\HousePricePredictorUK\Resources\Model\house_price_prediction_modelV11.joblib'

# Load the trained model using the configured model path
model_path = os.getenv('MODEL_PATH', DEFAULT_MODEL_PATH)
model = joblib.load(model_path)

def calculate_growth_rate(model, input_data, current_price):
    predicted_price = model.predict(input_data)[0]
    growth_rate = (predicted_price - current_price) / current_price
    return predicted_price, growth_rate

@app.route('/predict', methods=['POST'])
def predict():
    try:
        # Get JSON data from the request
        data = request.json

        # Extract individual fields
        year = int(data['Year'])
        town_city = data['Town/City']
        county = data['County']
        property_type = data['Property_Type']
        new_build = int(data['New_Build'])
        current_price = float(data['Current_Price'])

        # Create a DataFrame for prediction
        user_input_data = pd.DataFrame({
            'Year': [year] * 4,
            'Town/City': [town_city] * 4,
            'County': [county] * 4,
            'Property_Type': [property_type] * 4,
            'New_Build': [new_build] * 4
        })

        # Predict the prices and growth rates for the next 3 years
        predictions = []
        growth_rates = []
        for year_offset in range(3):
            predicted_price, growth_rate = calculate_growth_rate(model, user_input_data, current_price)
            predictions.append(predicted_price)
            growth_rates.append(growth_rate)
            user_input_data['Year'] += 1  # Update year for the next prediction
            current_price = predicted_price  # Update current price for the next prediction


        # Return the predictions and growth rates for the next 3 years
        response_data = {
            'predictions': predictions,
            'growth_rates': growth_rates
        }
        return jsonify(response_data)
    except Exception as e:
        # Return error message if prediction fails
        return jsonify({'error': str(e)}), 400

if __name__ == '__main__':
    
    app.run(host='0.0.0.0', port=5000)
    app.run(debug=True)
