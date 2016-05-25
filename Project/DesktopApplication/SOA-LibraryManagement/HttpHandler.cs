using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Windows;
namespace LibraryManagement
{
    class HttpHandler
    {
        System.Windows.Controls.UserControl parrent;
        public event EventHandler<GenericEventArgs<HttpWebResponse>> RequestCompleted;
        public static string APIUrl = "http://uetlib.herokuapp.com/api/books";
        public static string UploadImageUrl = "http://uploads.im/api?upload";
        Dictionary<string, string> parameters;

        public HttpHandler(Dictionary<string, string> parameters, System.Windows.Controls.UserControl parrent)
        {
            this.parameters = parameters;
            this.parrent = parrent;
        }

        public void LoadBook()
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(APIUrl) as HttpWebRequest;
                request.ContentType = "application/json; charset=utf-8";
                request.Method = "GET";
                Task.Factory.StartNew(() => ProcessRequest(request));
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message, "Network error");
                Debug.WriteLine(ex.Message);
                hideProgressBarInParrent();
            }
        }

        public void AddBook()
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(APIUrl) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message, "Network error");
                Debug.WriteLine(ex.Message);
                hideProgressBarInParrent();
            }

        }

        public void EditBook(int bookId)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(APIUrl + '/' + bookId.ToString()) as HttpWebRequest;
                request.Method = "PUT";
                request.ContentType = "application/json; charset=utf-8";
                request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message, "Network error");
                hideProgressBarInParrent();
            }

        }

        public void DeleteBook(int bookId)
        {
            HttpWebRequest request = WebRequest.Create(APIUrl + '/' + bookId.ToString()) as HttpWebRequest;
            request.ContentType = "application/json; charset=utf-8";
            request.Method = "DELETE";

            Task.Factory.StartNew(() => ProcessRequest(request));
        }

        private HttpWebResponse ProcessRequest(HttpWebRequest request)
        {
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                OnRequestCompleted(response);
                return response;
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message, "Network error");
                Debug.WriteLine(ex.Message);
                hideProgressBarInParrent();
                return null;
            }
        }

        protected void OnRequestCompleted(HttpWebResponse response)
        {
            if (null != RequestCompleted)
                RequestCompleted(this, new GenericEventArgs<HttpWebResponse>(response));
        }

        private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

                // End the operation
                Stream postStream = request.EndGetRequestStream(asynchronousResult);

                var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
                var jsonString = jss.Serialize(parameters);

                //string jsonString = parameters.FromDictionaryToJson();
                var data = Encoding.UTF8.GetBytes(jsonString);
                postStream.Write(data, 0, data.Length);
                postStream.Close();
                Task.Factory.StartNew(() => ProcessRequest(request));
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message, "Network error");
                Debug.WriteLine(ex.Message);
                hideProgressBarInParrent();
            }

        }

        public void hideProgressBarInParrent()
        {
            if (parrent is EditBook)
            {
                ((EditBook)parrent).hideProgressBarAndShowCurrentContent();
            }
            if (parrent is AddBook)
            {
                ((AddBook)parrent).hideProgressBarAndShowCurrentContent();
            }
            if (parrent is Card)
            {
                ((Card)parrent).hideProgressBarAndShowCurrentContent();
            }
        }
    }
}
