using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public Card card;
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            card = new Card();
            Content.Children.Clear();
            Content.Children.Add(card);
            MenuToggleButton.IsChecked = false;
            MenuToggleButton.IsHitTestVisible = false;
            ToolbarName.Text = "Library Management";
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = this;
        }

        public void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddBook addBook = new AddBook();
            Content.Children.Clear();
            Content.Children.Add(addBook);
            MenuToggleButton.IsChecked = true;
            MenuToggleButton.IsHitTestVisible = true;
            ToolbarName.Text = "Add Book";
            AddButton.Visibility = Visibility.Hidden;
        }

        public void GoBack(object sender, RoutedEventArgs e)
        {
            Content.Children.Clear();
            Content.Children.Add(card);
            MenuToggleButton.IsChecked = false;
            MenuToggleButton.IsHitTestVisible = false;
            ToolbarName.Text = "Library Management";
            AddButton.Visibility = Visibility.Visible;
        }


        public void EditBook_OnClick(object sender, RoutedEventArgs e, Book book)
        {
            EditBook editBook = new EditBook(book);
            Content.Children.Clear();
            Content.Children.Add(editBook);
            MenuToggleButton.IsChecked = true;
            MenuToggleButton.IsHitTestVisible = true;
            ToolbarName.Text = book.Name;
            AddButton.Visibility = Visibility.Hidden;
        }

        public void ViewBook(object sender, RoutedEventArgs e, Book book)
        {
            EditBook editBook = new EditBook(book);
            Content.Children.Clear();
            Content.Children.Add(editBook);
            MenuToggleButton.IsChecked = true;
            MenuToggleButton.IsHitTestVisible = true;
            ToolbarName.Text = book.Name;

            editBook.CoverImage.IsReadOnly = true;
            editBook.Name.IsReadOnly = true;
            editBook.Description.IsReadOnly = true;
            editBook.Status.IsEnabled = false;      
            editBook.Author.IsReadOnly = true;
            editBook.Date.IsEnabled = false;
            editBook.PageCount.IsReadOnly = true;

            editBook.BrowseImage.Visibility = Visibility.Hidden;
            editBook.AddButton.Visibility = Visibility.Hidden;
            editBook.CancelButton.Visibility = Visibility.Hidden;
            AddButton.Visibility = Visibility.Hidden;
        }
    }
}
