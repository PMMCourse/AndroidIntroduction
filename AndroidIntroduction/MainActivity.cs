using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace AndroidIntroduction
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private Button _buttonChangeName;
        private TextView _labelChangedName;
        private EditText _editTextForName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.content_main);

            AddBindForLayout();
                        
        }

        private void AddBindForLayout()
        {
            _buttonChangeName = FindViewById<Button>(Resource.Id.buttonChangeName);
            _labelChangedName = FindViewById<TextView>(Resource.Id.labelForName);
            _editTextForName = FindViewById<EditText>(Resource.Id.editTextName);

            _buttonChangeName.Click += ChangeNameClick;
        }

        private void ChangeNameClick(object sender, EventArgs e)
            => _editTextForName.Text = _labelChangedName.Text;
        
	}
}

