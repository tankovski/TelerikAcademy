using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JpegCounterWithDataBase
{
    public partial class JpegCounterWithDataBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new UsersCountEntities();
            using (context)
            {


                Application.Lock();
                if (Application["UsersDb"] == null)
                {
                    Application["UsersDb"] = 0;
                    var users = context.Users;
                    context.Users.RemoveRange(users);
                    context.SaveChanges();
                    
                }
                else
                {
                    context.Users.Add(new User());
                    context.SaveChanges();
                }
                Application.UnLock();


                Response.Clear();

                Bitmap generatedImage = new Bitmap(200, 200);
                using (generatedImage)
                {
                    Graphics gr = Graphics.FromImage(generatedImage);
                    using (gr)
                    {
                        // Create string to draw.
                        string num = context.Users.Count().ToString();

                        gr.FillRectangle(Brushes.MediumSeaGreen, 0, 0, 200, 200);

                        // Create font and brush.
                        Font drawFont = new Font("Arial", 24);
                        SolidBrush drawBrush = new SolidBrush(Color.Blue);

                        // Create point for upper-left corner of drawing.
                        PointF drawPoint = new PointF(80.0F, 80.0F);

                        gr.DrawString(num, drawFont, drawBrush, drawPoint);

                        Response.ContentType = "image/gif";

                        //Response.AppendHeader("Content-Disposition",
                        //    "attachment; filename=\"Financial-Report-April-2013.JPEG\"");

                        generatedImage.Save(Response.OutputStream, ImageFormat.Jpeg);

                    }
                }
            }
        }
    }
}