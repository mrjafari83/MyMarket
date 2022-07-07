using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class WebErrorHandler
    {
        public static string GetStatusCodeError(Exception exception)
        {
            if(exception != null)
            {
                if (exception is HttpRequestException)
                    return "سرویس در دسترس نیست.";
                if (exception is CookieException)
                    return "کوکی های شما در دسترس نیست.";
                if (exception is DirectoryNotFoundException || exception is FileNotFoundException)
                    return "فایل مرد نظر یافت نشد.";
                if (exception is ArgumentException || exception is ArgumentNullException || exception is ArgumentOutOfRangeException || exception is NullReferenceException)
                    return "اطلاعات وارد شده معتبر نمی باشد.";
            }

            return "خطایی رخ داده است.";
        }
    }
}
