using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace data
{
    class DataAdapter : RecyclerView.Adapter
    {
        private List<datatable> datalist;
        public Context context;
        tabledatabase sDB;
        datatable studentU;


        public override int ItemCount => datalist.Count;

        public DataAdapter(List<datatable> datalist, Context context)
        {
            this.datalist = datalist;
            this.context = context;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
         
            DataViewholder Dataholder = holder as DataViewholder;
            Dataholder.BindData(datalist[position]);
            Dataholder.deletebutton.Click += (s, e) =>
            {
               
                sDB = new tabledatabase();
                studentU = sDB.GetByUserId(datalist[position].Id);
                if (studentU != null)
                {
                    var isDeleted = sDB.DeleteStudents(studentU);
                    if (isDeleted == true)
                    {
                        Toast.MakeText(context, "Data Deleted Succesfully", ToastLength.Short).Show();
                    }

                    else
                    {

                        Toast.MakeText(context, "No action performed", ToastLength.Short).Show();

                    }
                }
                Intent i = new Intent(Application.Context, typeof(MainActivity));
                context.StartActivity(i);
            };

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.delete, parent, false);
            return new DataViewholder(view);
        }
    }

    internal class DataViewholder : RecyclerView.ViewHolder
    {
        public ImageView deletebutton;
        public TextView dataview;
        
        

        public DataViewholder(View itemView) : base(itemView)
        {
            deletebutton = itemView.FindViewById<ImageView>(Resource.Id.imageView2);
            dataview = itemView.FindViewById<TextView>(Resource.Id.deleteview);
           
        }

       

        internal void BindData(datatable data_table)
        {
            dataview.Text = data_table.Name;
        }
    }
}


        
        
     
           