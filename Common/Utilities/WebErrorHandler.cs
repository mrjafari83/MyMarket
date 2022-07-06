using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class WebErrorHandler
    {
        public static int GetStatusCodeError(Exception exception)
        {
            if(exception != null)
            {
                if (exception is HttpRequestException)
                    return 2;
                if (exception is SqlException)
                    return 3;
                if (exception is DirectoryNotFoundException || exception is FileNotFoundException)
                    return 4;
                if (exception is ArgumentException || exception is ArgumentNullException || exception is ArgumentOutOfRangeException)
                    return 5;
            }

            return 1;
        }
    }
}
