using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Reflection; 
using MercadoPago;

namespace MercadoPagoExample
{
    public static class Utils
    {
        public static string Prompt(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }

        public static void SetEnvVarsFromAppConfig()
        {
            SetIfNotExist("ACCESS_TOKEN", ConfigurationManager.AppSettings["ACCESS_TOKEN"]);
            SetIfNotExist("CLIENT_ID", ConfigurationManager.AppSettings["CLIENT_ID"]);
            SetIfNotExist("CLIENT_SECRET", ConfigurationManager.AppSettings["CLIENT_SECRET"]);

        }

        private static void SetIfNotExist(string key, string value)
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(key))) {
                Environment.SetEnvironmentVariable(key, value);
            };

        }

        public static int ShowMenu(NameValueCollection collection)
        {
            Console.Clear();
            Console.WriteLine("\nChoose an Option: \n");
            int i = 0;

            foreach (string item in collection.Keys) {
                Console.WriteLine( "\t" + i + ' ' + collection[item]);
                i++;
            }

            Console.WriteLine("\n");

            var selection = Console.ReadLine();
            int n = int.Parse(selection);

            return n;
        }
      
        public static NameValueCollection LoadExamples()
        {
            var activeExamples = ConfigurationManager.GetSection("activeExamples") as NameValueCollection;
            return activeExamples;
        }

        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => t.Namespace.Contains(nameSpace))
                      .ToArray();
        }

        public static NameValueCollection LoadExamplesFromNamespace(string namespaceName) {
            
            NameValueCollection typesCollection = new NameValueCollection();

            Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), namespaceName);


            for (int i = 0; i < typelist.Length; i++)
            {
                IExample instance = (IExample)Activator.CreateInstance(typelist[i]); 
                typesCollection.Add(typelist[i].FullName, instance.Name);
            }

            return typesCollection;
        }




    }


}