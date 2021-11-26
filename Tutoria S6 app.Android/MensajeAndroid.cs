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
using Tutoria_S6_app.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(MensajeAndroid))]

namespace Tutoria_S6_app.Droid
{
    class MensajeAndroid : Mensaje
    {
        public void LongAlert(string mensaje)
        {
            //5 segundos
            Toast.MakeText(Application.Context, mensaje, ToastLength.Long).Show();
        }

        public void ShortAlert(string mensaje)
        {
            //3 segundos
            Toast.MakeText(Application.Context, mensaje, ToastLength.Short).Show();
        }
    }
}