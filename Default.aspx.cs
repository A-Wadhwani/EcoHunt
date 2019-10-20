﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcoHunt
{
    public partial class _Default : Page
    {
        private string pathFile = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Cookies.ReadCookie(this.Request, this.Response);

            if (String.IsNullOrWhiteSpace(userName))
                Response.Redirect("LoginPage.aspx");
            //Database.FirebaseDatabase.AddPicture("First Test");
            //var allNames = Database.FirebaseDatabase.GetAllPictureNames();
            //Database.FirebaseDatabase.DeletePicture("First Test");

            //string url = Database.FirebaseCloudStorage.AddPhotoToStorage(MapPath(@"~\milky-way.jpg"));
            //bool succeeded = Database.FirebaseCloudStorage.DeletePhotoFromStorage("milky-way.jpg");

            //ThreadStart ts = new ThreadStart(SendThingToTransfer);
            //Thread t = new Thread(ts);
            //t.Start();

            //Database.FirebaseDatabase.AddUrlsToPicturesWithoutUrls();
            //Database.FirebaseDatabase.TransferNameToGarbageFoundCategory("milky-way");
            //Database.FirebaseUsers.CreateUser("Kade0", "abc");
            //Database.FirebaseUsers.AddBrandNewGroupToUser("Kade0");
            //Database.FirebaseUsers.AddGroupToUser("Kade1", "h2e51mc5");
            //Database.FirebaseCloudStorage.AddPhotoToStorage(MapPath("ImageNames.txt"));
            //bool isGarbage = GetGarbage.CheckGarbage("https://firebasestorage.googleapis.com/v0/b/ecomake-de93b.appspot.com/o/Pictures%2Fmilky-way.jpg?alt=media&token=9fa46c36-1364-4b9d-bd7c-d3734b275525");
            //var allPicturesWithGarbage = Database.FirebaseDatabase.GetAllPictureWithGarbageNames();
            //DisplayPics(allPicturesWithGarbage);
            //Database.FirebaseCloudStorage.ClearImageNameFile(MapPath("ImageNames.txt"));
            //string url = "https://firebasestorage.googleapis.com/v0/b/ecomake-de93b.appspot.com/o/Pictures%2FImageNames.txt?alt=media&token=15e491e9-5014-462d-ae48-a504f62e4edb";
            //string result = Database.FirebaseCloudStorage.GetImageNames(url);

            pathFile = MapPath("ImageNames.txt");

            ThreadStart ts = new ThreadStart(CheckingClock);
            Thread t = new Thread(ts);
            t.Start();

            DisplayPics(Database.FirebaseDatabase.GetAllPictureNames());
        }
        private void CheckingClock()
        {
            while (true)
            {
                Thread.Sleep(30000);
                Database.FirebaseCloudStorage.CheckForNewFiles(pathFile);
            }
        }
        private void DisplayPics(Database.NamesValues[] pictures)
        {
            if (pictures == null || pictures.Length == 0)
                return;

            for (int x = 0; x < pictures.Length; x++)
            {
                string url = pictures[x].url;
                if (!String.IsNullOrWhiteSpace(pictures[x].url))
                {
                    try
                    {
                        WebClient wc = new WebClient();
                        wc.DownloadString(url);

                        StringBuilder text = new StringBuilder();
                        string currentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                        string redirectUrl = currentUrl.Replace("Default", "SuccessfulDeletion.aspx?image=" + url);

                        text.Append("<div class=\"card\">");
                        text.Append("<div class=\"card bg-primary text-white\">");
                        text.Append("<b>" + "Picture" + "</b>");
                        text.Append("</div>");

                        text.Append("<div class=\"card-body\">");
                        text.Append("<a href=\"" + url + "\" >");
                        text.Append("<img width=\"100%\" src=\"" + url + "\" />");
                        text.Append("</a>");

                        //text.Append("<form action=\"" + redirectUrl + ">");
                        //    text.Append("<input type=\"submit\" value=\"Claim Points\"/>");
                        //text.Append("</form>");
                        text.Append("<a href='" + redirectUrl + "'>Claim Points</a>");
                        //text.Append("<button onclick=\"window.location.href='" + "http://google.com" + "'; \">Claim Points</button>");
                        text.Append("</div>");
                        text.AppendLine("</div>");


                        text.AppendLine("<br />");

                        imgList.Text += text.ToString();
                    }
                    catch
                    {
                    }
                }
            }
        }
        private void SendThingToTransfer()
        {
            Thread.Sleep(2000);
            Database.FirebaseDatabase.TransferNameToGarbageFoundCategory("Planet");
        }
    }
}