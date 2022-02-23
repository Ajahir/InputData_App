using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using static Android.App.ActionBar;

namespace data
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ImageView plus;
        private List<datatable> datalist;
        RecyclerView.LayoutManager myLayoutmanager;
        RecyclerView myrecyclerView;
        private tabledatabase myDataBase;
        private DataAdapter sadapter;
        private ImageView deletebtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            myrecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);
            plus = FindViewById<ImageView>(Resource.Id.imageView1);
            deletebtn = FindViewById<ImageView>(Resource.Id.deleteview);
            plus.Click += Plus_Click;
            myDataBase = new tabledatabase();
            myDataBase.dataTable();
            GetStudentsDetails();

            myLayoutmanager = new LinearLayoutManager(this);
            myrecyclerView.SetLayoutManager(myLayoutmanager);

            sadapter = new DataAdapter(datalist, this);
            myrecyclerView.SetAdapter(sadapter);
        }

        private List<datatable> GetStudentsDetails()
        {

            myDataBase = new tabledatabase();
            var data = myDataBase.ReadTask();

            datalist = new List<datatable>();

            datalist.AddRange(data);

            return datalist;
        }

        private void Plus_Click(object sender, System.EventArgs e)
        {
            Intent p = new Intent(Application.Context, typeof(insertdataActivity));
            StartActivity(p);
        }

        
    }
}