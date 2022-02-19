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
    internal class DateAnalyzerViewModel
    {
        #region Fields
        private readonly User _user = new User();
        private RelayCommand<object> _exitCommand;
        private RelayCommand<object> _analyzeCommand;
        private RelayCommand<object> _clearCommand;
        private string _age = null;
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
            }, 
            _ => DateOfBirth != null);
        }
        public RelayCommand<object> ClearCommand
        {
            get => _clearCommand ??= new RelayCommand<object>(_ =>
            {
                DateOfBirth = null;
            });
        }
        public DateTime? DateOfBirth
        {
            get => _user.DateOfBirth;
            set => _user.DateOfBirth = value;
        }
        public string Age
        {
            //get => "Your Age :\n" + _user.Age ?? "";
            get => _age ?? "";
            set => _age = "" + _user.Age;
        }
       
        public string WesternZodiacSign
        {
            get
            {
                User.WesternZodiac? tmp = _user.WesternZodiacSign;
                return "Western Zodiac:\n" + (tmp == null ? "" : Enum.GetName(typeof(User.WesternZodiac), tmp));
            }
        }

        public string ChineseZodiacSign
        {
            get 
            {
                User.ChineseZodiac? tmp = _user.ChineseZodiacSign;
                return "Chinese Zodiac:\n" + (tmp == null ? "" : Enum.GetName(typeof(User.ChineseZodiac), tmp)); 
            }
        }
        #endregion
    }
}
