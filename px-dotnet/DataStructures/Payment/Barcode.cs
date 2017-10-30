using System;
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
        public EncodingType? Encoding_type { 
            get => _encoding_type; 
            set => _encoding_type = value; 
        }
        public string Content { 
            get => _content; 
            set => _content = value; 
        }
        public int? Width { 
            get => width; 
            set => width = value; 
        }
        public int? Height { 
            get => height; 
            set => height = value; 
        }
        #endregion
    }
}
