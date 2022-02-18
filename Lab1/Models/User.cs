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
            return _dateOfBirth == null ? null : (short)(DateTime.Now.Year - _dateOfBirth.Value.Year + 
                                   (DateTime.Now.Month >= _dateOfBirth.Value.Month && 
                                    DateTime.Now.Day >= _dateOfBirth.Value.Day ? 0 : -1));
        }
        private WesternZodiac? getWesternZodiacSign()
        {
            return null;
        }

        private ChineseZodiac? getChineseZodiacSign()
        {
            return null;
        }
        #endregion

    }
}
