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
				Resposta= JsonSerializer.Deserialize<Results>(content);
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
		Labeldescription.Text =resposta.results.temp.ToString();
		Labelcity.Text =resposta.results.city;
		Labelrain.Text =resposta.results.rain.ToString();
		Labelhumidity.Text =resposta.results.humidity.ToString();
		Labelsunrise.Text =resposta.results.sunrise();
		Labelsunset.Text =resposta.results.sunset.();
		Labelwind_speedy.Text =resposta.results.wind_speedy();
		Labelwind_direction.Text =resposta.results.wind_direction();
			if (resposta.results.moon_fase=="full")
			labelmoon_phase.Text= "minguante";
			else if (resposta.results.moon_phase=="new")
			 labelmoon_phase.Text= "Nova"
			 else if (resposta.results.moon_phase=="growing")
			 labelmoon_phase.Text= "Crescente"
			 else if (resposta.results.moon_phase=="waning")
			 labelmoon_phase.Text= "minguante"

		if(resposta.results.rain.currently=="dia")
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