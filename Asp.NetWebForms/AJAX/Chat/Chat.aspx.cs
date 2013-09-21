using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chat
{
    public partial class Chat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var currentUser = ViewState["username"];
            if (currentUser != null)
            {
                this.NewMassageUserTb.Text = currentUser.ToString();
            }

            var context = new ChatContext();

            var messages = context.Messages.OrderBy(m=>m.TimeOfCreation).Take(100);

            this.AllMassageslistView.DataSource = messages.ToList();
            this.AllMassageslistView.DataBind();

        }

   
        protected void SendMsgBtn_Click(object sender, EventArgs e)
        {
            string msgText = this.NewMassageTextTb.Text;
            string user = this.NewMassageUserTb.Text;
            ViewState["username"] = user;

            var context = new ChatContext();

            Message message = new Message()
            {
                Text = msgText,
                Username = user,
                TimeOfCreation = DateTime.Now
            };

            context.Messages.Add(message);
            this.AllMassageslistView.DataBind();
            this.NewMassageTextTb.Text = "";
            this.NewMassageUserTb.Text = user;
            context.SaveChanges();
        }
    }
}