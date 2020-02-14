using System;
using System.Collections.Generic;

class DictionaryEnumerator
{
    static void Main()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("Hola", "Hello");
        dic["Adios"] = "Good bye";
        dic["Hasta luego"] = "See you later";
        dic["Tarde"] = "Late";
        dic["Pronto"] = "Soon";
        dic["Ayer"] = "Yesterday";
        
        IEnumerator<KeyValuePair<string, string>> myEnumerator =
            dic.GetEnumerator();
        while (myEnumerator.MoveNext())
        {
            Console.WriteLine(myEnumerator.Current.Key + " -> " +
                myEnumerator.Current.Value);
        }

        Console.WriteLine();
        foreach (KeyValuePair<string, string> entry in dic)
        {
            Console.WriteLine("{0} --> {1}", entry.Key, entry.Value);
        }
    }
}
