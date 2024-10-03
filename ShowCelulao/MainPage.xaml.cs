namespace ShowCelulao;

public partial class MainPage : ContentPage
{
	Gerenciador gerenciador;

	public MainPage()
	{
		InitializeComponent();
		gerenciador = new Gerenciador(Labelpergunta, Button1, Button2, Button3, Button4, Button5, labelPontuacao, labelNivel);

	}

	void OnButtonResposta01ButtonClicked(object sender, EventArgs args)
	{
		gerenciador.VerfiicaCorreto(1);
	}
	void OnButtonResposta02ButtonClicked(object sender, EventArgs args)
	{
		gerenciador.VerfiicaCorreto(2);
	}
	void OnButtonResposta03ButtonClicked(object sender, EventArgs args)
	{
		gerenciador.VerfiicaCorreto(3);
	}
	void OnButtonResposta04ButtonClicked(object sender, EventArgs args)
	{
		gerenciador.VerfiicaCorreto(4);
	}
	void OnButtonResposta05ButtonClicked(object sender, EventArgs args)
	{
		gerenciador.VerfiicaCorreto(5);
	}
	private void ButtonVoltarButtonClicked(object sender, EventArgs args)
	{

		Application.Current.MainPage = new MainPage();

	}

	async void OnAjudaPulaClicked(object s, EventArgs E)
	{
			gerenciador.ProximaQuestao();
			(s as ImageButton).IsVisible = false;
	}
	void OnAjudaRetirarClicked(object s, EventArgs e)
	{
		var ajuda = new RetiraErradas();
		ajuda.ConfiguraDesenho(Button1, Button2, Button3, Button4, Button5);
		ajuda.RealizaAjuda(gerenciador.GetQuestaoAtual());
		(s as ImageButton).IsVisible = false;
	}
}


