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
using SQLite;

namespace AndroidIntroduction
{
    [Activity(Label = "BBDDActivity")]
    public class BBDDActivity : Activity
    {
        private Button _buttonReadTable;
        private Button _buttonWriteTable;
        private EditText _editTextTable;

        private SQLiteConnection db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //We need to add Nuget package sqlite-net-pcl For ORM
            //Or nuget Mono.Data.Sqlite for standard database

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BBDDLayout);
            BindLayout();
        }

        private void BindLayout()
        {
            _buttonReadTable = FindViewById<Button>(Resource.Id.buttonReadTable);
            _buttonWriteTable = FindViewById<Button>(Resource.Id.buttonWriteTable);
            _editTextTable = FindViewById<EditText>(Resource.Id.editTextTableContent);

            _buttonReadTable.Click += ReadTable;
            _buttonWriteTable.Click += WriteTable;        
        }

        private void ReadTable(object sender, EventArgs e)
        {
            EnsureBBDD();

            try
            {                
                var users = db.Table<User>();

                if(users.Count() > 0)
                {
                    _editTextTable.Text = users.FirstOrDefault().ToString();
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }            
        }
        
        private void WriteTable(object sender, EventArgs e)
        {
            EnsureBBDD();

            try
            {
                db.CreateTable<User>();
                db.InsertOrReplace(new User() { Name = "Paco", Surname = "Martinez" });
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private void EnsureBBDD()
        {
            db = new SQLiteConnection("db.sqlite");
        }
    }
}