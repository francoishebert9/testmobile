using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace TipCalculator
{
    [Activity(Label = "Tip Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        EditText inputBill;
        Button calculateButton;
        TextView outputTip;
        TextView outputTotal;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            AppCenter.Start("948fdbd9-f879-4910-a2a8-18a96fb9ed23",
                   typeof(Analytics), typeof(Crashes));

            SetContentView(Resource.Layout.Main);

            inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);

            calculateButton.Click += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {
            var s = inputBill.Text;

            var bill = double.Parse(s);

            double tip = bill * 0.15;
            double total = bill + tip;

            outputTip.Text = tip.ToString();
            outputTotal.Text = total.ToString();
        }
    }
}

