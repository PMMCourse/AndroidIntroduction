using System;
using System.Collections.Generic;
using System.IO;
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
    [Activity(Label = "FilesActivity")]
    public class FilesActivity : Activity
    {
        private Button _buttonFileRead;
        private Button _buttonFileWrite;
        private EditText _editTextFile;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FilesLayout);

            BindLayout();
        }

        private void BindLayout()
        {
            _buttonFileRead = FindViewById<Button>(Resource.Id.buttonReadFile);
            _buttonFileWrite = FindViewById<Button>(Resource.Id.buttonWriteFile);
            _editTextFile = FindViewById<EditText>(Resource.Id.editTextFileContent);

            _buttonFileRead.Click += ReadFile;
            _buttonFileWrite.Click += WriteFile;
        }

        private void ReadFile(object sender, EventArgs e)
        {
            var f = EnsureFile();
            _editTextFile.Text = new StreamReader(f).ReadToEnd();
            f.Close();
        }
        
        private void WriteFile(object sender, EventArgs e)
        {
            var f = EnsureFile();
            new StreamWriter(f).WriteLine(_editTextFile.Text);
            f.Close();
        }

        private FileStream EnsureFile()
            => File.Open("sample.txt", FileMode.OpenOrCreate);
    }
}