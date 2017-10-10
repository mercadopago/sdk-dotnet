using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class Payer
    {
        #region Properties

        public enum Type
        {
            Customer,
            Registered,
            Guest
        }

        private string _entity_type;
        private string _type;
        private string _id;
        private string _email;
        private Identification _identification;
        private PayerPhone _phone;
        private string _first_name;
        private string _last_name;

        #endregion

        #region Accesors

        public string entity_type
        {
            get { return _entity_type; }
            set { _entity_type = value; }
        }

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        public Identification identification
        {
            get { return _identification; }
            set { _identification = value; }
        }

        public PayerPhone phone
        {
            get { return _phone; }
            private set { _phone = value; }
        }

        public string first_name
        {
            get { return _first_name; }
            private set { _first_name = value; }
        }

        public string last_name
        {
            get { return _last_name; }
            private set { _last_name = value; }
        }

        #endregion
    }
}
