namespace Day02.BL
{
    class Password
    {
        private int _min;
        private int _max;
        private char _letter;
        private string _password;
        private bool? _isValid = null; 
        private bool? _isStrictValid = null;

        public bool IsValid {
            get
            {
                if (_isValid == null)
                {
                    int count = 0;
                    foreach (char ch in _password)
                    {
                        if (ch == _letter)
                            count++;
                    }
                    if (count >= _min && count <= _max)
                        _isValid = true;
                    else
                        _isValid = false;
                }

                return (bool)_isValid;
            }
        }

        public bool IsStrictValid
        {
            get
            {
                if (_isStrictValid == null)
                    _isStrictValid = (_password[_min - 1] == _letter) != (_password[_max - 1] == _letter);

                return (bool)_isStrictValid;
            }
        }

        public Password(string rawData)
        {
            Prepare(rawData);
        }

        private void Prepare(string rawdata)
        {
            var result = rawdata.Split(":");
            _password = result[1].Trim();
            _letter = result[0].Split(" ")[1].Trim()[0];
            var minmax = result[0].Split(" ")[0];
            _min = int.Parse(minmax.Split("-")[0]);
            _max = int.Parse(minmax.Split("-")[1]);
        }
    }
}
