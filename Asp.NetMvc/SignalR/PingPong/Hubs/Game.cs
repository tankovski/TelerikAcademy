using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingPong.Hubs
{
    public class Game:Hub
    {
        private List<string> players;
        public bool gameStarted { get; set; }

        public Game()
        {
            this.players = new List<string>();
            this.gameStarted = false;
        }

        public void JoinGame()
        {
            string msg = "msg";

            if (!this.players.Contains(Context.ConnectionId) && this.players.Count>2)
            {
                this.players.Add(Context.ConnectionId);
                if (this.players.Count == 2)
                {
                    this.StartGame();
                    msg= "Game started";
                }

                msg = "You joined the game, and you are player " + this.players.Count;
            }
            else if (this.players.Contains(Context.ConnectionId))
            {
                msg = "You already joined the game";
            }
            else
            {
                msg = "The game is full";
            }

            Clients.All().joinGameMsg(msg);
        }

        public void StartGame()
        {
            this.gameStarted = true;
        }
    }
}