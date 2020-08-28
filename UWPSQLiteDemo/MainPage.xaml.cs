using System;
using SQLite.Net.Attributes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Runtime.InteropServices.ComTypes;
using System.ServiceModel.Channels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPSQLiteDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string path;
        SQLite.Net.Connection conn;
        public MainPage()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalCacheFolder.Path, "db.sqlsite");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Customer>();
        }
        private void Retrieve_Click(object sender, RoutedEventArgs e)
        {
            var query = conn.Table<Customer>();
            string id = "";
            string name = "";
            string age = "";
            foreach (var massage in query)
            {
                id = id + " " + Message.id;
                name = name + " " + Message.name;
                age = age + " " + Message.age;
            }
            textBlock2.Text = "ID :" + id + "\nName : " + Name + "\nAge : " +  age;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var s = conn.Insert(new Customer()
            {
                Name = textBox.Text,
                Age = textBox1.Text
            });
        }
    }
    public class Cutomer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string name { get; set; }
        public string age { get;set }
    }
}
