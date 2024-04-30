using System.Text.Json;
using Windows.ApplicationModel.AppService;

namespace sol;

public partial class MainPage : ContentPage
{
	
	const string url="https://api.hgbrasil.com/weather?woeid=455927&key=9ec40222";
	Resposta resposta;
	

	public MainPage()
	{
		InitializeComponent();
		AtualizaTempo();
	}

	async void AtualizaTempo()
	{
		try
		{
			var httpClient = new HttpClient();
			var response = await httpClient.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				var content= await response.Content.ReadAsStringAsync();
				resposta= JsonSerializer.Deserialize<Resposta>(content);
			}
			PreencherTela();
		}
		catch (Exception e)
		{		//Erro
		}
	}

	void PreencherTela()
	{
		Labeltemp.Text =resposta.results.temp.ToString();
		Labeldescription.Text =resposta.results.description;
		Labelcity.Text =resposta.results.city;
		Labelrain.Text =resposta.results.rain.ToString();
		Labelhumidity.Text =resposta.results.humidity.ToString();
		Labelsunrise.Text =resposta.results.sunrise;
		Labelsunset.Text =resposta.results.sunset;
		Labelwind_speedy.Text =resposta.results.wind_speedy;
		Labelwind_direction.Text =resposta.results.wind_direction.ToString();
		Labelwind_cardinal.Text =resposta.results.wind_cardinal.ToString();
		Labelmoon_phase.Text =resposta.results.moon_phase.ToString();
			if (resposta.results.moon_phase=="new")
			Labelmoon_phase.Text= "Lua Nova";
			else if (resposta.results.moon_phase=="full")
			 Labelmoon_phase.Text= "Lua Cheia";
			 else if (resposta.results.moon_phase=="waxing_quarter")
			 Labelmoon_phase.Text= "Lua Crescente";
			  else if (resposta.results.moon_phase=="waning_gibbous")
			 Labelmoon_phase.Text= "Lua Gibosa Crescente";
			  else if (resposta.results.moon_phase=="waning_gibbous")
			 Labelmoon_phase.Text= "Lua Gibosa Minguante";
			  else if (resposta.results.moon_phase=="last_quarter")
			 Labelmoon_phase.Text= "Lua Quarto minguante";
			 else if (resposta.results.moon_phase=="waning_crescent")
			 Labelmoon_phase.Text= "Lua minguante";


		if(resposta.results.currently=="dia")
		{
			if (resposta.results.rain>=18)
			imgFundo.Source="diachuvoso.jpg";
			else if (resposta.results.cloudiness>=10)
			imgFundo.Source="dianublado.jpg";
			else 
			imgFundo.Source="diaensolarado.jpg";

		}
		else
		{

		}


	}

}