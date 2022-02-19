using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                if (_user.HasBirthday) MessageBox.Show("Happy Birthday!");
            }, 
            _ => DateOfBirth != null);
        }
        public RelayCommand<object> ClearCommand
        {
            get => _clearCommand ??= new RelayCommand<object>(_ =>
            {
                DateOfBirth = null;
                Age = null;
                WesternZodiacSign = null;
                ChineseZodiacSign = null;
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
            get
            {
                if(!_user.HasCorrectDate)
                {
                    MessageBox.Show("Unacceptable date input!");
                    return "Your Age: ";
                }
                return "Your Age: " + _user.Age ?? "";
            }
            set => OnPropertyChanged(nameof(Age));
        }
       
        public string WesternZodiacSign
        {
            get
            {
                User.WesternZodiac? tmp = _user.WesternZodiacSign;
                return (tmp == null ? "" : Enum.GetName(typeof(User.WesternZodiac), tmp));
            }
            set => OnPropertyChanged(nameof(WesternZodiacSign));
        }

        public string ChineseZodiacSign
        {
            get 
            {
                User.ChineseZodiac? tmp = _user.ChineseZodiacSign;
                return (tmp == null ? "" : Enum.GetName(typeof(User.ChineseZodiac), tmp)); 
            }
            set => OnPropertyChanged(nameof(ChineseZodiacSign));
        }
        #endregion
    }
}
