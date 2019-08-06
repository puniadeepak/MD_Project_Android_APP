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
    [Activity(Label = "Details")]
    public class iteminfo : Activity
    {
        int itemid;
        TextView itemDetails, itemPrice;
        ImageView itemimg;
        Button itemOrder, small, med, large, openorder;
        


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Create your application here
            SetContentView(Resource.Layout.iteminfo);
            itemid = Intent.GetIntExtra("item_id",0);
            Console.WriteLine("item id: " + itemid);
            itemDetails = FindViewById<TextView>(Resource.Id.t1);
            itemPrice = FindViewById<TextView>(Resource.Id.t2);
            itemimg = FindViewById<ImageView>(Resource.Id.image1);
            itemOrder = FindViewById<Button>(Resource.Id.add_button);
            openorder = FindViewById<Button>(Resource.Id.show_button);
            openorder.Visibility = Android.Views.ViewStates.Gone;
            small = FindViewById<Button>(Resource.Id.s);
            med = FindViewById<Button>(Resource.Id.m);
            large = FindViewById<Button>(Resource.Id.l);

            //creating database object to access database
            DBHelperclass myDB;
            myDB = new DBHelperclass(this);

            //select small size by default, and disable button
            small.Enabled = false;
            int size = 1;
            
            //initializing price variables for small size coffee
            Double p0 = 1.99, p1 = 2.99, p2 = 2.99, p3 = 2.00, p4 = 1.99, p5 = 2.99, p6 = 2.99, p7 = 2.00;

            /*
             * on clicking medium size button
             * disable medium button and enable rest of buttons,
             * change price accordingly
             * and setting itemprize on page
             */
            med.Click += delegate
            {
                small.Enabled = true;
                med.Enabled = false;
                large.Enabled = true;
                size = 2;
                p0 = 2.99; p1 = 3.99; p2 = 3.99; p3 = 3.00; p4 = 2.99; p5 = 3.99; p6 = 3.99; p7 = 3.00;

                if (itemid == 0)
                {
                    itemPrice.Text = "$"+p0.ToString();


                }
                else if (itemid == 1)
                {
                    itemPrice.Text = "$" + p1.ToString();

                }
                else if (itemid == 2)
                {
                    itemPrice.Text = "$" + p2.ToString();

                }
                else if (itemid == 3)
                {
                    itemPrice.Text = "$" + p3.ToString();

                }
                else if (itemid == 4)
                {
                    itemPrice.Text = "$" + p4.ToString();

                }
                else if (itemid == 5)
                {
                    itemPrice.Text = "$" + p5.ToString();


                }
                else if (itemid == 6)
                {
                    itemPrice.Text = "$" + p6.ToString();

                }
                else if (itemid == 7)
                {
                    itemPrice.Text = "$" + p7.ToString();

                }

            };
            small.Click += delegate
            {
                small.Enabled = false;
                med.Enabled = true;
                large.Enabled = true;
                size = 1;
                p0 = 1.99; p1 = 2.99; p2 = 2.99; p3 = 2.00; p4 = 1.99; p5 = 2.99; p6 = 2.99; p7 = 2.00;
                if (itemid == 0)
                {
                    itemPrice.Text = "$" + p0.ToString();


                }
                else if (itemid == 1)
                {
                    itemPrice.Text = "$" + p1.ToString();

                }
                else if (itemid == 2)
                {
                    itemPrice.Text = "$" + p2.ToString();

                }
                else if (itemid == 3)
                {
                    itemPrice.Text = "$" + p3.ToString();

                }
                else if (itemid == 4)
                {
                    itemPrice.Text = "$" + p4.ToString();

                }
                else if (itemid == 5)
                {
                    itemPrice.Text = "$" + p5.ToString();


                }
                else if (itemid == 6)
                {
                    itemPrice.Text = "$" + p6.ToString();

                }
                else if (itemid == 7)
                {
                    itemPrice.Text = "$" + p7.ToString();

                }
            };
            large.Click += delegate
            {
                small.Enabled = true;
                med.Enabled = true;
                large.Enabled = false;
                size = 3;
                p0 = 3.99; p1 = 4.99; p2 = 4.99; p3 = 4.00; p4 = 3.99; p5 = 4.99; p6 = 4.99; p7 = 4.00;

                if (itemid == 0)
                {
                    itemPrice.Text = "$" + p0.ToString();


                }
                else if (itemid == 1)
                {
                    itemPrice.Text = "$" + p1.ToString();

                }
                else if (itemid == 2)
                {
                    itemPrice.Text = "$" + p2.ToString();

                }
                else if (itemid == 3)
                {
                    itemPrice.Text = "$" + p3.ToString();

                }
                else if (itemid == 4)
                {
                    itemPrice.Text = "$" + p4.ToString();

                }
                else if (itemid == 5)
                {
                    itemPrice.Text = "$" + p5.ToString();


                }
                else if (itemid == 6)
                {
                    itemPrice.Text = "$" + p6.ToString();

                }
                else if (itemid == 7)
                {
                    itemPrice.Text = "$" + p7.ToString();

                }

            };

            //open order list
            openorder.Click += delegate
            {
                myDB.SelectMydata();

                //pass details or order to next page via database
                //SetContentView(Resource.Layout.activity_main);
                Intent newScreen = new Intent(this, typeof(orderlist));


                StartActivity(newScreen);
            };
            if (itemid == 0)
            {
                int resourceId = (int)typeof(Resource.Drawable).GetField("drink1").GetValue(null); //getting image id
                itemimg.SetImageResource(resourceId);
                itemDetails.Text = "A medium roast blend, expertly roasted with care to deliver a perfect balance and the unique Tim Hortons taste that has made it Canada's Favourite Coffee.";
                itemPrice.Text = "$" + p0.ToString();


            }
            else if (itemid == 1)
            {
                int resourceId = (int)typeof(Resource.Drawable).GetField("drink2").GetValue(null);
                itemimg.SetImageResource(resourceId);
                itemDetails.Text = "Our premium 100% Arabica beans are roasted to deliver a darker, richer and smooth flavour that all dark roast coffee lovers can enjoy.";
                itemPrice.Text = "$" + p1.ToString();

            }
            else if (itemid == 2)
            {
                int resourceId = (int)typeof(Resource.Drawable).GetField("drink3").GetValue(null);
                itemimg.SetImageResource(resourceId);
                itemDetails.Text = "A refreshing frozen drink blended with real lemon, sweetened and served ice cold, this tangy crowd pleaser comes in Original or Raspberry Flavour. ";
                itemPrice.Text = "$" + p2.ToString();

            }
            else if (itemid == 3)
            {
                int resourceId = (int)typeof(Resource.Drawable).GetField("drink4").GetValue(null);
                itemimg.SetImageResource(resourceId);
                itemDetails.Text = "A delicious combination of real cream and layers of chocolaty goodness. It’s the perfect summer treat that takes chocolaty to the next level";
                itemPrice.Text = "$" + p3.ToString();

            }
            else if (itemid == 4)
            {
                int resourceId = (int)typeof(Resource.Drawable).GetField("snack1").GetValue(null);
                itemimg.SetImageResource(resourceId);
                itemDetails.Text = "The ultimate breakfast bagel, made fresh on the spot. Three pieces of crisp bacon, seasoned egg patty, fresh lettuce, ripe tomato and processed cheese, all stacked up on your choice of Always Fresh Bagel. ";
                itemPrice.Text = "$" + p4.ToString();

            }
            else if (itemid == 5)
            {
                int resourceId = (int)typeof(Resource.Drawable).GetField("snack2").GetValue(null);
                itemimg.SetImageResource(resourceId);
                itemDetails.Text = "This is what “good morning” tastes like. Your choice of sausage, three pieces of crisp bacon, seasoned egg omelette and processed cheese on a Homestyle Biscuit, English Muffin or toasted Bagel. Not a meat lover? Hold the sausage, or bacon. ";
                itemPrice.Text = "$" + p5.ToString();


            }
            else if (itemid == 6)
            {
                int resourceId = (int)typeof(Resource.Drawable).GetField("snack3").GetValue(null);
                itemimg.SetImageResource(resourceId);
                itemDetails.Text = "Available with our grilled seasoned chicken strips, bacon, tomato, lettuce and ranch sauce.";
                itemPrice.Text = "$" + p6.ToString();

            }
            else if (itemid == 7)
            {
                int resourceId = (int)typeof(Resource.Drawable).GetField("snack4").GetValue(null);
                itemimg.SetImageResource(resourceId);
                itemDetails.Text = "Your choice of seasoned grilled chicken strips, cheddar cheese, lettuce, tomato and chipotle sauce wrapped in a tortilla and grilled to perfection.";
                itemPrice.Text = "$" + p7.ToString();

            }


            itemOrder.Click += delegate
            {
                
                //open order list
                
                
                if (itemid == 0)
                {
                   
                    int resourceId = (int)typeof(Resource.Drawable).GetField("drink1").GetValue(null);
                    itemimg.SetImageResource(resourceId);
                    myDB.InsertValue(resourceId, "Coffee", "0", p0.ToString(), "0");

                }
                else if (itemid == 1)
                {
                    
                    int resourceId = (int)typeof(Resource.Drawable).GetField("drink2").GetValue(null);
                    itemimg.SetImageResource(resourceId);
                    myDB.InsertValue(resourceId, "Dark Roast", "0", p1.ToString(), "0");
                }
                else if (itemid == 2)
                {
                    
                    int resourceId = (int)typeof(Resource.Drawable).GetField("drink3").GetValue(null);
                    itemimg.SetImageResource(resourceId);
                    myDB.InsertValue(resourceId, "Lemonade", "0", p2.ToString(), "0");
                }
                else if (itemid == 3)
                {
                   
                    int resourceId = (int)typeof(Resource.Drawable).GetField("drink4").GetValue(null);
                    itemimg.SetImageResource(resourceId);
                    myDB.InsertValue(resourceId, "Choco Chips", "0", p3.ToString(), "0");
                }
                else if (itemid == 4)
                {
                    
                    int resourceId = (int)typeof(Resource.Drawable).GetField("snack1").GetValue(null);
                    itemimg.SetImageResource(resourceId);
                    myDB.InsertValue(resourceId, "Bagel", "0", p4.ToString(), "0");
                }
                else if (itemid == 5)
                {
                    
                    int resourceId = (int)typeof(Resource.Drawable).GetField("snack2").GetValue(null);
                    itemimg.SetImageResource(resourceId);
                    myDB.InsertValue(resourceId, "Sandwich", "0", p5.ToString(), "0");

                }
                else if (itemid == 6)
                {
                   
                    int resourceId = (int)typeof(Resource.Drawable).GetField("snack3").GetValue(null);
                    itemimg.SetImageResource(resourceId);
                    myDB.InsertValue(resourceId, "Egg Wrap", "0", p6.ToString(), "0");
                }
                else if (itemid == 7)
                {
                    
                    int resourceId = (int)typeof(Resource.Drawable).GetField("snack4").GetValue(null);
                    itemimg.SetImageResource(resourceId);
                    myDB.InsertValue(resourceId, "Chicken Wrap", "0", p7.ToString(), "0");
                }

                
                    


                itemOrder.Visibility = Android.Views.ViewStates.Gone; //hide button
                openorder.Visibility = Android.Views.ViewStates.Visible; //show button

            };


        }
        


     }
}