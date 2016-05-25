using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Net;
using System.IO;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public static string APIUrl = "http://uetlib.herokuapp.com/api/books";
        public ObservableCollection<Book> listBook = new ObservableCollection<Book>();
        MainWindow mainWindow;
        Book selectedBook;

        public Card()
        {
            InitializeComponent();
            MyListBook.ItemsSource = listBook;            
            LoadBook(APIUrl);
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (Book)(sender as Button).DataContext;
            mainWindow.EditBook_OnClick(sender, e, selectedBook);
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this book?",
              "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Visibility = Visibility.Collapsed;
                mainWindow.ProgressBar.Visibility = Visibility.Visible;

                selectedBook = (Book)(sender as Button).DataContext;
                var deleteBookHandler = new HttpHandler(null, this);
                deleteBookHandler.RequestCompleted += HandlerDeleteBookRequestCompleted;
                deleteBookHandler.DeleteBook(selectedBook.Id);
            }
        }

        private void Card_OnClick(object sender, MouseButtonEventArgs e)
        {
            Book selectedBook = (Book) (ItemsControl.ContainerFromElement(MyListBook, e.OriginalSource as DependencyObject) 
                as ListBoxItem).DataContext;
            mainWindow.ViewBook(sender, e, selectedBook);
        }

        public void LoadBook(string requestUrl)
        {
            this.Visibility = Visibility.Collapsed;
            //mainWindow.ProgressBar.Visibility = Visibility.Visible;

            var loadBookHandler = new HttpHandler(null, this);
            loadBookHandler.RequestCompleted += HandlerLoadBookRequestCompleted;
            loadBookHandler.LoadBook();
        }

        void HandlerLoadBookRequestCompleted(object sender, GenericEventArgs<HttpWebResponse> e)
        {
            if (e.Value.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(String.Format("Server error (HTTP {0}: {1}).", e.Value.StatusCode, e.Value.StatusDescription));
            }

            else
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    if (e.Value.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        e.Value.StatusCode,
                        e.Value.StatusDescription));
                    }


                    var reader = new StreamReader(e.Value.GetResponseStream());
                    System.Web.Script.Serialization.JavaScriptSerializer js =
                        new System.Web.Script.Serialization.JavaScriptSerializer();
                    var obj = js.Deserialize<dynamic>(reader.ReadToEnd());
                    foreach (var o in obj)
                    {
                        var id = o["id"];
                        var name = o["name"];
                        var description = o["description"];
                        var picture = o["picture"];
                        var author = o["author"];
                        var status = o["status"];
                        var date = o["published_date"];
                        var pageCount = o["page_count"];
                        listBook.Add(new Book(id, picture, name, description, author, status, date, pageCount));
                    }
                    mainWindow = (MainWindow)Window.GetWindow(this);
                    mainWindow.ProgressBar.Visibility = Visibility.Collapsed;
                    this.Visibility = Visibility.Visible;
                }));
            }
        }

        void HandlerDeleteBookRequestCompleted(object sender, GenericEventArgs<HttpWebResponse> e)
        {
            if (e.Value.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(String.Format("Server error (HTTP {0}: {1}).", e.Value.StatusCode, e.Value.StatusDescription));
            }

            else
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    listBook.Remove(selectedBook);
                    mainWindow.ProgressBar.Visibility = Visibility.Collapsed;
                    this.Visibility = Visibility.Visible;
                }));
            }
        }

        public void hideProgressBarAndShowCurrentContent()
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                this.Visibility = Visibility.Visible;
                MainWindow win = (MainWindow)Application.Current.MainWindow;
                win.ProgressBar.Visibility = Visibility.Collapsed;
            }));
        }

        public void showProgressBarAndHideCurrentContent()
        {
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.ProgressBar.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }
    }
}
