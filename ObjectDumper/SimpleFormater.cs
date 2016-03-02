namespace ObjectDumper
{
    public class SimpleFormater
    {
        private string _key;
        private string _value;

        public SimpleFormater(string key, string value)
        {
            _key = key;
            _value = value;
        }
        public string Key
        {
            get { return _key; }
        }

        public string Value
        {
            get { return _value; }
        }
    }
}
