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
    }
}