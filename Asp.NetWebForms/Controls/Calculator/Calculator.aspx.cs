using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        private static long firstNum = 0;
        private static long secondNum = 0;
        private static string operation = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            firstNum = 0;
            secondNum = 0;
            operation = "";
            this.resultTb.Text = "";
        }

        protected void Number_Click(object sender, CommandEventArgs e)
        {
            try
            {
                this.resultTb.Text += e.CommandName;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Operation_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "root")
            {
                firstNum = long.Parse(this.resultTb.Text);
                this.resultTb.Text = Math.Sqrt(firstNum).ToString();
            }
            else
            {
                firstNum = long.Parse(this.resultTb.Text);
                operation = e.CommandName;
                this.resultTb.Text = "";
            }
        }


        protected void Result_Click(object sender, EventArgs e)
        {
            long result = 0;
            secondNum = long.Parse(this.resultTb.Text);
            switch (operation)
            {
                case "+":
                    {
                        result = firstNum + secondNum;
                    } break;
                case "-":
                    {
                        result = firstNum - secondNum;
                    } break;
                case "x":
                    {
                        result = firstNum * secondNum;
                    } break;
                case "/":
                    {
                        result = firstNum / secondNum;
                    } break;
            }

            this.resultTb.Text = result.ToString();
        }

    }
}