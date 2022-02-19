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
        private short? _age;
        private WesternZodiac? _westernSign;
        private ChineseZodiac? _chineseSign;
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
            //get => _age;
            //set => _age = getAge();
            get => getAge();
        }
        public WesternZodiac? WesternZodiacSign
        {
            get => _westernSign;
            set => _westernSign = getWesternZodiacSign();
        }

        public ChineseZodiac? ChineseZodiacSign
        {
            get => _chineseSign;
            set => _chineseSign = getChineseZodiacSign();
        }
        #endregion

        #region Methods
        private short? getAge()
        {
            //return 10;
            //return _dateOfBirth == null ? null : (short)(DateTime.Now.Year - _dateOfBirth.Value.Year +
            //                       (DateTime.Now.Month >= _dateOfBirth.Value.Month &&
            //                        DateTime.Now.Day >= _dateOfBirth.Value.Day ? 0 : -1));
            if (DateOfBirth == null) return null;

            return (short)(DateTime.Now.Year - _dateOfBirth.Value.Year + ((DateTime.Now.Month >= _dateOfBirth.Value.Month &&
                                                                           DateTime.Now.Day >= _dateOfBirth.Value.Day) ||
                                                                          DateTime.Now.Year == _dateOfBirth.Value.Year ? 0 : -1));
        }
        private WesternZodiac? getWesternZodiacSign()
        {
            return WesternZodiac.Gemini;
        }

        private ChineseZodiac? getChineseZodiacSign()
        {
            return 0;
        }
        #endregion

    }
}
