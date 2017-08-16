﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Time;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class representing a partial date (eg. only year and month).
    /// </summary>
    [JsonConverter(typeof(EssentialsPartialDateConverter))]
    public class EssentialsPartialDate {

        #region Properties

        /// <summary>
        /// Gets the year, or <code>0</code> if not specified.
        /// </summary>
        public int Year { get; private set; }
        
        /// <summary>
        /// Gets the month, or <code>0</code> if not specified.
        /// </summary>
        public int Month { get; private set; }
        
        /// <summary>
        /// Gets the day, or <code>0</code> if not specified.
        /// </summary>
        public int Day { get; private set; }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> representing the publication date. This instance will not be
        /// realiable in the way that an instance of <see cref="DateTime"/> can't represent a partial date.
        /// </summary>
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// Gets whether a year has been specified for this date.
        /// </summary>
        public bool HasYear {
            get { return Year > 0; }
        }
        
        /// <summary>
        /// Gets whether a month has been specified for this date.
        /// </summary>
        public bool HasMonth {
            get { return Month > 0; }
        }
        
        /// <summary>
        /// Gets whether a day has been specified for this date.
        /// </summary>
        public bool HasDay {
            get { return Day > 0; }
        }
        
        /// <summary>
        /// Gets whether the date is partial (missing either year, month or day).
        /// </summary>
        public bool IsPartialDate {
            get { return !(HasYear && HasMonth && HasDay); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <code>date</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the full date.</param>
        public EssentialsPartialDate(DateTime date) {
            Year = date.Year;
            Month = date.Month;
            Day = date.Day;
            DateTime = new DateTime(Year, Month, Day);
        }

        /// <summary>
        /// Initializes a new instance from the specified <code>date</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTimeOffset"/> representing the full date.</param>
        public EssentialsPartialDate(DateTimeOffset date) {
            Year = date.Year;
            Month = date.Month;
            Day = date.Day;
            DateTime = new DateTime(Year, Month, Day);
        }

        /// <summary>
        /// Initializes a new instance from the specified <code>date</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="EssentialsDateTime"/> representing the full date.</param>
        public EssentialsPartialDate(EssentialsDateTime date) {
            Year = date == null ? 0 : date.Year;
            Month = date == null ? 0 : date.Month;
            Day = date == null ? 0 : date.Day;
            DateTime = new DateTime(Year == 0 ? 1 : Year, Month == 0 ? 1 : Month, Day == 0 ? 1 : Day);
        }

        /// <summary>
        /// Initializes a new instance from the specified <code>year</code>.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        public EssentialsPartialDate(int year) {
            Year = Math.Max(0, year);
            DateTime = new DateTime(Year == 0 ? 1 : Year, Month == 0 ? 1 : Month, Day == 0 ? 1 : Day);
        }

        /// <summary>
        /// Initializes a new instance from the specified <code>year</code> and <code>month</code>.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        /// <param name="month">The month of the date.</param>
        public EssentialsPartialDate(int year, int month) {
            Year = Math.Max(0, year);
            Month = Math.Max(0, month);
            DateTime = new DateTime(Year == 0 ? 1 : Year, Month == 0 ? 1 : Month, Day == 0 ? 1 : Day);
        }

        /// <summary>
        /// Initializes a new instance from the specified <code>year</code>, <code>month</code> and <code>day</code>.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        /// <param name="month">The month of the date.</param>
        /// <param name="day">The day of the date.</param>
        public EssentialsPartialDate(int year, int month, int day) {
            Year = Math.Max(0, year);
            Month = Math.Max(0, month);
            Day = Math.Max(0, day);
            DateTime = new DateTime(Year == 0 ? 1 : Year, Month == 0 ? 1 : Month, Day == 0 ? 1 : Day);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a string representation of the partial date in the format of <code>yyyy-MM-dd</code>.
        /// </summary>
        /// <returns>A string that represents the partial date.</returns>
        public override string ToString() {
            return String.Format("{0:0000}-{1:00}-{2:00}", Year, Month, Day);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to its <see cref="EssentialsPartialDate"/>
        /// equivalent.
        /// </summary>
        /// <param name="input">A string that contains the partial date to convert.</param>
        /// <returns>An instance of <see cref="EssentialsPartialDate"/> representing the converted partial date.</returns>
        public static EssentialsPartialDate Parse(string input) {

            if (String.IsNullOrWhiteSpace(input)) return null;

            EssentialsPartialDate date;
            if (TryParse(input, out date)) return date;

            throw new ArgumentException("Specified string is not a valid date\r\n\r\n--" + input + "--", "input");

        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to its <see cref="EssentialsPartialDate"/>
        /// equivalent.
        /// </summary>
        /// <param name="input">A string that contains the partial date to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="input"/>.</param>
        /// <returns>An instance of <see cref="EssentialsPartialDate"/> representing the converted partial date.</returns>
        public static EssentialsPartialDate Parse(string input, IFormatProvider provider) {

            if (String.IsNullOrWhiteSpace(input)) return null;

            EssentialsPartialDate date;
            if (TryParse(input, provider, out date)) return date;

            throw new ArgumentException("Specified string is not a valid date\r\n\r\n--" + input + "--", "input");

        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to its <see cref="EssentialsPartialDate"/>
        /// equivalent and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <param name="result">When this method returns, contains the <see cref="EssentialsPartialDate"/> value
        /// equivalent to the partial date and time contained in <paramref name="input"/>, if the conversion succeeded,
        /// or <code>null</code> if the conversion failed. The conversion fails if <paramref name="input"/> is
        /// <code>null</code>, is an empty string (""), or does not contain a valid string representation of a partial
        /// date. This parameter is passed uninitialized.</param>
        /// <returns><code>true</code> if <paramref name="input"/> was converted successfully; otherwise, <code>false</code>.</returns>
        public static bool TryParse(string input, out EssentialsPartialDate result) {
            return TryParse(input, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to its <see cref="EssentialsPartialDate"/>
        /// equivalent and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="input"/>.</param>
        /// <param name="result">When this method returns, contains the <see cref="EssentialsPartialDate"/> value
        /// equivalent to the partial date and time contained in <paramref name="input"/>, if the conversion succeeded,
        /// or <code>null</code> if the conversion failed. The conversion fails if <paramref name="input"/> is
        /// <code>null</code>, is an empty string (""), or does not contain a valid string representation of a partial
        /// date. This parameter is passed uninitialized.</param>
        /// <returns><code>true</code> if <paramref name="input"/> was converted successfully; otherwise, <code>false</code>.</returns>
        public static bool TryParse(string input, IFormatProvider provider, out EssentialsPartialDate result) {

            // Initialize "date"
            result = null;

            // Strip all commas to make parsing easier
            input = (input ?? "").Replace(",", "");

            // Parse the string into an instance of DateTime for full dates
            DateTime dt;
            if (DateTime.TryParseExact(input, new[] { "yyyy-MM-dd", "d MMMM yyyy", "MMMM d yyyy" }, provider, DateTimeStyles.None, out dt)) {
                result = new EssentialsPartialDate(dt);
                return true;
            }

            // Match various formats
            Match m1 = Regex.Match(input, "^([0-9]{4})$");
            Match m2 = Regex.Match(input, "^([0-9]{4})-([0-9]{2})$");
            Match m3 = Regex.Match(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$");
            Match m4 = Regex.Match(input, "^([a-zA-Z]+) ([0-9]{4})$");
            Match m6 = Regex.Match(input, "^([a-zA-Z]+) ([0-9]{1,2})(st|nd|rd|th) ([0-9]{4})$");
            
            if (m1.Success) result = new EssentialsPartialDate(Int32.Parse(m1.Groups[1].Value));
            if (m2.Success) result = new EssentialsPartialDate(Int32.Parse(m2.Groups[1].Value), Int32.Parse(m2.Groups[2].Value));
            if (m3.Success) result = new EssentialsPartialDate(Int32.Parse(m3.Groups[1].Value), Int32.Parse(m3.Groups[2].Value), Int32.Parse(m3.Groups[3].Value));

            if (m4.Success) {
                int month;
                if (!TimeUtils.TryParseNumberFromMonthName(m4.Groups[1].Value, provider, out month)) return false;
                int year = Int32.Parse(m4.Groups[2].Value);
                result = new EssentialsPartialDate(year, month);
                return true;
            }

            if (m6.Success) {
                int month;
                if (!TimeUtils.TryParseNumberFromMonthName(m6.Groups[1].Value, provider, out month)) return false;
                int year = Int32.Parse(m6.Groups[4].Value);
                int day = Int32.Parse(m6.Groups[2].Value);
                result = new EssentialsPartialDate(year, month, day);
                return true;
            }

            return result != null;

        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsPartialDate"/> from the specified <code>timestamp</code>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="DateTime"/>.</param>
        /// <returns>Returns an instance of <see cref="EssentialsPartialDate"/>.</returns>
        public static implicit operator EssentialsPartialDate(DateTime timestamp) {
            return new EssentialsPartialDate(timestamp);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsPartialDate"/> from the specified <code>timestamp</code>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="DateTimeOffset"/>.</param>
        /// <returns>Returns an instance of <see cref="EssentialsPartialDate"/>.</returns>
        public static implicit operator EssentialsPartialDate(DateTimeOffset timestamp) {
            return new EssentialsPartialDate(timestamp);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsPartialDate"/> from the specified <code>timestamp</code>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns>Returns an instance of <see cref="EssentialsPartialDate"/>.</returns>
        public static implicit operator EssentialsPartialDate(EssentialsDateTime timestamp) {
            return new EssentialsPartialDate(timestamp);
        }

        #endregion

    }

}