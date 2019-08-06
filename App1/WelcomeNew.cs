using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    [Activity(Label = "Welcome to Tim Hortons")]
    public class WelcomeNew : Activity
    {

        String valueFromLoginUser;
        String passwordFromLogin;
        EditText name, email, age, password;
        TextView greeting;
        Button editBtn, deleteBtn;
        DBHelperclass dbcn;
        Android.App.AlertDialog.Builder alert;
        ListView myList;
        SearchView mySearch;
        List<string> locnArray = new List<string>(){ "ALocation", "BLocation",
                "CLocation", "DLocation"};
        List<string> locnArray2 = new List<string>(){ "ALocation", "BLocation",
                "CLocation", "DLocation"};
        
        ArrayAdapter myAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.welcomeLayout);
            // Create your application here

            valueFromLoginUser = Intent.GetStringExtra("usernameLogin");
            passwordFromLogin = Intent.GetStringExtra("passwordLogin");
            name = FindViewById<EditText>(Resource.Id.display_name);
            email = FindViewById<EditText>(Resource.Id.display_email);
            age = FindViewById<EditText>(Resource.Id.display_age);
            password = FindViewById<EditText>(Resource.Id.display_password);
            editBtn = FindViewById<Button>(Resource.Id.editBtn);
            deleteBtn = FindViewById<Button>(Resource.Id.DeleteBtn);
            alert = new Android.App.AlertDialog.Builder(this);
            myList = FindViewById<ListView>(Resource.Id.myListView);
            greeting = FindViewById<TextView>(Resource.Id.greetings);

            //assign value
            name.Text = valueFromLoginUser;
            greeting.Text = valueFromLoginUser.ToUpper() ;
            //Read Only
            name.Visibility = Android.Views.ViewStates.Gone;
            ICursor myresut1;
            /// ???
            dbcn = new DBHelperclass(this);
            dbcn.clearorderlist();
            myresut1 = dbcn.SelectUserdata(valueFromLoginUser, passwordFromLogin);

            myAdapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, locnArray);
            myList.Adapter = myAdapter;
            myList.ItemClick += myIteamClickMethod;

            mySearch = FindViewById<SearchView>(Resource.Id.searchID);
            //Search Events
            mySearch.QueryTextChange += mySearchMethod;

            var myId1 = 1; var nameValue1 = ""; var emailValue1 = ""; var ageValue1 = ""; var passValue1 = "";
            //get cursor values
            if (myresut1.Count > 0)
            {
                while (myresut1.MoveToNext())
                {

                    myId1 = myresut1.GetInt(myresut1.GetColumnIndexOrThrow("id"));
                    System.Console.WriteLine("ID from Database: " + myId1);


                    nameValue1 = myresut1.GetString(myresut1.GetColumnIndexOrThrow("names"));
                    System.Console.WriteLine("Name from Database: " + nameValue1);

                    emailValue1 = myresut1.GetString(myresut1.GetColumnIndexOrThrow("email"));
                    System.Console.WriteLine("Email from Database: " + emailValue1);

                    ageValue1 = myresut1.GetString(myresut1.GetColumnIndexOrThrow("age"));
                    System.Console.WriteLine("Age from Database: " + ageValue1);

                    passValue1 = myresut1.GetString(myresut1.GetColumnIndexOrThrow("password"));
                    System.Console.WriteLine("Password from Database: " + passValue1);


                }
                //assign value
                email.Text = emailValue1;
                //Read Only
                email.Visibility = Android.Views.ViewStates.Gone;
                //assign value
                age.Text = ageValue1;
                //Read Only
                age.Visibility = Android.Views.ViewStates.Gone;
                //assign value
                password.Text = passValue1;
                //Read Only
                password.Visibility = Android.Views.ViewStates.Gone;
                System.Console.WriteLine("Name from Login ---> " + valueFromLoginUser);
                System.Console.WriteLine("Pasword from Login ---> " + passwordFromLogin);


                editBtn.Click += editBtnClicEvent;
                deleteBtn.Click += editBtnClicEvent2;


            }
            else
            {
                Console.WriteLine("User doesnt exitst!");
                alert.SetTitle("Error");

                alert.SetMessage("USER DOESN'T EXIST");

                alert.SetPositiveButton("OK", alertOKButton);

                alert.SetNegativeButton("Cancel", alertOKButton);

                Dialog myDialog = alert.Create();

                myDialog.Show();

                Intent newScreen1 = new Intent(this, typeof(MainActivity));
                StartActivity(newScreen1);
            }


           
        }


        public void editBtnClicEvent(object sender, EventArgs e)
        {


            name.Visibility = Android.Views.ViewStates.Visible;
            email.Visibility = Android.Views.ViewStates.Visible;
            age.Visibility = Android.Views.ViewStates.Visible;
            password.Visibility = Android.Views.ViewStates.Visible;
            editBtn.Text = "Save Details";
            string namevalue = name.Text;
            string emailvalue = email.Text;
            string agevalue = age.Text;
            string passwordvalue = password.Text;
            dbcn.UpdateUserdata(namevalue, emailvalue, agevalue, passwordvalue, valueFromLoginUser, passwordFromLogin);
            dbcn.SelectMydata();
            editBtn.Click += delegate
                {
                    Console.WriteLine("UPDATED SUCCESSFULLY");
                    alert.SetTitle("Updated");

                    alert.SetMessage("Details updated");

                    alert.SetPositiveButton("OK", alertOKButton);

                    alert.SetNegativeButton("Cancel", alertOKButton);

                    Dialog myDialog = alert.Create();

                    myDialog.Show();

                    name.Visibility = Android.Views.ViewStates.Gone;
                    email.Visibility = Android.Views.ViewStates.Gone;
                    age.Visibility = Android.Views.ViewStates.Gone;
                    password.Visibility = Android.Views.ViewStates.Gone;
                    
                    editBtn.Text = "Details Updated";
                    editBtn.Enabled = false;
                };
        }

        public void editBtnClicEvent2(object sender, EventArgs e)
        {

            
            dbcn.DeleteUserdata(valueFromLoginUser, passwordFromLogin);

            Console.WriteLine("Deleted SUCCESSFULLY");
            alert.SetTitle("Deleted");

            alert.SetMessage("Your account has been deleted.");

            alert.SetPositiveButton("OK", alertOKButton);

            alert.SetNegativeButton("Cancel", alertOKButton);

            Dialog myDialog = alert.Create();

            myDialog.Show();
            Intent newScreen1 = new Intent(this, typeof(MainActivity));
            StartActivity(newScreen1);

        }

        public void alertOKButton(object sender, Android.Content.DialogClickEventArgs e)

        {

            System.Console.WriteLine("OK Button Pressed");

        }

        public void mySearchMethod(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            locnArray2.Clear();
            var mySearchValue = e.NewText;
            System.Console.WriteLine("Search Text is :  is \n\n " + mySearchValue);

            foreach (string item in locnArray)
            {
                if (item.ToLower().Contains(mySearchValue.ToLower()))
                {
                    locnArray2.Add(item);
                    System.Console.WriteLine("Match: " + item);
                }
            }

            myAdapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, locnArray2);
            myList.Adapter = myAdapter;
        }

        public void myIteamClickMethod(object sender, AdapterView.ItemClickEventArgs e)
        {
            System.Console.WriteLine("I am clicking on the list item \n\n");
            var indexValue = e.Position;
            var myValue = locnArray2[indexValue];
            System.Console.WriteLine("Value is \n\n " + myValue);
            Intent newScreen = new Intent(this, typeof(foodlist));



            StartActivity(newScreen);

        }

    }


}