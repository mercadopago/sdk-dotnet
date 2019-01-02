using System;
namespace MercadoPago.DataStructures.Generic
{
    public struct BadParamsCause
    {
        #region Properties
        private string _code;
        private string _description;
        private string _data; 
        #endregion

        #region Accessors
        public string Code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public string Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }
        #endregion
    }
}
