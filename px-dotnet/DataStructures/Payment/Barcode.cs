using System;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Payment
{
    /// <summary>
    /// Barcode information.
    /// </summary>
    public struct Barcode
    {
        #region Properties 
        private EncodingType? _encoding_type;
        private string _content;
        private int? width;
        private int? height;
        #endregion

        #region Accessors

        /// <summary>
        /// Encoding type.
        /// </summary>
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

        /// <summary>
        /// Content.
        /// </summary>
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

        /// <summary>
        /// Width.
        /// </summary>
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

        /// <summary>
        /// Height.
        /// </summary>
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
