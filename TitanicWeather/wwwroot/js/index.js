function getWeather() {
    axios({
        method: 'get',
        url: 'https://api.met.no/weatherapi/locationforecast/2.0/complete.json?altitude=41&lat=55.6415&lon=12.0804'
    })
        .then(res => Forecast(res.data.properties.timeseries[0]))
        .catch(err => console.log(err));
}


function Forecast(res) {
    document.getElementById('temp').innerHTML = `
    ${JSON.stringify(res.data.instant.details.air_temperature)}
  `;
    document.getElementById('wind').innerHTML = `
  ${JSON.stringify(res.data.instant.details.wind_speed)}
  `;
    document.getElementById('humid').innerHTML = `
  ${JSON.stringify(res.data.instant.details.relative_humidity)}
  `;
    str = `icons\\properIcons\\png\\${JSON.stringify(res.data.next_1_hours.summary.symbol_code)}.png`;
    document.getElementById('pic').src = str.replace(/"/g, "");
    axios({
        method: 'post',
        url: 'https://titanicweatherapi.azurewebsites.net/api/Titanic/SetPiIcon',
        data: { iconName: res.data.next_1_hours.summary.symbol_code.replace(/"/g, "") },
        headers: { contentType: "application/json; charset=utf-8" }
    })
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.log(error);
        });

}


getWeather();
  /* forecast res object for reference
 {
      "time": "2021-11-24T17:00:00Z",
      "data": {
        "instant": {
          "details": {
            "air_pressure_at_sea_level": 1014.9,
            "air_temperature": 7.9,
            "air_temperature_percentile_10": 7.1,
            "air_temperature_percentile_90": 8.6,
            "cloud_area_fraction": 99.9,
            "cloud_area_fraction_high": 77.3,
            "cloud_area_fraction_low": 99.9,
            "cloud_area_fraction_medium": 0,
            "dew_point_temperature": 6.2,
            "fog_area_fraction": 0,
            "relative_humidity": 89.3,
            "ultraviolet_index_clear_sky": 0,
            "wind_from_direction": 226.5,
            "wind_speed": 3.7,
            "wind_speed_of_gust": 7.3,
            "wind_speed_percentile_10": 3.2,
            "wind_speed_percentile_90": 4.6
          }
        },
        "next_12_hours": {
          "summary": {
            "symbol_code": "cloudy",
            "symbol_confidence": "uncertain"
          },
          "details": {
            "probability_of_precipitation": 70.5
          }
        },
        "next_1_hours": {
          "summary": {
            "symbol_code": "cloudy"
          },
          "details": {
            "precipitation_amount": 0,
            "precipitation_amount_max": 0,
            "precipitation_amount_min": 0,
            "probability_of_precipitation": 0.8,
            "probability_of_thunder": 0
          }
        },
        "next_6_hours": {
          "summary": {
            "symbol_code": "cloudy"
          },
          "details": {
            "air_temperature_max": 7.7,
            "air_temperature_min": 7.1,
            "precipitation_amount": 0,
            "precipitation_amount_max": 0.6,
            "precipitation_amount_min": 0,
            "probability_of_precipitation": 15.8
          }
        }
      }
    },
 */