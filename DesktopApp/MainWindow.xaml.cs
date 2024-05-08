using HotelLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private readonly HotelDbContext dx = new();
        private readonly LocalView<Roomdatum> room;
        private readonly LocalView<Bookingdatum> booking;
        private readonly LocalView<User> user;

        public MainWindow() {
            InitializeComponent();

            room = dx.Roomdata.Local;
            booking = dx.Bookingdata.Local;
            user = dx.Users.Local;

            dx.Roomdata.Load();
            dx.Bookingdata.Load();
            dx.Users.Load();

            allRooms();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e) {
            dx.Roomdata.Load();
            string searchText = searchBox.Text.Trim().ToLower();
            
            if(string.IsNullOrEmpty(searchText) ) {
                allRooms();
            } else if (int.TryParse(searchText, out int RoomNumber)) {
                var filteredList = dx.Roomdata.Where(r => r.RoomNumber == RoomNumber).ToList();
                roomList.ItemsSource = filteredList;
            }
        }

        private void allRooms() {
            dx.Roomdata.Load();
            var filteredList = dx.Roomdata.Select (r => new {
                RoomNumber = r.RoomNumber,
                NumberOfBeds = r.NumberOfBeds,
                RoomSize = r.RoomSize,
                RoomQuality = r.RoomQuality
            }).ToList();
            roomList.ItemsSource = filteredList;
        }

        private void addReservationButton_Click(Object sender, RoutedEventArgs e) {
            using (var context = new HotelDbContext()) {
                var username = usernameTextBox.Text;
                var roomNumber = int.Parse(roomNumberTextBox.Text);
                var numberOfPeople = int.Parse(numberOfPeopleTextBox.Text);
                var checkIn = (DateTime)checkInDatePicker.SelectedDate;
                var checkOut = (DateTime)checkOutDatePicker.SelectedDate;

                var userId = 0;

                var existing = context.Users.FirstOrDefault(u => u.Username == username);

                if (existing != null) {
                    userId = existing.Id;
                } else {
                    addReservationResult.Text = "Bruker eksisterer ikke";
                }

                var room = context.Roomdata.FirstOrDefault(r => r.RoomNumber == roomNumber);
                if (room == null) {
                    addReservationResult.Text = "Rom ikke funnet";
                    return;
                }
                var newBooking = new Bookingdatum {
                    Roomid = room.Id,
                    Userid = userId,
                    Startdate = checkIn,
                    Enddate = checkOut,
                    AntallPersoner = numberOfPeople
                };
                context.Bookingdata.Add(newBooking);
                context.SaveChanges();
                addReservationResult.Text = "Reservasjon har blitt lagt til";
            }
        }
    }
}