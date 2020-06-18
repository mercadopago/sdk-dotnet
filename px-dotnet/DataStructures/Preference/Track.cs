using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;

namespace MercadoPago.DataStructures.Preference
{
    public struct Track
    {
        #region Properties 
        [StringLength(256)]
        private string _type;
        private JObject _values;
        #endregion

        #region Accessors
        /// <summary>
        /// Track type
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// Track values
        /// </summary>
        public JObject Values
        {
            get { return _values; }
            set { _values = value; }
        }
        #endregion
    }
}
