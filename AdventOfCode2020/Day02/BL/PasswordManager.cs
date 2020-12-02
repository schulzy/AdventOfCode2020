using System.Collections.Generic;

namespace Day02.BL
{
    class PasswordManager
    {
        private int _validPassword = -1;
        private int _validStrictPassword = -1;
        public List<Password> Passwords { get; set; } = new List<Password>();
        
        public int ValidPassword 
        {
            get
            {
                if(_validPassword == -1)
                {
                    _validPassword = 0;
                    foreach (var pwd in Passwords)
                    {
                        if (pwd.IsValid)
                            _validPassword++;
                    }
                }

                return _validPassword;
            }
        }

        public int ValidStrictPassword
        {
            get
            {
                if (_validStrictPassword == -1)
                {
                    _validStrictPassword = 0;
                    foreach (var pwd in Passwords)
                    {
                        if (pwd.IsStrictValid)
                            _validStrictPassword++;
                    }
                }

                return _validStrictPassword;
            }
        }

        public PasswordManager()
        {
            DataProcessor dataProcessor = new DataProcessor();
            foreach (var rawData in dataProcessor.GetData())
            {
                Passwords.Add(new Password(rawData));
            }
            
        }


    }
}
