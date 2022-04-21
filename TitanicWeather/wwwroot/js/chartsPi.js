function GetData() {
    axios({
        method: 'get',
        url: 'https://titanicweatherapi.azurewebsites.net/api/Titanic/SummarizedData'
    })
        .then(res => {DrawCharts(res.data); })
        .catch(err => console.log(err));
}
function Dates(startDate, daysToAdd) {
    var aryDates = [];

    for (var i = daysToAdd; i >= 0; i--) {
        var currentDate = new Date();
        currentDate.setDate(startDate.getDate() - i);
        aryDates.push(currentDate.getDate() + "/" + (currentDate.getMonth() + 1));
    }

    return aryDates;
}

function DrawCharts(res) {
    const labels = Dates(new Date(), 6)
    let MaxTemp = [];
    let MinTemp = [];
    let MaxHum = [];
    let MinHum = [];

    res.forEach(element => {
        MaxTemp.push(element.maxTemp);
        MinTemp.push(element.minTemp);
        MaxHum.push(element.maxHumid);
        MinHum.push(element.minHumid);
    });
    const tempPi = document.getElementById('TempChartPi').getContext('2d');
    const TempChartPi = new Chart(tempPi, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'High Temperature °C',
                data: MaxTemp,
                backgroundColor: "transparent",
                borderColor: "#ee6666",
                borderWidth: 3
            },

            {
                label: 'Low Temperature °C',
                data: MinTemp,
                backgroundColor: "transparent",
                borderColor: "#ea7ccc",
                borderWidth: 3
            }
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
                label: 'High Humidity %',
                data: MaxHum,
                backgroundColor: "transparent",
                borderColor: "#73c0de",
                borderWidth: 3
            },
            {
                label: 'LowHumidity %',
                data: MinHum,
                backgroundColor: "transparent",
                borderColor: "#3ca7d1",
                borderWidth: 3
            }
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
};

GetData();
