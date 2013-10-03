using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingPongSignalR.Models
{
    public class Paddle
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Paddle(int left, int top, int width, int height)
        {
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
        }
    }
}