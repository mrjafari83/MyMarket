using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class CookiesManager
    {
        public static void AddCookie(HttpContext context , string token , string value)
        {
            context.Response.Cookies.Append(token, value);
        }

        public static void AddCookieHttpOnly(HttpContext context, string token, string value)
        {
            context.Response.Cookies.Append(token, value , new CookieOptions { HttpOnly = true });
        }

        public static string GetCookieValue(HttpContext context , string token)
        {
            string cookieValue;
            if (context.Request.Cookies.TryGetValue(token, out cookieValue))
                return cookieValue;

            return "";
        }

        public static bool ContainCookie(HttpContext context , string token)
        {
            return context.Request.Cookies.ContainsKey(token);
        }
    }
}
