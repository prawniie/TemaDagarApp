async function GetThemeDay() {

    document.getElementById("result").innerText = "";
    document.getElementById("error").innerText = "";

    let date = document.getElementById("date").value;

    let response = await fetch(`temadagar/getthemeday?date=${date}`);

    if (response.status === 200) {
        let result = await response.text();
        document.getElementById("result").innerText = result;
    }
    else if (response.status === 400) {
        let error = await response.text();
        document.getElementById("error").innerText = error;
    }
    else if (response.status === 404) {
        let error = await response.text();
        document.getElementById("error").innerText = error;
    }

}
