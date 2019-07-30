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
        TextView itemDetails, itemPrice;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Create your application here
            SetContentView(Resource.Layout.iteminfo);
            itemid = Intent.GetIntExtra("item_id",0);
            Console.WriteLine("item id: " + itemid);
            itemDetails = FindViewById<TextView>(Resource.Id.t1);
            itemPrice = FindViewById<TextView>(Resource.Id.t2);
            if (itemid == 0)
            {
                itemDetails.Text = "A medium roast blend, expertly roasted with care to deliver a perfect balance and the unique Tim Hortons taste that has made it Canada's Favourite Coffee.";

            }
            else if (itemid == 1)
            {
                itemDetails.Text = "Our premium 100% Arabica beans are roasted to deliver a darker, richer and smooth flavour that all dark roast coffee lovers can enjoy.";
            }
            else if (itemid == 2)
            {
                itemDetails.Text = "";
            }
            else if (itemid == 3)
            {

            }
            else if (itemid == 4)
            {

            }
            else if (itemid == 5)
            {
                itemDetails.Text = "This is what “good morning” tastes like. Your choice of sausage, three pieces of crisp bacon, seasoned egg omelette and processed cheese on a Homestyle Biscuit, English Muffin or toasted Bagel. Not a meat lover? Hold the sausage, or bacon. ";


            }
            else if (itemid == 6)
            {

            }
            else if (itemid == 7)
            {

            }
            else if (itemid == 8)
            {

            }

        }
    }
}