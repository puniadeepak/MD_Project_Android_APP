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
    [Activity(Label = "foodlist")]
    public class foodlist : Activity
    {
        List<UserObject> myUsersList2 = new List<UserObject>();
        List<UserObject> mysnackList2 = new List<UserObject>();


        Fragment[] _fragmentsArray;
        string name = "Welcome To my App";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Set our view from the "main" layout resource
            RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
            //enable navigation mode to support tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.foodlist);
            //adding items to drink list
            myUsersList2.Add(new UserObject("Coffee", "1.99", Resource.Drawable.drink1));
            myUsersList2.Add(new UserObject("Dark Roast", "2.99", Resource.Drawable.drink2));
            myUsersList2.Add(new UserObject("Lemonade", "2.99", Resource.Drawable.drink3));
            myUsersList2.Add(new UserObject("Choco Chips", "2.00", Resource.Drawable.drink4));

            //adding items to SANACK list
            mysnackList2.Add(new UserObject("Bagel", "1.99", Resource.Drawable.snack1));
            mysnackList2.Add(new UserObject("Sandwich", "2.99", Resource.Drawable.snack2));
            mysnackList2.Add(new UserObject("Egg Wrap", "2.99", Resource.Drawable.snack3));
            mysnackList2.Add(new UserObject("Chicken Wrap", "2.00", Resource.Drawable.snack4));

            _fragmentsArray = new Fragment[]
            {
            new Fragment1( "Mike",myUsersList2, this),
            new SecondFragment("secondlist",mysnackList2, this ),
            
            };


            AddTabToActionBar("Drinks"); //First Tab
            AddTabToActionBar("Snaks"); //Second Tab
            

        }


        void AddTabToActionBar(string tabTitle)
        {
            Android.App.ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText(tabTitle);

            tab.SetIcon(Android.Resource.Drawable.IcInputAdd);

            tab.TabSelected += TabOnTabSelected;

            ActionBar.AddTab(tab);
        }



        void TabOnTabSelected(object sender, Android.App.ActionBar.TabEventArgs
            tabEventArgs)
        {
            Android.App.ActionBar.Tab tab = (Android.App.ActionBar.Tab)sender;

            //Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Fragment frag = _fragmentsArray[tab.Position];

            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }



    }
}
        