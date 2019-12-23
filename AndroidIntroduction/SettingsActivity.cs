using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidIntroduction
{
    [Activity(Label = "SettingsActivity")]
    public class SettingsActivity : Activity
    {
        private Button _buttonReadSetting;
        private Button _buttonWriteSetting;
        private EditText _editTextSetting;

        private ISharedPreferences _sharedPreferences;
        private ISharedPreferencesEditor _sharedPreferencesEditor;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SettingsLayout);

            BindLayout();
            InstancePreferences();
        }
        
        private void BindLayout()
        {
            _buttonReadSetting = FindViewById<Button>(Resource.Id.buttonReadSetting);
            _buttonWriteSetting = FindViewById<Button>(Resource.Id.buttonWriteSetting);            
            _editTextSetting = FindViewById<EditText>(Resource.Id.editTextSettings);            

            _buttonReadSetting.Click += ReadSetting;
            _buttonWriteSetting.Click += WriteSetting;
        }
                
        private void ReadSetting(object sender, EventArgs e)
            => _editTextSetting.Text = _sharedPreferences.GetString("keySettingString", string.Empty);            
        
        private void WriteSetting(object sender, EventArgs e)
        {
            _sharedPreferencesEditor.PutString("keySetting", _editTextSetting.Text);
            _sharedPreferencesEditor.Apply();

            //=> _sharedPreferencesEditor.PutInt("KeySettingInt" int.Parse(_editTextSetting.Text);
        }

        private void InstancePreferences()
        {
            _sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);
            //We can use ApplicationContext too.
            //_sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(Application.ApplicationContext);

            _sharedPreferencesEditor = _sharedPreferences.Edit();
        }
    }
}