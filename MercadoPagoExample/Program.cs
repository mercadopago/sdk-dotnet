using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Reflection;
using MercadoPago;
using MercadoPagoExample;

namespace MercadoPagoExample
{
    public class MainClass
    { 
        
        public static void Main(string[] args)
        { 

            Utils.SetEnvVarsFromAppConfig();

            while (true) {

                NameValueCollection examples = Utils.LoadExamples();
                int selected_index = Utils.ShowMenu(examples);

                string currentNamespace = typeof(MainClass).Namespace;
     
                examples = Utils.LoadExamplesFromNamespace(examples.GetKey(selected_index));
                selected_index = Utils.ShowMenu(examples);
     
                Type type = Type.GetType(examples.GetKey(selected_index)); 

                IExample instance = (IExample)Activator.CreateInstance(type);
                instance.Run();

            } 
        }
    }

}
