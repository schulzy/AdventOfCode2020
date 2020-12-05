using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day04.BL
{
    internal class PassportManager
    {
        private List<Passport> _passports = new List<Passport>();
        private Passport _curretPassport;

        public int ValidCount()
        {
            int validCount = 0;
            foreach (var passport in _passports)
            {
                if (passport.IsValid())
                    validCount++;
                
            }
            return validCount;
        }
        
        public int StrictValid()
        {
            int validCount = 0;
            foreach (var passport in _passports)
            {
                if (passport.IsValid() && passport.StrictValid)
                    validCount++;
            }
            return validCount;
        }

        public void AddLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line) || _curretPassport == null)
            {
                _curretPassport = new Passport();
                _passports.Add(_curretPassport);
                return;
            }

            ParseLine(line);
        }

        private void ParseLine(string line)
        {
            var keyValues = line.Split(" ");
            foreach (var item in keyValues)
            {
                var prop = item.Split(":");

                switch (prop[0])
                {
                    case "byr":
                        {
                            if (!(int.TryParse(prop[1], out int num) && num >= 1920 && num <= 2002))
                                _curretPassport.StrictValid = false;
                            _curretPassport.BirthYear = prop[1];
                            break;
                        }
                    case "iyr":
                        {
                            if (!(int.TryParse(prop[1], out int num) && num >= 2010 && num <= 2020))
                                _curretPassport.StrictValid = false;
                            _curretPassport.IssueYear = prop[1];
                        }
                        break;
                    case "eyr":
                        {
                            if (!(int.TryParse(prop[1], out int num) && num >= 2020 && num <= 2030))
                                _curretPassport.StrictValid = false;
                            _curretPassport.ExpirationYear = prop[1];
                            break;
                        }
                    case "hgt":
                        {
                            if (prop[1].EndsWith("cm"))
                            { 
                                if(!(int.TryParse(prop[1].Replace("cm",""), out int hight) && hight>=150 && hight <=193))
                                    _curretPassport.StrictValid = false;
                            }
                            else if (prop[1].EndsWith("in"))
                            {
                                if (!(int.TryParse(prop[1].Replace("in", ""), out int hight) && hight >= 59 && hight <= 76))
                                    _curretPassport.StrictValid = false;
                            }
                            else
                                _curretPassport.StrictValid = false;

                            _curretPassport.Height = prop[1];
                            break;
                        }
                    case "hcl":
                        {
                            Regex regex = new Regex("^#(?:[0-9a-fA-F]{3}){1,2}$");
                            if(!regex.IsMatch(prop[1]))
                                _curretPassport.StrictValid = false;
                            _curretPassport.HairColor = prop[1];
                            break;
                        }
                    case "ecl":
                        {
                            List<string> colors = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                            if(!colors.Contains(prop[1]))
                                _curretPassport.StrictValid = false;
                            _curretPassport.EyeColor = prop[1];
                            break;
                        }
                    case "pid":
                        if(!(prop[1].Length == 9 && int.TryParse(prop[1], out _)))
                            _curretPassport.StrictValid = false;
                        _curretPassport.PassportID = prop[1];
                        break;
                    case "cid":
                        _curretPassport.CountryID = prop[1];
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
