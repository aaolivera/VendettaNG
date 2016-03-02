﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Dominio.Recursos;

namespace VendettaNG.Helpers
{
    public static class FormattingHtmlHelper
    {
        public static string ClientDateFormat(this HtmlHelper htmlHelper)
        {
            var currentFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

            //Convert the date
            currentFormat = currentFormat.Replace("dddd", "DD");
            currentFormat = currentFormat.Replace("ddd", "D");

            //Convert month
            if (currentFormat.Contains("MMMM"))
            {
                currentFormat = currentFormat.Replace("MMMM", "MM");
            }
            else if (currentFormat.Contains("MMM"))
            {
                currentFormat = currentFormat.Replace("MMM", "M");
            }
            else if (currentFormat.Contains("MM"))
            {
                currentFormat = currentFormat.Replace("MM", "mm");
            }
            else
            {
                currentFormat = currentFormat.Replace("M", "m");
            }

            //Convert year

            currentFormat = currentFormat.Contains("yyyy")
                                ? currentFormat.Replace("yyyy", "yy")
                                : currentFormat.Replace("yy", "y");
            return currentFormat;
        }

        public static string Formatted(this DateTime date)
        {
            if (date != DateTime.MinValue)
                return String.Format(CultureInfo.CurrentCulture, "{0:d}", date);
            {
                return String.Empty;
            }
        }

        public static string FormattedFixed(this DateTime date)
        {
            var fecha = String.Format(CultureInfo.CurrentCulture, "{0:d}", date);
            const string er1 = "^[0-9]{1}[^0-9]{1}";
            const string er2 = "[^0-9]{1}[0-9]{1}[^0-9]{1}";
            const string er3 = "[^0-9]{1}[0-9]{1}$";
            Match match = Regex.Match(fecha, er1, RegexOptions.IgnoreCase);
            if (match.Success) fecha = fecha.Insert(match.Index, "0");
            match = Regex.Match(fecha, er2, RegexOptions.IgnoreCase);
            if (match.Success) fecha = fecha.Insert(match.Index + 1, "0");
            match = Regex.Match(fecha, er3, RegexOptions.IgnoreCase);
            if (match.Success) fecha = fecha.Insert(match.Index + 1, "0");

            if (date != DateTime.MinValue)
                return fecha;
            {
                return String.Empty;
            }
        }

        public static string FormattedTime(this DateTime date)
        {
            if (date != DateTime.MinValue)
                return String.Format(CultureInfo.CurrentCulture, "{0:d/M/yyyy HH:mm:ss}", date);
            {
                return String.Empty;
            }
        }

        public static string FormattedPdf(this DateTime date)
        {
            if (date != DateTime.MinValue)
                return date.ToString("MMM  d, yyyy");
            {
                return String.Empty;
            }
        }

        public static string Formatted(this DateTime? date)
        {
            if (date.HasValue && date.Value != DateTime.MinValue)
                return String.Format(CultureInfo.CurrentCulture, "{0:d}", date);
            {
                return String.Empty;
            }
        }

        public static string Formatted(this Decimal number)
        {
            return String.Format(CultureInfo.CurrentCulture, "{0:0.00}", number);
        }

        public static string Formatted(this Decimal? number)
        {
            return number != null ? String.Format(CultureInfo.CurrentCulture, "{0:0.00}", number) : "";
        }

        public static string FormattedOneDecimal(this Decimal number)
        {
            return String.Format(CultureInfo.CurrentCulture, "{0:0.0}", number);
        }

        public static string FormattedOneDecimal(this Decimal? number)
        {
            return number != null ? String.Format(CultureInfo.CurrentCulture, "{0:0.0}", number) : "";
        }

        public static string FormattedOneDecimal(this int number)
        {
            return String.Format(CultureInfo.CurrentCulture, "{0:0.0}", number);
        }

        public static string FormattedOneDecimal(this int? number)
        {
            return number != null ? String.Format(CultureInfo.CurrentCulture, "{0:0.0}", number) : "";
        }

        public static string FormattedOneDecimalThousandSeparator(this Decimal number)
        {
            return String.Format(CultureInfo.CurrentCulture, "{0:#,0.0}", number);
        }

        public static string FormattedOneDecimalThousandSeparator(this Decimal? number)
        {
            return number != null ? String.Format(CultureInfo.CurrentCulture, "{0:#,0.0}", number) : "";
        }

        public static string FormattedThousandSeparator(this Decimal number)
        {
            return String.Format(CultureInfo.CurrentCulture, "{0:0,0}", number);
        }


        public static string Formatted(this bool value)
        {
            return value ? Textos.Si : Textos.No;
        }

        public static string WrapIfLong(this string value)
        {
            var res = "";
            var words = value.Split(' ');
            foreach (var v in words)
            {
                if (v.Length > 18)
                {
                    var word = v;
                    while (word.Length > 18)
                    {
                        res = res + word.Substring(0, 18) + " ";
                        word = word.Substring(18, v.Length - 18);
                    }
                    res = res + word + " ";
                }
                else
                {
                    res = res + v + " ";
                }
            }
            return res;
        }
    }
}
