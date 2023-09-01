using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Services;
using System;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
        private string? username;
        public string? Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private int floorNumber;
        public int FloorNumber
        {
            get { return floorNumber; }
            set
            {
                floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }

        private int roomNumber;
        public int RoomNumber
        {
            get { return roomNumber; }
            set
            {
                roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        private DateTime startDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime endDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public ICommand? SubmitCommand { get; }
        public ICommand? CancelCommand { get; }

        public MakeReservationViewModel(Hotel hotel, NavigationService reservationViewNavigationService)
        {
            SubmitCommand = new MakeReservationCommand(this, hotel, reservationViewNavigationService);
            CancelCommand = new NavigateCommand(reservationViewNavigationService);
        }
    }
}
