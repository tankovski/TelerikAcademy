using Microsoft.AspNet.SignalR;
using PingPongSignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingPongSignalR.Hubs
{
    public class Game:Hub
    {
        private static List<string> players = new List<string>();
        private static bool gameStarted = false;
        private static Paddle firstPlayer = new Paddle(10, 150, 10, 100);
        private static Paddle secondPlayer = new Paddle(490, 150, 10, 100);
        private static Ball ball = new Ball(10, 200, 250);

        public Game()
        {
           
        }

        //Move Down
        public void MovePlayerDown()
        {
            if (players[0] == Context.ConnectionId)
            {
                this.MovePlayerOneDown();

            }
            else if (players[1] == Context.ConnectionId)
            {
                this.MovePlayerTwoDown();
            }
        }

        private void MovePlayerTwoDown()
        {
            if (secondPlayer.Top < 400 - firstPlayer.Height)
            {
                secondPlayer.Top += 10;
            }
        }

        private void MovePlayerOneDown()
        {
            if (firstPlayer.Top<400-firstPlayer.Height)
            {
                firstPlayer.Top += 10;
            }
        }

        //Move Up
        public void MovePlayerUp()
        {
            if (players[0] == Context.ConnectionId)
            {
                this.MovePlayerOneUp();

            }
            else if (players[1] == Context.ConnectionId)
            {
                this.MovePlayerTwoUp();
            }
            
        }

        private void MovePlayerTwoUp()
        {
            if (secondPlayer.Top > 0)
            {
                secondPlayer.Top -= 10;
            }
        }

        private void MovePlayerOneUp()
        {
            if (firstPlayer.Top>0)
            {
                firstPlayer.Top -= 10;
            }      
        }

        

        public void JoinGame()
        {
            string msg = "msg";

            if (!players.Contains(Context.ConnectionId) && players.Count<=2)
            {
                players.Add(Context.ConnectionId);
                if (players.Count == 2)
                {
                    gameStarted = true;
                    msg= "Second player joined the game";
                }
                else
                {
                    msg = "First player joined the game.";
                }

               
            }
            else if (players.Contains(Context.ConnectionId))
            {
                msg = "You already joined the game";
            }
            else
            {
                msg = "The game is full";
            }

            Clients.All.joinGameMsg(msg);
        }

        public void CheckIsGameStarted()
        {
            if (gameStarted)
            {
                Clients.All.startGame();
  
            }
        }

        public void DrawningGame()
        {
            if (ball.ballOutOfField)
            {
                this.EndGame();
            }
            else
            {
                ball.MoveBall(firstPlayer, secondPlayer);
                Clients.All.drawInCanvas(firstPlayer, secondPlayer, ball);   
            }
           
        }

        private void EndGame()
        {
            Clients.All.endGame();
        }

    }
}