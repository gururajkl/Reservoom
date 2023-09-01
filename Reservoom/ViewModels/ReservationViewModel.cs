using Reservoom.Models;

namespace Reservoom.ViewModels
{
    /// <summary>
    /// Class that helps to bind the Model and ViewModel that implements the INotify.
    /// (Because Model class does not implement the ViewModelBase, so changes won't be notified there, so created the another ViewModel).
    /// </summary>
    public class ReservationViewModel : ViewModelBase
    {
        private Reservation reservation;

        public string? RoomID => reservation.RoomID?.ToString();
        public string Username => reservation.Username;
        public string StartDate => reservation.StartTime.Date.ToString("d");
        public string EndDate => reservation.EndTime.Date.ToString("d");

        public ReservationViewModel(Reservation reservation)
        {
            this.reservation = reservation;
        }
    }
}
