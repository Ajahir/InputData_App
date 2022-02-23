using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data
{
    [Activity(Label = "insertdataActivity")]
    public class insertdataActivity : Activity
    {
        private Button btn;
        private EditText myName;
        tabledatabase Tdb;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.insertact);
            btn = FindViewById<Button>(Resource.Id.addbtn);
            myName = FindViewById<EditText>(Resource.Id.editText2);
            btn.Click += Btn_Click;
            Tdb = new tabledatabase();
            Tdb.dataTable();
        }

        private void Btn_Click(object sender, EventArgs e)
        {

            datatable studs = new datatable();
            studs.Name = myName.Text;
      


            bool checkinsert = Tdb.InstertData(studs);
            if (checkinsert == true)
            {

                Toast.MakeText(this, "Data Inserted Succesfully", ToastLength.Short).Show();

            }
            else
            {

                Toast.MakeText(this, "No action performed", ToastLength.Short).Show();


            }
            Intent p = new Intent(Application.Context, typeof(MainActivity));
            StartActivity(p);



        }
    }
    }
