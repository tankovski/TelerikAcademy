var canvas = document.getElementsByTagName("canvas")[0].getContext("2d");
canvas.lineWidth = 1;
canvas.fillStyle = "#90CAD7";
canvas.strokeStyle = "#234C56";

//Draw head
canvas.arc(100, 100, 50, 0, 2 * Math.PI, false);
canvas.fill();
canvas.stroke();