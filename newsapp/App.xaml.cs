using newsapp.Pages;

namespace newsapp;

public partial class App : Application
{
	public App()
	{
        InitializeComponent();

		MainPage = new NavigationPage(new NewsHomePage());
	}

    
}

