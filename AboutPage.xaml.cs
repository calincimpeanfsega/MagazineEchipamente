using System.Diagnostics;

namespace MagazineEchipamente;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    private void facebook(object sender, EventArgs e)
    {
        var url = "https://www.facebook.com/outdoorprocluj";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(url)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }
    private void email(object sender, EventArgs e)
    {
        var email = "mailto:ski@gmail.com";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(email)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }

    private void ski(object sender, EventArgs e)
    {
        var url = "https://iturist.ro/partii-de-schi-din-romania/";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(url)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }
    

}