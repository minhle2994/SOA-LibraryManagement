using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class Book : ViewModelBase
    {
        private int id;
        private string picture;
        private string name;
        private string description;
        private string author;
        private string status;
        private string publishDate;
        private int pageCount;

        public int Id
        {
            get { return id; }
            set { id = value; NotifyPropertyChanged("Id"); }
        }

        public string Picture
        {
            get { return picture; }
            set { picture = value; NotifyPropertyChanged("Picture"); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }

        public string Description
        {
            get { return description; }
            set { description = value; NotifyPropertyChanged("Description"); }
        }

        public string Author
        {
            get { return author; }
            set { author = value; NotifyPropertyChanged("Author"); }
        }
        public string Status
        {
            get { return status; }
            set { status = value; NotifyPropertyChanged("Status"); }
        }

        public string PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; NotifyPropertyChanged("PublishDate"); }
        }

        public int PageCount
        {
            get { return pageCount; }
            set { pageCount = value; NotifyPropertyChanged("PageCount"); }
        }

        public Book(int id, string picture, string name, string description, string author, string status, string publishDate, int pageCount)
        {
            this.Id = id;
            this.Picture = picture;
            this.Name = name;
            this.Description = description;
            this.Author = author;
            this.Status = status;
            this.PublishDate = publishDate;
            this.PageCount = pageCount;
        }
    }
}
