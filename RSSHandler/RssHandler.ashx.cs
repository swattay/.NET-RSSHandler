using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Xsl;
using System.Text;
using System.IO;

namespace RSSHandler
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class RssHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "application/x-javascript";

                if (!String.IsNullOrEmpty(context.Request.QueryString["feed"]))
                {
                    string feedUrl = context.Request.QueryString["feed"].ToString();
                    string xslPath = context.Server.MapPath("FeedFormatter.xsl");

                    XmlDocument feedXml = new XmlDocument();
                    feedXml.Load(feedUrl);

                    XslCompiledTransform feedFormat = new XslCompiledTransform();
                    feedFormat.Load(xslPath);

                    StringBuilder jsText = new StringBuilder();
                    StringWriter jsWriter = new StringWriter(jsText);

                    // Call the Transform method of the XslTransform object passing it
                    // our input via the XmlDocument and getting output via the StringWriter.
                    feedFormat.Transform(feedXml, null, jsWriter);

                    //context.Response.Write(@"document.write('<div><a href=\'" + feedUrl + @"\'>FEED HERE</a></div>');");
                    context.Response.Write(@"document.write('<div>" + MakeJava(jsText.ToString()) + @"</div>');");
                }
                else
                {
                    context.Response.Write(@"document.write('<div>FEED NOT AVAILABLE</div>')");
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(@"document.write('<div>FEED NOT AVAILABLE</div>')");
            }
        }

        private static string MakeJava(string strIn)
        {
            strIn = strIn.Replace("\r", "");
            strIn = strIn.Replace("\\", "\\\\");
            strIn = strIn.Replace("\'", "\\'");
            strIn = strIn.Replace("\r", "");
            strIn = strIn.Replace("\n", "\\n");
            strIn = strIn.Replace("\t", "\\t");
            strIn = strIn.Replace("<", "<'+'");
            return strIn;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
