using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarsStore
{
    public partial class CarsStore : System.Web.UI.Page
    {
       private int index =  0;
       private List<Producer> cars = new List<Producer>
            {
                   new Producer()
                   {
                       Name="Toyota",
                       Models={"Yaris","Avensis","Rav-4","LandCruiser"}
                   },
                   new Producer()
                   {
                       Name="Mercedess",
                       Models={"E-Class","C-Class","S-Class","A-Class","B-Class"}
                   },
                   new Producer()
                   {
                       Name="Reno",
                       Models={"Megan","Twingo","Clio","Laguna"}
                   }
            };

       private List<Extra> extras = new List<Extra> 
        {
            new Extra("GPS"),new Extra("ABS"),new Extra("AFL"),new Extra("Parktronic")
        };

       private string[] engines = new[] { "disel", "gasoline" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
           

            this.ProducersDropDown.DataSource = cars;
            this.ExtrasCheckBoxList.DataSource = extras;
            this.ModelsDropDown.DataSource = cars[index].Models;
            this.EnginesRadioButtons.DataSource = engines;
            Page.DataBind();
           
        }

        protected void ProducersDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {   
        
            this.index = this.ProducersDropDown.SelectedIndex;
            this.ModelsDropDown.DataSource = cars[index].Models;
            this.ModelsDropDown.DataBind();

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.ProducersDropDown.SelectedItem.Text + "<br/>");
            sb.Append(this.ModelsDropDown.SelectedItem.Text + "<br/>");
            for (int i = 0; i < this.ExtrasCheckBoxList.Items.Count; i++)
            {
                if (this.ExtrasCheckBoxList.Items[i].Selected==true)
                {
                    sb.Append(this.ExtrasCheckBoxList.Items[i].Text + ";");
                }
            }
            sb.Append("<br/>");
            sb.Append(this.EnginesRadioButtons.SelectedItem.Text);

            this.ResultLabel.Text = sb.ToString();
        }
    }
}