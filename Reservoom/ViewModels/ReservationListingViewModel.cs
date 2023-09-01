using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private ObservableCollection<ReservationViewModel>? reservations;
        public IEnumerable<ReservationViewModel>? Reservations => reservations;

        public ICommand? MakeReservationCommand { get; }

        public ReservationListingViewModel(Hotel hotel, NavigationService makeReservationnavigationService)
        {
            reservations = new ObservableCollection<ReservationViewModel>();
            MakeReservationCommand = new NavigateCommand(makeReservationnavigationService);
            UpdatedReservations(hotel);
        }

        private void UpdatedReservations(Hotel hotel)
        {
            foreach (var reservation in hotel.GetAllReservation())
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
                reservations!.Add(reservationViewModel);
            }
        }
    }
}
