/// <reference path="../lib/_references.js" />


var objectFactory = (function () {

    var playersImgs = ["imgs/dog.png", "imgs/cat.png", "imgs/bat.png", "imgs/soldier.png"];
    var stoneImg = "imgs/stone.png";

    var Player = Class.create({
        init: function (imgIndex) {
            this.imgUrl = playersImgs[imgIndex];
            this.height = 32;
            this.width = 32,
            this.positionX = 120;
            this.positionY = 120;
        }
    })

    var Rock = Class.create({
        init: function () {
            this.imgUrl = stoneImg;
            this.height = 16;
            this.width = 16,
            this.positionX = 0;
            this.positionY = 0;
        }
    })

    return {
        createPlayer: function (playerImgIndex) {
            return new Player(playerImgIndex);
        },
        createRock: function () {
            return new Rock();
        }
    }

}());