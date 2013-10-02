using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PWUrlRedirect
{
    public partial class PWUrlRedirect : System.Web.UI.UserControl
    {
        public string URL { get; set; }
        public string Is301Redirect { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(URL))
            {
                string urlReformat = URL;

				if (!URL.StartsWith("http://") && !URL.StartsWith("https://"))
                {
                    urlReformat = String.Format("~{0}", URL);
                }

                bool permRedirect = false;
                if (Boolean.TryParse( Is301Redirect, out permRedirect ) )
                {
                    if (permRedirect)
                    {
                        Response.StatusCode = 301;
                        Response.StatusDescription = "Moved Permanently";
                        Response.RedirectLocation = urlReformat;
                        Response.End();
                    }
                    else
                    {
                        Response.Redirect(urlReformat);
                    }
                }
                else
                {
                    Response.Redirect(urlReformat);
                }
            }
        }
    }
}