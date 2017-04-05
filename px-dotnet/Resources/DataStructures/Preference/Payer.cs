using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Preference
{
    public class Payer
    {
        #region Properties

        [StringLength(256)]
        private string name { get; set; }
        [StringLength(256)]
        private string surname { get; set; }
        [StringLength(256)]
        private string email { get; set; }
        private Phone phone { get; set; }
        private Identification identification { get; set; }
        private DateTime dateCreated { get; set; }
        
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
