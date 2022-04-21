# TitanicWeather
## Important:
In order to build the solution a Secrets.cs file has to be added in the TitanicWeather project.

The file contains the connection string to the database. That's why it's not in the GitHub repository.

## Description:
This is a semester project we made in the 3rd semester of computer science in zealand.
Our idea was to make a weather application with a Raspberry Pi. The main idea is that we measure data on the pi and send this to a web application using a rest-service.

## API method links:

Our weather API is published at this web address: https://titanicweatherapi.azurewebsites.net/

GET

https://titanicweatherapi.azurewebsites.net/api/Titanic/All

https://titanicweatherapi.azurewebsites.net/api/Titanic/Recent

https://titanicweatherapi.azurewebsites.net/api/Titanic/Command

https://titanicweatherapi.azurewebsites.net/api/Titanic/HeatingLevel

https://titanicweatherapi.azurewebsites.net/api/Titanic/SummarizedData

https://titanicweatherapi.azurewebsites.net/api/Titanic/PiIcon


POST

https://titanicweatherapi.azurewebsites.net/api/Titanic/SetCommand

https://titanicweatherapi.azurewebsites.net/api/Titanic/SetHeatingLevel

https://titanicweatherapi.azurewebsites.net/api/Titanic/SetPiIcon


## Instructions:

CutePi:
For the database to be updated both the TitanicUDPServer and RestClient projects should be running.

The raspberry pi should run both the restReceive.py and the iconReceive.py scripts. (Can be done in one line: python3 restReceive.py & python3 iconReceive.py &)

Now you can navigate to the Cute Pi page in the weather API.

There are three buttons.

The GetCurrentData button manually runs a script on the Pi to update the Measurement data.

The 30MIN/60MIN button sets a parameter to be passed when the ON/OFF button is clicked. (This is used in some of our measurement logic.)

The ON/OFF button turns on the heating (If the logic permits it, it won't work if the temperature is higher than 24°C.)

## Functionalities:
When you start the application you can see the home page. On this page you see the current weather, temperature, wind speed and humidity. (3rd party API)

This page also updates the LED Matrix on the Raspberry Pi if all instructions have been followed.

The CutePi page interacts with the Raspberry Pi. (All data was gathered from the Pi's sensor)

The Forecast page is another page that uses the 3rd party API to show the forecast for the next few days.

The Add On page is an exciting feature coming in a future implementation. :)
