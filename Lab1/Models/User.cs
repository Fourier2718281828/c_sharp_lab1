using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models
{
    internal class User
    {
        #region Fields
        private DateTime? _dateOfBirth = null;
        #endregion

        #region ZodiacSigns
        public enum WesternZodiac
        { 
            Aries, Taurus, Gemini, Cancer, Leo, Virgo, Libra, Scorpio, Sagittarius, Capricorn, Aquarius, Pisces 
        }
        public enum ChineseZodiac
        {
            Rat, Ox, Tiger, Rabbit, Dragon, Snake, Horse, Goat, Monkey, Rooster, Dog, Pig
        }

        private enum Month
        {
            Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
        }
        #endregion

        #region Properties
        public DateTime? DateOfBirth
        {
            get => _dateOfBirth;
            set => _dateOfBirth = value;
        }
        public short? Age
        {
            get => getAge();
        }

        public bool HasCorrectDate
        {
            get => hasCorrectDate();
        }

        public bool HasBirthday 
        {
            get => hasBirthday();
        }
        public WesternZodiac? WesternZodiacSign
        {
            get => getWesternZodiacSign();
        }

        public ChineseZodiac? ChineseZodiacSign
        {
            get => getChineseZodiacSign();
        }
        #endregion

        #region Methods
        private short? getAge()
        {
            if (DateOfBirth == null) return null;
            return (short)(DateTime.Now.Year - _dateOfBirth.Value.Year + ((DateTime.Now.Month >= _dateOfBirth.Value.Month &&
                                                                           DateTime.Now.Day >= _dateOfBirth.Value.Day) ||
                                                                          DateTime.Now.Year == _dateOfBirth.Value.Year ? 0 : -1));
        }

        private bool hasCorrectDate()
        {
            if (_dateOfBirth == null) return true;
            return DateTime.Now >= _dateOfBirth.Value.Date && Age <= 135;
        }
        private bool hasBirthday()
        {
            if (_dateOfBirth == null) return false;
            return (DateTime.Now.Day == _dateOfBirth.Value.Day) && (DateTime.Now.Month == _dateOfBirth.Value.Month);
        }
        private WesternZodiac? getWesternZodiacSign()
        {
            if (DateOfBirth == null) return null;

            if (isIn(Month.Mar, 21, Month.Apr, 19)) return WesternZodiac.Aries;
            if (isIn(Month.Apr, 20, Month.May, 20)) return WesternZodiac.Taurus;
            if (isIn(Month.May, 21, Month.Jun, 21)) return WesternZodiac.Gemini;
            if (isIn(Month.Jun, 22, Month.Jul, 22)) return WesternZodiac.Cancer;
            if (isIn(Month.Jul, 23, Month.Aug, 22)) return WesternZodiac.Leo;
            if (isIn(Month.Aug, 23, Month.Sep, 22)) return WesternZodiac.Virgo;
            if (isIn(Month.Sep, 23, Month.Oct, 22)) return WesternZodiac.Libra;
            if (isIn(Month.Oct, 23, Month.Nov, 22)) return WesternZodiac.Scorpio;
            if (isIn(Month.Nov, 23, Month.Dec, 21)) return WesternZodiac.Sagittarius;
            if (isIn(Month.Dec, 22, Month.Jan, 19)) return WesternZodiac.Capricorn;
            if (isIn(Month.Jan, 20, Month.Feb, 18)) return WesternZodiac.Aquarius;
            if (isIn(Month.Feb, 19, Month.Mar, 20)) return WesternZodiac.Pisces;

            return null;
        }

        private ChineseZodiac? getChineseZodiacSign()
        {
            if (DateOfBirth == null) return null;
            return (ChineseZodiac)((_dateOfBirth.Value.Year - 4) % 12);
        }

        private bool isIn( Month m1, int d1, Month m2, int d2)
        {
            //new DateTime((int)_dateOfBirth.Value.Year, (int)m1, (int)d1) ;
            //return false;
            return _dateOfBirth >= new DateTime(_dateOfBirth.Value.Year, (int)m1, d1)
                && _dateOfBirth <= new DateTime(_dateOfBirth.Value.Year, (int)m2, d2);
        }
        #endregion

    }
}
