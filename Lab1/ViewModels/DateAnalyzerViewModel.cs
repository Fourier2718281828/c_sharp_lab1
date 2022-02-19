using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Lab1.Models;
using Lab1.Tools;

namespace Lab1.ViewModels
{
    internal class DateAnalyzerViewModel : BindedObject
    {
        #region Fields
        private User _user = new User();
        private RelayCommand<object> _exitCommand;
        private RelayCommand<object> _analyzeCommand;
        private RelayCommand<object> _clearCommand;
        #endregion

        #region Properties
        public RelayCommand<object> ExitCommand
        {
            get => _exitCommand ??= new RelayCommand<object>(_ => Environment.Exit(0)); 
        }
        public RelayCommand<object> AnalyzeCommand
        {
            get => _analyzeCommand ??= new RelayCommand<object>(_ =>
            {
                Age = null;
                WesternZodiacSign = null;
                ChineseZodiacSign = null;
            }, 
            _ => DateOfBirth != null);
        }
        public RelayCommand<object> ClearCommand
        {
            get => _clearCommand ??= new RelayCommand<object>(_ =>
            {
                DateOfBirth = null;
            },
            _ => DateOfBirth != null);
        }
        public DateTime? DateOfBirth
        {
            get => _user.DateOfBirth;
            set
            {
                _user.DateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }
        public string Age
        {
            get => "Your Age: " + _user.Age ?? "";
            set
            {
                //_user.Age = 0;
                OnPropertyChanged();
            }
        }
       
        public string WesternZodiacSign
        {
            get
            {
                User.WesternZodiac? tmp = _user.WesternZodiacSign;
                return "Western Zodiac:\n" + (tmp == null ? "" : Enum.GetName(typeof(User.WesternZodiac), tmp));
            }
            set
            {
                _user.WesternZodiacSign = 0;
                OnPropertyChanged();
            }
        }

        public string ChineseZodiacSign
        {
            get 
            {
                User.ChineseZodiac? tmp = _user.ChineseZodiacSign;
                return "Chinese Zodiac:\n" + (tmp == null ? "" : Enum.GetName(typeof(User.ChineseZodiac), tmp)); 
            }
            set
            {
                _user.ChineseZodiacSign = 0;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
