using System.Text.Json;
using Windows.ApplicationModel.AppService;

namespace sol;

public partial class MainPage : ContentPage
{
	
	const string url = "https://api.hgbrasil.com/weather?woeid=455927&key=9ec40222";
	Resposta resposta;
	

	public MainPage()
	{
		InitializeComponent();
	}

	async void AtualizaTempo()
	{
		try
		{
			var httpClient = new HttpClient();
			var Response = await httpClient.GetAsync(Url);
			if (Response.IsSuccessStatusCode)
			{
				var content= await Response.Content.ReadAsStringAsync();
				Resposta= JsonSerializer.Deserialize<Results>(content);
			}
		}
		catch (Exception e)
		{		//Erro
		}
	}

	void PreencherTela()
	{
		Labeltemp.Text = resposta.results.temp.ToString();
		Labelcity.Text = resposta.results.city;
		Labelrain.Text = resposta.results.rain.ToString();
		Labelhumidity.Text = resposta.results.humidity.ToString();
		Labelsunrise.Text = resposta.results.sunrise;
		Labelsunset.Text =  refesposta.results.sunset;
		Labelwind_speedy.Text =  resposta.results.wind_speedy;
		Labelwind_direction.Text =  resposta.results.wind_direction;
			
		if (resposta.results.moon_phase=="full")
		Labelmoon_phase.Text = "Cheia";
		else if (resposta.results.moon_phase=="new")
		Labelmoon_phase.Text = "Nova";
	}

}