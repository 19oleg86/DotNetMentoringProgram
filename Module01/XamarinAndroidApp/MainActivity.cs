using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace XamarinAndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button btn = FindViewById<Button>(Resource.Id.button1);
            btn.Click += Btn_Click;
            EditText et = FindViewById<EditText>(Resource.Id.editText1);
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            EditText et = FindViewById<EditText>(Resource.Id.editText1);
            TextView tv = FindViewById<TextView>(Resource.Id.textView1);
            tv.Text = "Hello " + et.Text;
        }
    }
}