using System;
namespace MercadoPago.DataStructures.Generic
{
    public struct BadParamsError
    {

        #region Properties
        private string _message;
        private string _error;
        private int _status;
        private BadParamsCause[] _cause; 
        #endregion

        #region Accessors 
        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
            }
        }

        public string Error
        {
            get
            {
                return _error;
            }

            set
            {
                _error = value;
            }
        }

        public int Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

        public BadParamsCause[] Cause
        {
            get
            {
                return _cause;
            }

            set
            {
                _cause = value;
            }
        }
        #endregion
    }
}
