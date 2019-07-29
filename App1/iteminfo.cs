using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    [Activity(Label = "iteminfo")]
    public class iteminfo : Activity
    {
        int itemid;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Create your application here
            SetContentView(Resource.Layout.iteminfo);
            itemid = Intent.GetIntExtra("item_id",0);
            Console.WriteLine("item id: " + itemid);
        }
    }
}