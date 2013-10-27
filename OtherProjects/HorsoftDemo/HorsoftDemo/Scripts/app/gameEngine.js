/// <reference path="../lib/_references.js" />

var GameEngine = Class.create({
    init: function (playerImgIndex) {
        this.gameInterval;
        this.player = objectFactory.createPlayer(playerImgIndex);
        this.speed = 40;
        this.level = 1;
        this.rocks = [];
        this.isGameRunning = true;
    },
    drawInCanvas: function () {
        var self = this;
        var canvas = document.getElementById("gameCanvas").getContext("2d");
        //Clear canvas
        canvas.clearRect(0, 0, 450, 450);

        //Draw player
        var playerImg = new Image();
        playerImg.onload = function () {
            canvas.drawImage(playerImg, self.player.positionX, self.player.positionY, self.player.width, self.player.height);
        }
        playerImg.src = this.player.imgUrl;

        //Draw rocks
        var rockImg = new Image();
        rockImg.onload = function () {
            for (var i = 0; i < self.rocks.length; i++) {
                canvas.drawImage(rockImg, self.rocks[i].positionX, self.rocks[i].positionY, self.rocks[i].width, self.rocks[i].height);
            }
        }
        rockImg.src = this.rocks[0].imgUrl;



    },
    //PLayer logic
    movePlayerLeft: function () {
        if (this.player.positionX > 0) {
            this.player.positionX-=3;
        }
    },
    movePlayerRight: function () {
        if (this.player.positionX < 270) {
            this.player.positionX+=3;
        }
    },
    //Rocks logic
    createRocks: function () {
        for (var i = 0; i < (this.level+1) ; i++) {
            this.rocks[i] = objectFactory.createRock();
            this.rocks[i].positionX = Math.floor((Math.random() * 270) + 1);
            this.rocks[i].positionY = Math.floor((Math.random() * 50) + 1);
        }
    },
    moveRocks:function () {
        var self = this;
        for (var i = 0; i < this.rocks.length; i++) {
            if (this.rocks[i].positionY<155) {
                this.rocks[i].positionY++;
            }
        }      
    },
    checkForExistingRocks: function () {
        var isRocksInTheField = _.some(this.rocks, function (rock) {
            return rock.positionY < 155;
        });

        if (!isRocksInTheField) {
            this.changeLevel();
        }
    },
    //Collisoins
    checkForCollisions: function () {
        var self = this;
        var isDeath = _.some(self.rocks, function (rock) {

            var playerPostionXLikeRange = _.range(self.player.positionX, self.player.positionX + self.player.width);
            var rockPostitionXLikeRange = _.range(rock.positionX, rock.positionX + rock.width);
            var isPlayerPositionXEqualToRockPositionX = _.some(rockPostitionXLikeRange, function (xPostion) {
                return _.contains(playerPostionXLikeRange, xPostion);
            });

            var playerPostionYLikeRange = _.range(self.player.positionY, self.player.positionY + self.player.height);
            var rockPostitionYLikeRange = _.range(rock.positionY, rock.positionY + (rock.height-5));
            var isPlayerPositionYEqualToRockPositionY = _.some(rockPostitionYLikeRange, function (yPostion) {
                return _.contains(playerPostionYLikeRange, yPostion);
            });

            return isPlayerPositionXEqualToRockPositionX && isPlayerPositionYEqualToRockPositionY;
        });
        if (isDeath) {
            
            clearInterval(self.gameInterval);
            this.loseGame();
        }
    },
    //Game logic
    changeLevel: function () {
        this.level++;
        this.createRocks();
        this.speed -= 2;
        clearInterval(this.gameInterval);
        this.playGame();
    },
    checkIfWin:function () {
        var isGameFinished = this.level >= 10;
        if (isGameFinished) {
            clearInterval(this.gameInterval);
            this.isGameRunning = false;
            this.winGame();
        }
    },
    winGame: function () {
        var canvas = $("#gameCanvas");
        var ctx = canvas[0].getContext("2d");

        var gradient = ctx.createLinearGradient(30, 20, 50, 0);
        gradient.addColorStop("0", "magenta");
        gradient.addColorStop("0.5", "blue");
        gradient.addColorStop("1.0", "red");

        ctx.fillStyle = gradient;
        ctx.font = "20px Georgia";
        ctx.fillText("You Win", 100, 110);

        canvas.css("background-image", "url('imgs/trophy_gold.ico')")
            .css("background-position", "150px 150px");
        
    },
    loseGame:function () {
        var canvas = $("#gameCanvas");
        var ctx = canvas[0].getContext("2d");

        ctx.fillStyle = "red";
        ctx.font = "30px Georgia";
        ctx.fillText("OSER", 150, 110);

        canvas.css("background-image", "url('imgs/Looser.png')")
            .css("background-position", "0 100px");
    },
    playGame: function () {
        var self = this;
        this.createRocks();
        this.gameInterval = setInterval(function () {
            self.drawInCanvas();
            self.moveRocks();
            self.checkForCollisions();
            self.checkForExistingRocks();
            self.checkIfWin();
        }, this.speed);
    }

})