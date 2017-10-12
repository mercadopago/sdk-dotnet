using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public class Payer
    {
        #region Properties

        [StringLength(256)]
        private string name;
        [StringLength(256)]
        private string surname;
        [StringLength(256)]
        private string email;
        private Phone phone;
        private Identification identification;
        private DateTime dateCreated;
        
        #endregion        

        #region Accessors

        public string Name 
        {
            get { return this.name; }
            set { this.name = value; } 
        }
        
        public string Surname 
        {
            get { return this.surname; }
            set { this.surname = value; }
        }
        
        public string Email 
        {
            get { return this.email; }
            set { this.email = value; } 
        }
        
        public Phone Phone 
        {
            get { return this.phone; }
            set { this.phone = value; } 
        }
        
        public Identification Identification 
        {
            get { return this.identification; }
            set { this.identification = value; }
        }
        
        public DateTime DateCreated 
        {
            get { return this.dateCreated; }
            set { this.dateCreated = value; }
        }
        
        #endregion
    }
}
