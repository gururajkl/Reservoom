using Reservoom.Exceptions;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace Reservoom.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly Hotel hotel;
        private readonly NavigationService navigationService;
        private readonly MakeReservationViewModel makeReservationViewModel;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel, NavigationService navigationService)
        {
            this.hotel = hotel;
            this.navigationService = navigationService;
            this.makeReservationViewModel = makeReservationViewModel;
            makeReservationViewModel.PropertyChanged += MakeReservationViewModel_PropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(makeReservationViewModel.Username) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Reservation reservation = new Reservation(
                new RoomID(makeReservationViewModel.FloorNumber, makeReservationViewModel.RoomNumber),
                makeReservationViewModel.StartDate,
                makeReservationViewModel.EndDate,
                makeReservationViewModel.Username!);

            try
            {
                hotel.MakeReservation(reservation);
                MessageBox.Show($"Room number {makeReservationViewModel.RoomNumber} in Floor number {makeReservationViewModel.FloorNumber} Booked Successfully!", "Booking Successful!", MessageBoxButton.OK, MessageBoxImage.Information);
                navigationService.Navigate();
            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("This room has been booked!", "Booked!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MakeReservationViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.Username))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
