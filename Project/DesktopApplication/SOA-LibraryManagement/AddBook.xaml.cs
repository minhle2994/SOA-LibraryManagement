using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : UserControl
    {
        public static string UploadImageUrl = "http://uploads.im/api?upload";

        public AddBook()
        {
            InitializeComponent();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Name.Text.Equals("") || CoverImage.Text.Equals("") || Description.Text.Equals("") ||
                Author.Text.Equals("") || Status.Text.Equals("") || Date.Text.Equals("") || PageCount.Text.Equals(""))
            {
                return;
            }

            this.Visibility = Visibility.Collapsed;
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.ProgressBar.Visibility = Visibility.Visible;
            UpLoadImage(CoverImage.Text);
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.GoBack(sender, e);
        }

        private void BrowseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                bookCoverImage.Source = new BitmapImage(new Uri(op.FileName));
                CoverImage.Text = op.FileName;
            }
        }

        void UploadImageRequestCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBoxResult r = MessageBox.Show(e.Error.Message, "Network error");
                Debug.WriteLine(e.Error.Message);
                MainWindow win = (MainWindow)Application.Current.MainWindow;
                win.ProgressBar.Visibility = Visibility.Collapsed;
                this.Visibility = Visibility.Visible;
            }
            else
            {
                string result = System.Text.Encoding.UTF8.GetString(e.Result);
                System.Web.Script.Serialization.JavaScriptSerializer js =
                    new System.Web.Script.Serialization.JavaScriptSerializer();
                var obj = js.Deserialize<dynamic>(result);
                if (obj["status_code"] != 200)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    obj["status_code"],
                    obj["status_txt"]));
                else
                {
                    string imageUrl = (obj["data"])["thumb_url"];

                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("name", Name.Text);
                    dic.Add("description", Description.Text);
                    dic.Add("picture", imageUrl);
                    dic.Add("author", Author.Text);
                    dic.Add("status", Status.Text);
                    dic.Add("published_date", Date.Text);
                    dic.Add("page_count", PageCount.Text);

                    var addBookHandler = new HttpHandler(dic, this);
                    addBookHandler.RequestCompleted += HandlerAddBookRequestCompleted;
                    addBookHandler.AddBook();
                }
            }
        }

        void HandlerAddBookRequestCompleted(object sender, GenericEventArgs<HttpWebResponse> e)
        {
            if (e.Value.StatusCode != HttpStatusCode.Created)
                throw new Exception(String.Format(
                "Server error (HTTP {0}: {1}).",
                e.Value.StatusCode,
                e.Value.StatusDescription));
            else
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    MainWindow win = (MainWindow)Application.Current.MainWindow;
                    var reader = new StreamReader(e.Value.GetResponseStream());
                    System.Web.Script.Serialization.JavaScriptSerializer js =
                        new System.Web.Script.Serialization.JavaScriptSerializer();
                    var obj = js.Deserialize<dynamic>(reader.ReadToEnd());
                    var id = obj["id"];
                    var name = obj["name"];
                    var description = obj["description"];
                    var picture = obj["picture"];
                    var author = obj["author"];
                    var status = obj["status"];
                    var date = obj["published_date"];
                    var pageCount = obj["page_count"];
                    win.card.listBook.Add(new Book(id, picture, name, description, author, status, date, pageCount));

                    win.ProgressBar.Visibility = Visibility.Collapsed;
                    this.Visibility = Visibility.Visible;
                    MessageBoxResult result = MessageBox.Show("Add book success", "Confirmation");
                    if (result == MessageBoxResult.OK)
                    {
                        win.GoBack(sender, new RoutedEventArgs());
                    }
                }));
            }
            e.Value.Close();
        }

        static string ReadResponse(HttpWebResponse response)
        {
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }

        public void UpLoadImage(string fileName)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.UploadFileCompleted += UploadImageRequestCompleted;
                wc.UploadFileAsync(new Uri(UploadImageUrl), fileName);
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message, "Network error");
                Debug.WriteLine(ex.Message);
                MainWindow win = (MainWindow)Application.Current.MainWindow;
                win.ProgressBar.Visibility = Visibility.Collapsed;
                this.Visibility = Visibility.Visible;
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
