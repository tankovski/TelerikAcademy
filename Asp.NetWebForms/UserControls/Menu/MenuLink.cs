using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace Menu
{
    public class MenuLink
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public Color FontColor { get; set; }

        public MenuLink(string name, string url)
        {
            this.Name = name;
            this.Url = url;
            this.FontColor = Color.Blue;

        }
    }
}