using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using AndroidIntroduction.Adapters;

namespace AndroidIntroduction
{
    [Activity(Label = "ListSampleActivity")]
    public class ListSampleActivity : Activity
    {
        private RecyclerView _listSample;
        private RecyclerView.LayoutManager _layoutManager;
        private UserAdapter _userAdapter;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListSampleLayout);

            BindLayout();
            PopulateList();
        }
        
        private void BindLayout()
        {
            _listSample = FindViewById<RecyclerView>(Resource.Id.listViewSample);
        }

        private void PopulateList()
        {
            _layoutManager = new LinearLayoutManager(this);
            _listSample.SetLayoutManager(_layoutManager);

            _userAdapter = new UserAdapter(LoadUsers());
            _listSample.SetAdapter(_userAdapter);
        }

        private List<User> LoadUsers()
            =>
            new List<User>()
            {
                new User() { Name = "Paco" , Surname = "Perez" },
                new User() { Name = "Paco" , Surname = "Perez" },
                new User() { Name = "Paco" , Surname = "Perez" },
                new User() { Name = "Paco" , Surname = "Perez" },
                new User() { Name = "Paco" , Surname = "Perez" },
                new User() { Name = "Paco" , Surname = "Perez" },
                new User() { Name = "Paco" , Surname = "Perez" },
                new User() { Name = "Paco" , Surname = "Perez" },
                new User() { Name = "Paco" , Surname = "Perez" },
                new User() { Name = "Paco" , Surname = "Perez" },
                new User() { Name = "Paco" , Surname = "Perez" },
                new User() { Name = "Paco" , Surname = "Perez" },
                new User() { Name = "Paco" , Surname = "Perez" },
                new User() { Name = "Paco" , Surname = "Perez" },
            };
    }
}