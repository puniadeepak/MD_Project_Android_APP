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
    public class SecondFragment : Fragment
    {
        SearchView mySearch;

        List<UserObject> mysnackList;
        
        public Activity myContext;
        ArrayAdapter myAdapter;

        public SecondFragment(List<UserObject> templist, Activity context)
        {
            
            mysnackList = templist;
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
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.SecondTabLayout, container, false);

            ListView myList = myView.FindViewById<ListView>(Resource.Id.listID);
           


            MyCustomAdapter myAdapter = new MyCustomAdapter(myContext, mysnackList);

            myList.Adapter = myAdapter;
            myList.ItemClick += myIteamClickMethod;


            return myView;
            //return base.OnCreateView(inflater, container, savedInstanceState);

        }
        
        public void myIteamClickMethod(object sender, AdapterView.ItemClickEventArgs e)
        {
            System.Console.WriteLine("I am clicking on the list item \n\n");
            var indexValue = e.Position + 4;

            Intent intent = new Intent(this.Activity, typeof(iteminfo));
            intent.PutExtra("item_id", indexValue);
            StartActivity(intent);
            //var myValue = movieArray[indexValue];
            // System.Console.WriteLine("Value is \n\n " + myValue);
        }

    }
}