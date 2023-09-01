using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using Reservoom.ViewModels;
using System.Windows;

namespace Reservoom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Singletons for whole app
        private readonly Hotel hotel;
        private readonly NavigationStore navigationStore;

        public App()
        {
            hotel = new Hotel("Name is hotel");
            navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            navigationStore.CurrentViewModel = new ReservationListingViewModel(hotel, new NavigationService(navigationStore, CreateMakeReservationViewModel));

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(hotel, new NavigationService(navigationStore, CreateReservationListingViewModel));
        }

        private ReservationListingViewModel CreateReservationListingViewModel()
        {
            return new ReservationListingViewModel(hotel, new NavigationService(navigationStore, CreateMakeReservationViewModel));
        }
    }
}
