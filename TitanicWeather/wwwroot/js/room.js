//const toggleHeating = document.getElementById('heating');
//const toggleTime = document.getElementById('time');

//function changeStatusOfToggleTime() {
//    if (toggleHeating.disabled == true) {
//        toggleTime.disabled = true;
//    }
//}

function getRoomTemp() {
    axios({
        method: 'get',
        url: 'https://titanicweatherapi.azurewebsites.net/api/Titanic/Recent'
    })
        .then(res => ShowRoomTemp(res))
        .catch(err => console.log(err));
}

function PostCommand(command) {
    axios({
        method: 'post',
        url: 'https://titanicweatherapi.azurewebsites.net/api/Titanic/SetCommand',
        data: { integer: command },
        headers: { contentType: "application/json; charset=utf-8" }
    })
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.log(error);
        });
    document.getElementById("loading").innerHTML = "Loading, don't push more buttons";
    document.getElementById("heating").disabled = true;
    document.getElementById("getdata").disabled = true;
    setTimeout(() => {
        document.getElementById("heating").disabled = false;
        document.getElementById("getdata").disabled = false;
        document.getElementById("loading").innerHTML = ``;
        getHeatLevel();
        getRoomTemp();
    }, 6500)


}
function ShowRoomTemp(res) {

    //document.getElementById('temp').innerHTML = `
    //${JSON.stringify(res.data.temperature)}
    //`;
    //document.getElementById('humid').innerHTML = `
    //${JSON.stringify(res.data.humidity)}
    //`;
    vm.Temperature = res.data.temperature;
    vm.Humidity = res.data.humidity;
}
function PostHeatingLevel(lev = vm.calcLevel) {
    axios({
        method: 'post',
        url: 'https://titanicweatherapi.azurewebsites.net/api/Titanic/SetHeatingLevel',
        data: { integer: lev },
        headers: { contentType: "application/json; charset=utf-8" }
    })
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.log(error);
        });
}
function getHeatLevel() {
    axios({
        method: 'get',
        url: 'https://titanicweatherapi.azurewebsites.net/api/Titanic/HeatingLevel'
    })
        .then(res => vm.Level = res.data)
        .catch(err => console.log(err))
}
function TurnOnOff() {
    var checkBox = document.getElementById("heating");
    if (checkBox.checked) {
        PostHeatingLevel();
        PostCommand(1);
        console.log("on")
        //document.getElementById("time").backgroundColor ="#ee6666"
        //document.getElementById("time").disabled = false;
    }
    else {
        PostCommand(0);
        //document.getElementById("time").disabled = true;
        //document.getElementById("time").backgroundColor = "grey"
        console.log("off")
    }

    //if (toggleHeating.disabled == true) {
    //    toggleTime.disabled = true;
    //}
}
function GetNewData() {
    PostCommand(2);
    //setTimeout(() => {
    //    getRoomTemp();
    //    console.log("clicked");
    //}, 5500);
}

var vm = new Vue({
    el: '#app',
    data: {
        Level: 0,
        TimeHome: true,
        Temperature: 0,
        Humidity: 0

    },
    computed: {
        calcLevel() {

            if (this.Temperature >= 24) {
                return 0
            }
            if (this.Humidity > 60) {
                return 1
            }
            let result = 0;
            let tempDiff = 24 - this.Temperature;
            if (tempDiff < 5 && tempDiff > 0) {
                result = 1
            }
            if (tempDiff < 10 && tempDiff > 5) {
                result = 2
            }
            if (tempDiff < 15 && tempDiff > 10) {
                result = 3
            }
            if (this.TimeHome) {
                result += 1;
            }
            return result;
        }
    }
})

document.getElementById("getdata").addEventListener("click", GetNewData);
document.getElementById("heating").addEventListener("click", TurnOnOff)
getRoomTemp();
getHeatLevel();
