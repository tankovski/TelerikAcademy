
var timeNow = new Date().getTime();
var timeLater;
var trash = document.getElementById("trash");
var junks = document.getElementsByClassName("junk");
var length = junks.length;
for (var i = 0; i < length; i++) {
    junks[i].style.position = "absolute";
    junks[i].style.top = "" + ((50 + Math.random() * 200) | 0) + "px";
    junks[i].style.left = "" + ((200 + Math.random() * 400) | 0) + "px";
}

printScore();
function openTrash(ev) {
    trash.src = "imgs/open2.png";
    ev.preventDefault();

}

function dragFinish() {
    trash.src = "imgs/closed2.png";
}

function drag(ev) {
    ev.dataTransfer.setData("dragged-id", ev.target.id);
}

function drop(ev) {
    trash.src = "imgs/closed2.png";
    ev.preventDefault();
    var data = ev.dataTransfer.getData("dragged-id");
    document.body.removeChild(document.getElementById(data));
}

function askForName() {
    if (junks.length == 0) {
        timeLater = new Date().getTime();

        var label = document.createElement("label");
        label.innerText = "Enter your name.";
        label.htmlFor = "name";

        var inputName = document.createElement("input");
        inputName.type = "text";
        inputName.id = "name";

        var button = document.createElement("button");
        button.innerText = "Save";
        button.style.width = "50px";
        button.onclick = saveScore;

        document.body.appendChild(label);
        document.body.appendChild(inputName);
        document.body.appendChild(button);
    }
}
function saveScore() {
    var inputName = document.getElementById("name");
    var key = (timeLater - timeNow) / 1000;
    var value = inputName.value;
    localStorage.setItem(key, value);
    printScore();
}

function printScore() {

    var storageArray = [];
    for (var i = 0; i < localStorage.length; i++) {

        storageArray[i] = parseFloat(localStorage.key(i));
    }
    storageArray.sort(function (a, b) { return a - b });
    var div = document.getElementById("resultContaier");
    div.innerHTML = "";
    for (var j = 0; j < 5; j++) {
        var key = storageArray[j];
        var value = localStorage.getItem(key);
        div.innerHTML += key + " - ";
        div.innerHTML += value + "<br/>";
    }
}