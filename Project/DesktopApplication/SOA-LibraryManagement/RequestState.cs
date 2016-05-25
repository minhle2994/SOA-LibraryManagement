using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace LibraryManagement
{
    public class RequestState
    {
        public WebRequest webRequest;
        public string errorMessage;

        public RequestState()
        {
            webRequest = null;
            errorMessage = null;
        }
    }
}
