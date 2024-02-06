from flask import Flask, request, jsonify
import joblib
import pandas as pd

app = Flask(__name__)

# Load the trained model
model = joblib.load('C:/Users/ocsio\Desktop/HousePricePredictorUK/Model/house_price_prediction_modelV9.joblib')

@app.route('/predict', methods=['POST'])
def predict():
    try:
        # Get JSON data from the request
        data = request.json

        # Print or log the received JSON data
        print("Received JSON data:", data)

        # Extract individual fields
        year = int(data['Year'])
        town_city = data['Town/City']
        district = data['Disctrict ']  # Corrected key name
        county = data['County']
        street = data['Street']
        property_type = data['Property_Type']
        new_build = int(data['New_Build'])

        # Log the extracted fields
        print("Extracted Fields:")
        print("Year:", year)
        print("Town/City:", town_city)
        print("District:", district)
        print("County:", county)
        print("Street:", street)
        print("Property Type:", property_type)
        print("New Build:", new_build)

        user_input = {
            'Year': year,
            'Town/City': town_city,
            'Disctrict ': district,
            'County': county,
            'Street': street, 
            'Property_Type': property_type,
            'New_Build': new_build
        }

        # Create a DataFrame for prediction
        user_input_data = pd.DataFrame([user_input])

        # Predict the price for the current year
        prediction = model.predict(user_input_data)[0]
        
        # Convert the prediction value to a JSON serializable type
        prediction = float(prediction)

        # Print the prediction value
        print("Prediction:", prediction)

        # Return the prediction for the current year
        return jsonify({'prediction': prediction})
    except Exception as e:
        # Print any error that occurs during the prediction process
        print("Prediction Error:", e)
        return jsonify({'error': str(e)}), 400

if __name__ == '__main__':
    app.run(debug=True)
