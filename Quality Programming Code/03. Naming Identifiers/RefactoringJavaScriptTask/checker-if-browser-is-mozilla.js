function checkIfBrowserIsMozilla() {
    var browser = window.navigator.appCodeName,
    isMozilla = (browser == 'Mozilla');

    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}