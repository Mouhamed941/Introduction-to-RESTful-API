using Newtonsoft.Json.Linq;

namespace Example_3_Battery_Info_Android
{
    public partial class MainPage : ContentPage
    {
        private HttpClient _httpClient = new HttpClient();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnBatteryCheckClicked(object sender, EventArgs e)
        {
            string url = "http://192.168.1.4:5184/api/battery/status"; // Replace with your PC's IP

            try
            {
                string response = await _httpClient.GetStringAsync(url);
                var json = JObject.Parse(response);

                BatteryLevelLabel.Text = $"PC Battery: {json["BatteryLevel"]}%";
                BatteryStateLabel.Text = $"Power Source: {json["PowerSource"]}";
            }
            catch (Exception ex)
            {
                BatteryLevelLabel.Text = "Error connecting to PC";
                BatteryStateLabel.Text = ex.Message;
            }
        }
    }

}
