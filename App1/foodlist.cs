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
            //adding items to list
            myUsersList2.Add(new UserObject("Mike", "21", Resource.Drawable.pin));
            myUsersList2.Add(new UserObject("Mike2", "23", Resource.Drawable.pin));
            myUsersList2.Add(new UserObject("Mike2", "24", Resource.Drawable.pin));
            myUsersList2.Add(new UserObject("Mike2", "25", Resource.Drawable.pin));

            _fragmentsArray = new Fragment[]
            {
            new Fragment1( "Mike",myUsersList2, this),
            new SecondFragment(),
            
            };


            AddTabToActionBar("Snack"); //First Tab
            AddTabToActionBar("Drink"); //Second Tab
            

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
        