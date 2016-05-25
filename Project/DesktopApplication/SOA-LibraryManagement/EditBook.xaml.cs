using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Net;
using System.Diagnostics;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for EditBook.xaml
    /// </summary>
    public partial class EditBook : UserControl
    {
        Book book;
        string imageUrl;
        public static string APIUrl = "http://uetlib.herokuapp.com/api/books";
        public static string UploadImageUrl = "http://uploads.im/api?upload";

        public EditBook(Book book)
        {
            InitializeComponent();
            this.book = book;
            imageUrl = book.Picture;
            CoverImage.Text = book.Picture;
            Name.Text = book.Name;
            Description.Text = book.Description;
            Author.Text = book.Author;
            Status.Text = book.Status;
            Date.Text = book.PublishDate;
            PageCount.Text = book.PageCount.ToString();
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Name.Text.Equals("") || CoverImage.Text.Equals("") || Description.Text.Equals("") ||
                Author.Text.Equals("") || Status.Text.Equals("") || Date.Text.Equals("") || PageCount.Text.Equals(""))
            {
                return;
            }

            MainWindow win = (MainWindow)Window.GetWindow(this);
            if (Name.Text.Equals(book.Name) && CoverImage.Text.Equals(book.Picture) && Description.Text.Equals(book.Description) &&
                Author.Text.Equals(book.Author) && Status.Text.Equals(book.Status) && Date.Text.Equals(book.PublishDate) &&
                PageCount.Text.Equals(book.PageCount.ToString()))
            {
                win = (MainWindow)Window.GetWindow(this);
                win.GoBack(sender, e);
                return;
            }

            showProgressBarAndHideCurrentContent();

            if (!(CoverImage.Text.Equals(book.Picture)))
            {
                UpLoadImage(CoverImage.Text);
            }
            else
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("name", Name.Text);
                dic.Add("description", Description.Text);
                dic.Add("picture", CoverImage.Text);
                dic.Add("author", Author.Text);
                dic.Add("status", Status.Text);
                dic.Add("published_date", Date.Text);
                dic.Add("page_count", PageCount.Text);

                var editBookHandler = new HttpHandler(dic, this);
                editBookHandler.RequestCompleted += HandlerEditBookRequestCompleted;
                editBookHandler.EditBook(book.Id);
            }
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

        public void UpLoadImage(string fileName)
        {
            WebClient wc = new WebClient();
            wc.UploadFileCompleted += UploadImageRequestCompleted;
            wc.UploadFileAsync(new Uri(UploadImageUrl), fileName);
        }

        void UploadImageRequestCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBoxResult r = MessageBox.Show(e.Error.Message, "Network error");
                Debug.WriteLine(e.Error.Message);
                MainWindow win = (MainWindow)Application.Current.MainWindow;
                this.Visibility = Visibility.Visible;
                win.ProgressBar.Visibility = Visibility.Collapsed;
            }
            else
            {
                string result = System.Text.Encoding.UTF8.GetString(e.Result);
                System.Web.Script.Serialization.JavaScriptSerializer js =
                new System.Web.Script.Serialization.JavaScriptSerializer();
                var obj = js.Deserialize<dynamic>(result);
                if (obj["status_code"] != 200)
                {
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    obj["status_code"],
                    obj["status_txt"]));
                }

                else
                {
                    imageUrl = (obj["data"])["thumb_url"];

                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("name", Name.Text);
                    dic.Add("description", Description.Text);
                    dic.Add("picture", imageUrl);
                    dic.Add("author", Author.Text);
                    dic.Add("status", Status.Text);
                    dic.Add("published_date", Date.Text);
                    dic.Add("page_count", PageCount.Text);

                    var editBookHandler = new HttpHandler(dic, this);
                    editBookHandler.RequestCompleted += HandlerEditBookRequestCompleted;
                    editBookHandler.EditBook(book.Id);
                }
            }          
        }

        void HandlerEditBookRequestCompleted(object sender, GenericEventArgs<HttpWebResponse> e)
        {
            if (e.Value.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(String.Format("Server error (HTTP {0}: {1}).", e.Value.StatusCode, e.Value.StatusDescription));
            }

            else
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    MainWindow win = (MainWindow)Application.Current.MainWindow;
                    foreach (Book b in win.card.listBook)
                    {
                        if (b.Id == book.Id)
                        {
                            b.Name = Name.Text;
                            b.Description = Description.Text;
                            b.Picture = imageUrl;
                            b.Author = Author.Text;
                            b.Status = Status.Text;
                            b.PublishDate = Date.Text;
                            b.PageCount = Int32.Parse(PageCount.Text);
                        }
                    }


                    this.Visibility = Visibility.Visible;
                    win.ProgressBar.Visibility = Visibility.Collapsed;
                    MessageBoxResult result = MessageBox.Show("Edit book success", "Confirmation");
                    if (result == MessageBoxResult.OK)
                    {
                        win.GoBack(sender, new RoutedEventArgs());
                    }
                }));
            }
            e.Value.Close();
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
