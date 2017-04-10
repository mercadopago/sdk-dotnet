using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class Source
    {
        #region Properties        

        private string id;
        private string name;
        private Type type;
        public enum Type
        {
            Collector,
            Operator,
            Admin,
            Bpp
        }

        #endregion

        #region Accessors

        public string ID
        {
            get { return id; }            
        }
        
        public string Name
        {
            get { return name; }            
        }        
       
        public Type SourceType
        {
            get { return type; }
        }

        #endregion
    }
}
