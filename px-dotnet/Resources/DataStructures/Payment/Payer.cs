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

        private Type type;
        private string id;
        private string email;
        private Identification identification;
        private PayerPhone payerPhone;
        private string firstName;
        private string lastName;

        #endregion

        #region Accesors

        public Type Type
        {
            get { return type; }
            set { type = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Identification Identification
        {
            get { return identification; }
            set { identification = value; }
        }

        public PayerPhone PayerPhone
        {
            get { return payerPhone; }
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        #endregion
    }
}
