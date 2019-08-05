using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace App1
{
    [Activity(Label = "nomoney")]
    public class nomoney : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.nomoney);

            string strUrl = "https://youtube.com/embed/C31hcftHBIk";

            string html = @"<html><body><div align=""center""><iframe width=""550"" height=""450"" src=""strUrl""></iframe></div></body></html>";
            var myWebView = (WebView)FindViewById(Resource.Id.videoView1);
            var settings = myWebView.Settings;
            settings.JavaScriptEnabled = true;
            settings.UseWideViewPort = true;
            settings.LoadWithOverviewMode = true;
            settings.JavaScriptCanOpenWindowsAutomatically = true;
            settings.DomStorageEnabled = true;
            settings.SetRenderPriority(WebSettings.RenderPriority.High);
            settings.BuiltInZoomControls = false;

            settings.JavaScriptCanOpenWindowsAutomatically = true;
            myWebView.SetWebChromeClient(new WebChromeClient());
            settings.AllowFileAccess = true;
            settings.SetPluginState(WebSettings.PluginState.On);
            string strYouTubeURL = html.Replace("strUrl", strUrl);

            myWebView.LoadDataWithBaseURL(null, strYouTubeURL, "text/html", "UTF-8", null);


        }

    }
}