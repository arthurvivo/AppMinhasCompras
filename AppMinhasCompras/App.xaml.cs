using SQLite;
using Microsoft.Extensions.DependencyInjection;
using AppMinhasCompras.Helpers;

namespace AppMinhasCompras
{
    public partial class App : Application
    {
        static SqliteDatabaseHelper db;

        public static SqliteDatabaseHelper Db
        {
            get
            {
                if (db == null)
                {
                    string dbPath = Path.Combine(FileSystem.AppDataDirectory, "MinhasCompras.db3");
                    db = new SqliteDatabaseHelper(dbPath);
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}