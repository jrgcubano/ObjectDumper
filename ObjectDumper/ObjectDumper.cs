using System.Collections.Generic;

namespace ObjectDumper
{
    public class ObjectDumper<T> : BaseObjectDumper<T, KeyValuePair<string, string>>
    {
        protected override KeyValuePair<string, string> FormatResult(string name, string value)
        {
            return new KeyValuePair<string, string>(name, value);
        }
    }

    //public class ObjectDumper<T> : BaseObjectDumper<T, SimpleFormater>
    //{
    //    protected override SimpleFormater FormatResult(string name, string value)
    //    {
    //        return new SimpleFormater(name, value);
    //    }
    //}
}
