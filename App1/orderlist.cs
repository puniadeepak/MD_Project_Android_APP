using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    [Activity(Label = "Your order")]
    
    public class orderlist : Activity
    {
        ListView listView;
        SearchView mySearch;
        TextView totalprice, removed_msg;
        List<UserObject> myUsersList3 = new List<UserObject>();


        /*string[] movieArray = { "A-Moive", "B-Moive",
                 "C-Moive", "D-Moive", "E-Moive", "F - Moive", "G  - Moive", "H  - Moive", "I  - Moive"};
                 */


        ArrayAdapter myAdapter;
        DBHelperclass myDB;
        ICursor myresut3;

        //spinner
        Spinner spinnerView;
        string[] myCategory = { "Select Payment Method","Credit Card", "Debit Card", "Cash" , "I Don't Have Money" };

        protected override void OnCreate(Bundle savedInstanceState)
        {


            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.orderlist);
            listView = FindViewById<ListView>(Resource.Id.myListView3);
            totalprice = FindViewById<TextView>(Resource.Id.price1);
            removed_msg = FindViewById<TextView>(Resource.Id.removed);
            removed_msg.Visibility = Android.Views.ViewStates.Gone;
            //get orderlist data from database
            myDB = new DBHelperclass(this);
            myresut3= myDB.orderList();
            var myId1 = 1; var nameValue1 = ""; var emailValue1 = ""; var ageValue1 = ""; var passValue1 = "";
            float price=0;
            //get cursor values
            if (myresut3.Count > 0)
            {
                while (myresut3.MoveToNext())
                {

                    myId1 = myresut3.GetInt(myresut3.GetColumnIndexOrThrow("id"));
                    System.Console.WriteLine("ID from Database: " + myId1);


                    nameValue1 = myresut3.GetString(myresut3.GetColumnIndexOrThrow("names"));
                    System.Console.WriteLine("Name from Database: " + nameValue1);

                    emailValue1 = myresut3.GetString(myresut3.GetColumnIndexOrThrow("email"));
                    System.Console.WriteLine("Email from Database: " + emailValue1);

                    ageValue1 = myresut3.GetString(myresut3.GetColumnIndexOrThrow("age"));
                    System.Console.WriteLine("Age from Database: " + ageValue1);

                    passValue1 = myresut3.GetString(myresut3.GetColumnIndexOrThrow("password"));
                    System.Console.WriteLine("Password from Database: " + passValue1);

                    //adding data in userlist
                    myUsersList3.Add(new UserObject(nameValue1, ageValue1, myId1));

                    price += float.Parse(ageValue1);
                }
            }
            else
            {
                Console.WriteLine("There is data in order list!");
            }

                    


            MyCustomAdapter myAdapter = new MyCustomAdapter(this, myUsersList3);

            listView.Adapter = myAdapter;
            totalprice.Text = "$"+ price.ToString("0.00");
            listView.ItemClick += myIteamClickMethod;
            /*
            myAdapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, movieArray);
            myList.Adapter = myAdapter;
            myList.ItemClick += myIteamClickMethod;

            mySearch = FindViewById<SearchView>(Resource.Id.searchID);
            //Search Events
            mySearch.QueryTextChange += mySearchMethod;
            */

            //adding menu in orderlist
            spinnerView = FindViewById<Spinner>(Resource.Id.spinner1);

            spinnerView.Adapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, myCategory);


            spinnerView.ItemSelected += MyItemSelectedMethod;

        }
        



        void MyItemSelectedMethod(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var index = e.Position;

            var value = myCategory[index];
            System.Console.WriteLine("value is " + value);


            if (value.ToLower().Equals("Action"))
            {
                //create a veg array and create as a new adater 

            }

            if(value.Equals("I Don't Have Money"))
            {
                Intent newScreen1 = new Intent(this, typeof(nomoney));

                StartActivity(newScreen1);

            }
        }



    //menu code end here



    public void mySearchMethod(object sender, SearchView.QueryTextChangeEventArgs e)
        {

            var mySearchValue = e.NewText;
            System.Console.WriteLine("Search Text is :  is \n\n " + mySearchValue);



        }

        public void myIteamClickMethod(object sender, AdapterView.ItemClickEventArgs e)
        {
            System.Console.WriteLine("I am clicking on the list item \n\n");
            var indexValue = e.Position;
            //var myValue = movieArray[indexValue];
            // System.Console.WriteLine("Value is \n\n " + myValue);
            string name=myUsersList3[indexValue].name;
            myDB = new DBHelperclass(this);
            myDB.deleteitem(name);
            myUsersList3.RemoveAt(indexValue);
            float price=0;

            //calculating total price of items in list
            foreach (UserObject myObject in myUsersList3)
            {
                // Do something nifty here
                myDB.InsertValue(myObject.image, myObject.name, "0", myObject.age, "0");
                price += float.Parse(myObject.age);
            }
            totalprice.Text = "$"+price.ToString("0.00");
            
            MyCustomAdapter myAdapter = new MyCustomAdapter(this, myUsersList3);

            listView.Adapter = myAdapter;
            removed_msg.Visibility = Android.Views.ViewStates.Visible;
            

        }
    }
}