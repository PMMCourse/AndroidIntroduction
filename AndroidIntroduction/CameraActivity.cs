using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace AndroidIntroduction
{
    [Activity(Label = "CameraActivity")]
    public class CameraActivity : Activity
    {
        private const int REQUEST_CAMERA = 1000;

        private LinearLayout _mainLayout;
        private Button _buttonUseCamera;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CameraActivityLayout);
            BindLayout();
            RequestCameraPermission();
        }
        
        private void BindLayout()
        {
            _mainLayout = FindViewById<LinearLayout>(Resource.Id.mainLayout);
            _buttonUseCamera = FindViewById<Button>(Resource.Id.buttonUseCamera);

            _buttonUseCamera.Click += UseCameraClick;
        }

        private void RequestCameraPermission()
        {
            var requiredPermission = new String[] { Manifest.Permission.Camera };
            if (this.ShouldShowRequestPermissionRationale(Manifest.Permission.Camera))
            {
                Snackbar.Make(_mainLayout, "Require camera permissions", Snackbar.LengthIndefinite)
                    .SetAction("OK", new Action<View>((v) => RequestPermission(requiredPermission)))
                    .Show();
            }
            else
            {
                RequestPermission(requiredPermission);
            }
        }

        private void RequestPermission(string[] permissions)
            => ActivityCompat.RequestPermissions(this, permissions, REQUEST_CAMERA);

        private void UseCameraClick(object sender, EventArgs e)
        {
            if (this.CheckSelfPermission(Manifest.Permission.Camera) == Android.Content.PM.Permission.Granted)
            {
                //Go ahead and use camera
            }
            else
            {
                //No permission for camera
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            if(requestCode == REQUEST_CAMERA)
            {
                if((grantResults.Length == 1) && (grantResults[0] == Permission.Granted))
                {
                    //User click in allow for Camera permission you can include in settings or do anything you want.
                }
                else
                {
                    //User click in disallow for Camera permission you take care about this and warn user to require for something
                }
            }
        }
    }
}