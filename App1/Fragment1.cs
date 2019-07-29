using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace App1
{
    public class Fragment1 : Fragment
    {


        //string[] movieArray = { "A-Moive", "B-Moive",
         //       "C-Moive", "D-Moive", "E-Moive", "F - Moive", "G  - Moive", "H  - Moive", "I  - Moive"};

        SearchView mySearch;

        List<UserObject> myUsersList;
        public String myName;
        public Activity myContext;
        ArrayAdapter myAdapter;


        public Fragment1(string name,List<UserObject> templist, Activity context)
        {
            myName = name;
            myUsersList = templist;
            myContext = context;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.FirstTapLayout,
                container, false);
            ListView myList = myView.FindViewById<ListView>(Resource.Id.listID);
            myView.FindViewById<TextView>(Resource.Id.myNameIdl).Text = myName;

           
            MyCustomAdapter myAdapter = new MyCustomAdapter(myContext, myUsersList);

            myList.Adapter = myAdapter;
            myList.ItemClick += myIteamClickMethod;

            return myView;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
        public void mySearchMethod(object sender, SearchView.QueryTextChangeEventArgs e)
        {

            var mySearchValue = e.NewText;
            System.Console.WriteLine("Search Text is :  is \n\n " + mySearchValue);



        }

        public void myIteamClickMethod(object sender, AdapterView.ItemClickEventArgs e)
        {
            System.Console.WriteLine("I am clicking on the list item \n\n");
            var indexValue = e.Position;
           
            Intent intent = new Intent(this.Activity, typeof(iteminfo));
            intent.PutExtra("item_id", indexValue);
            StartActivity(intent);
            //var myValue = movieArray[indexValue];
            // System.Console.WriteLine("Value is \n\n " + myValue);
        }

        










    }
}