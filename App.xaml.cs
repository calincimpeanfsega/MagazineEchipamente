using System;
using MagazineEchipamente.Data;
using System.IO;

namespace MagazineEchipamente;

public partial class App : Application
{
    static EchipamenteDatabase database;
    public static EchipamenteDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               EchipamenteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "ShoppingList.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
