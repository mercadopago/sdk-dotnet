using System;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Payment
{
    public struct Barcode
    {
        #region Properties 
        private EncodingType? _encoding_type;
        private string _content;
        private int? width;
        private int? height;
        #endregion

        #region Accessors 
        public EncodingType? Encoding_type
        {
            get
            {
                return _encoding_type;
            }

            set
            {
                _encoding_type = value;
            }
        }
        public string Content
        {
            get
            {
                return _content;
            }

            set
            {
                _content = value;
            }
        }
        public int? Width {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }
        public int? Height 
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }


        #endregion
    }
}
