using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;

namespace HahaFrame.Web.App_Start
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //var twittersocialData = new Dictionary<string, object>();
            //twittersocialData.Add("Icon", "Twitter.png");
            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "",
            //    displayName: "Twitter",
            //    extraData: twittersocialData);
            
            //var facebooksocialData = new Dictionary<string, object>();
            //facebooksocialData.Add("Icon", "images/loginfb.png");
            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "",
            //    displayName: "Facebook",
            //    extraData: facebooksocialData);
            
            
            //var googlesocialData = new Dictionary<string, object>();
            //googlesocialData.Add("Icon", "images/logingp.png");
            //OAuthWebSecurity.RegisterGoogleClient("Google", googlesocialData);
        }
    }
}