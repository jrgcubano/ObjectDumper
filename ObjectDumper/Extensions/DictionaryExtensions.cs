namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        public static void AddIfNotNull(this IDictionary<string, Delegate> dictionary, string key, Delegate value)
        {
            if (!string.IsNullOrEmpty(key))
            {
                dictionary.Add(key, value);
            }
        }
    }
}
