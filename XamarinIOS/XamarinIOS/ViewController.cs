using Foundation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using UIKit;

namespace XamarinIOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {

        }

        private static readonly HttpClient client = new HttpClient();

        private readonly string helloUrl = "http://192.168.0.188:5000/api/values/";


        public override void ViewDidLoad ()
        {



            base.ViewDidLoad ();

            btnPress.TouchUpInside += async (object sender, EventArgs e) =>
            {
                Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                { "s", "Vasya"}
            };

                FormUrlEncodedContent form = new FormUrlEncodedContent(dict);

                var values = new Dictionary<string, string>{
              { "productId", "1" },
              { "productKey", "Abc6666" },
              { "userName", "OPPO" },
            };

                var json = JsonConvert.SerializeObject(values, Formatting.Indented);

                var stringContent = new StringContent(json);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsync(helloUrl, stringContent);

                string result = await response.Content.ReadAsStringAsync();

                var alert = UIAlertController.Create("Hello ", result, UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
            };

        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}