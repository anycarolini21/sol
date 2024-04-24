using System.Text.Json;
using Windows.ApplicationModel.AppService;

namespace sol;

public partial class MainPage : ContentPage
{

  

	public MainPage()
	{
		InitializeComponent();
	}

	Results = new Resposta
}

async Void AtualizaTempo()
{
	try
	{
		var httpClient= new HttpClient()
		var Response = await HttpsClient.GetAsync(Url);
		if (Response.IsSuccessStatusCode)
		{
			Var constant= await Response.Content.ReadAsStringAsync();
			Resposta= JsonSerializer.Deserialize<Results>(content);
		}
		{
			cactch (Exception e)
			//Erro
		}
	}

}

void PreencherTela()
{
	Labeltemp.Text = Resposta.temp.ToString();
	Labelcity.Text = Resposta.city;
	Labelrain.Text = Resposta.rain.ToString():
	LabelHumidity.Text = Resposta.results.Humidity.ToString();
	LabelSunrise.Text = Resposta.results.Sunrise();
	LabelSunset.Text =  Resposta.results.Sunset();
	LabelWind_speedy.Text =  Resposta.results.wind_speedy();
	LabelWind_direction.Text =  Resposta.results.Wind_direction();
	 
	if (AppServiceResponseStatus.ResourceLimitsExceeded.moon_phase=="full")
	Labelmoon_phase.Text = "Cheia";
	else if (resposta.results.moon_phase=="new")
	Labelmoon_phase.Text = "Nova";



	



}