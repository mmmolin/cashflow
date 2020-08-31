function hamburgerMenu() {
    let element = document.getElementById("topnav");
    if (element.className === "topnav") {
        element.className += " responsive";
    } else {
        element.className = "topnav";
    }
}