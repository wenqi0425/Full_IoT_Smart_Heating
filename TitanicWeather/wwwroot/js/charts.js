function getWeather() {
    axios({
        method: 'get',
        url: 'https://api.met.no/weatherapi/locationforecast/2.0/complete.json?altitude=41&lat=55.6415&lon=12.0804'
    })
        .then(res => Forecast(res.data.properties))
        .catch(err => console.log(err));
}
function Dates(startDate, daysToAdd) {
    var aryDates = [];

    for (var i = 0; i <= daysToAdd; i++) {
        var currentDate = new Date();
        currentDate.setDate(startDate.getDate() + i);
        aryDates.push(currentDate.getDate() + "/" + (currentDate.getMonth() + 1));
    }

    return aryDates;
}

function Forecast(res) {
    const ForcData = [res.timeseries[0].data.instant.details, res.timeseries[24].data.instant.details, res.timeseries[48].data.instant.details, res.timeseries[59].data.instant.details, res.timeseries[63].data.instant.details, res.timeseries[67].data.instant.details, res.timeseries[71].data.instant.details]
    const ForcTempMin = [ForcData[0].air_temperature_percentile_10, ForcData[1].air_temperature_percentile_10, ForcData[2].air_temperature_percentile_10, ForcData[3].air_temperature_percentile_10, ForcData[4].air_temperature_percentile_10, ForcData[5].air_temperature_percentile_10, ForcData[6].air_temperature_percentile_10]
    const ForcTempMax = [ForcData[0].air_temperature_percentile_90, ForcData[1].air_temperature_percentile_90, ForcData[2].air_temperature_percentile_90, ForcData[3].air_temperature_percentile_90, ForcData[4].air_temperature_percentile_90, ForcData[5].air_temperature_percentile_90, ForcData[6].air_temperature_percentile_90]
    const ForcHumid = [ForcData[0].relative_humidity, ForcData[1].relative_humidity, ForcData[2].relative_humidity, ForcData[3].relative_humidity, ForcData[4].relative_humidity, ForcData[5].relative_humidity, ForcData[6].relative_humidity]
    const ForcWindS = [ForcData[0].wind_speed, ForcData[1].wind_speed, ForcData[2].wind_speed, ForcData[3].wind_speed, ForcData[4].wind_speed, ForcData[5].wind_speed, ForcData[6].wind_speed]
    const labels = Dates(new Date(), 6)

    const temp = document.getElementById('TempChart').getContext('2d');
    const TempChart = new Chart(temp, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'High Temperature °C',
                data: ForcTempMax,
                backgroundColor: "transparent",
                borderColor: "#ee6666",
                borderWidth: 3
            },

            {
                label: 'Low Temperature °C',
                data: ForcTempMin,
                backgroundColor: "transparent",
                borderColor: "#ea7ccc",
                borderWidth: 3
            },
            ]
        },
        options: {
            elements: {
                line: {
                    tension: 0.5
                }
            },
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        },
    });

    const humi = document.getElementById('HumiChart').getContext('2d');
    const humiChart = new Chart(humi, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Humidity %',
                data: ForcHumid,
                backgroundColor: "transparent",
                borderColor: "#73c0de",
                borderWidth: 3
            },
            ]
        },
        options: {
            elements: {
                line: {
                    tension: 0.5
                }
            },
            scales: {
                y: {
                    beginAtZero: false
                }
            }
        }
    });

    const wind = document.getElementById('WindChart').getContext('2d');
    const windChart = new Chart(wind, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Wind Speed  m/s',
                data: ForcWindS,
                backgroundColor: "transparent",
                borderColor: "#fac858",
                borderWidth: 3
            },
            ]
        },
        options: {
            elements: {
                line: {
                    tension: 0.5
                }
            },
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}
getWeather();


/* const tempPi = document.getElementById('TempChartPi').getContext('2d');
const TempChartPi = new Chart(tempPi, {
    type: 'line',
    data: {
        labels: ['Mon', 'Tue', 'Wed', 'Thur', 'Fri', 'Sta', 'Sun'],
        datasets: [{
            label: 'Temperature °C',
            data: [5, 2, 5, 3, 2, 6, 1],
            backgroundColor: "transparent",
            borderColor: "#ea7ccc",
            borderWidth: 3
        }
    ]
    },
    options: {
        elements:{
            line:{
                tension:0.5
            }
        },
        scales: {
            y: {
                beginAtZero: true
            }
        }
    },
}); */
