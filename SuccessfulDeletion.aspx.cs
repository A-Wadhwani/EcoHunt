using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcoHunt
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Success.Visible = false;
            Redirect.Visible = false;
        }

        protected void SubmitChanges_ServerClick(object sender, EventArgs e)
        {
            
            String inpName = Cookies.ReadCookie(this.Request, this.Response);
            Database.FirebaseUsers.AddPoints(inpName, 10);
            Success.Visible = true;
            SubmitChanges.Visible = false;
            Redirect.Visible = true;
            String imageUrl = Request.QueryString["image"];
            string token = Request.QueryString["token"];

            string url = imageUrl + "&token=" + token;
            url = url.Replace("Pictures/", "Pictures%2F");
            var thingFromDb = Database.FirebaseDatabase.GetNameFromUrl(url);
            Database.FirebaseDatabase.DeletePicture(thingFromDb.ID);
            Database.FirebaseCloudStorage.DeletePhotoFromStorage(thingFromDb.name + ".jpg");
        }

        protected void Redirect_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Leaderboard.aspx");
        }
    }
}