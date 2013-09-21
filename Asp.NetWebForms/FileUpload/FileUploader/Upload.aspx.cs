using FileUploader.Models;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FileUploader
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
            try
            {
                HttpPostedFile file = Request.Files["uploaded"];


                string ftype = file.ContentType;

                if (file.ContentType == "application/octet-stream")
                {
                    ZipFile zipFile = ZipFile.Read(file.InputStream);
                    var context = new TextFilesFromZipEntities();

                    foreach (var item in zipFile.Entries)
                    {
                        int extensionStartIndex = item.FileName.LastIndexOf('.');
                        if (extensionStartIndex!=-1)
                        {
                            string type = item.FileName.Substring(extensionStartIndex);
                            if (type==".txt")
                            {
                                MemoryStream memoryStream = new MemoryStream();
                                item.Extract(memoryStream);
                                memoryStream.Position = 0;
                                StreamReader reader = new StreamReader(memoryStream);
                                string fileContent = reader.ReadToEnd().ToString();
                                reader.Close();

                                TextFile zipTextFile = new TextFile()
                                {
                                    FileName=item.FileName,
                                    FileContent=fileContent
                                };

                                context.TextFiles.Add(zipTextFile);
                            }
                        }
                       
                    }
                    context.SaveChanges();
                    Response.Write("{}");
                }
                else
                {
                    Response.Write("The file is not in rar format!");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}