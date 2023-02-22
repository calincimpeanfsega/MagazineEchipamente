namespace MagazineEchipamente;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Ai {count} ture de ski";
		else
			CounterBtn.Text = $"Ai {count} ture de ski";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

