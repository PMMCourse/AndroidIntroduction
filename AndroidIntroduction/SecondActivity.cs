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

namespace AndroidIntroduction
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        private Button _buttonCreateFragment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.secondActivityLayout);

            BindLayout();


        }

        private void BindLayout()
        {
            _buttonCreateFragment = FindViewById<Button>(Resource.Id.buttonCreateFragment);

            _buttonCreateFragment.Click += CreateFragment;
        }

        private void CreateFragment(object sender, EventArgs e)
        {
            FragmentManager.BeginTransaction()
                .Replace(Resource.Id.contentFragment, new FragmentSample())
                .Commit();
        }
    }
}