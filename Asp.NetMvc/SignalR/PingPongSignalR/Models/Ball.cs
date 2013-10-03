using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingPongSignalR.Models
{
    public class Ball
    {
        private int directionTop = 1;
        private int directionLeft = 1;
        public bool ballOutOfField =false;
        public int Radius { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }

        public Ball(int radius, int top, int left)
        {
            this.Radius = radius;
            this.Left = left;
            this.Top = top;
        }

        public void MoveBall(Paddle playerOne, Paddle playerTwo)
        {


            Top += directionTop;
            Left += directionLeft;
            if (Top <= 1)
            {
                directionTop *= -1;
            }
            if (Left >= playerTwo.Left && Top >= playerTwo.Top && Top <= playerTwo.Top + playerTwo.Height)
            {
                directionLeft *= -1;
            }
            if (Top >= 399)
            {
                directionTop *= -1;
            }
            if (Left <= playerOne.Left + playerOne.Width && Top >= playerOne.Top && Top <= playerOne.Top + playerTwo.Height)
            {
                directionLeft *= -1;
            }
            if (Left == 499 || Left==1)
            {
                directionLeft = 0;
                directionTop = 0;

                ballOutOfField = true;
            }
        }
    }
}