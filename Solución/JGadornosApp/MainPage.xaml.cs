using JGadornosApp.JGmodels;
using Newtonsoft.Json;

namespace JGadornosApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void JGButton_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7111/api/");
            var response = client.GetAsync("JGadorno").Result;

            if (response.IsSuccessStatusCode) {

                var JGadornos = response.Content.ReadAsStringAsync().Result;
                var JGadornoList = JsonConvert.DeserializeObject<List<JGadorno>>(JGadornos);
                JGlistView.ItemsSource = JGadornoList;
        }
    }
    }
}
