using System;
namespace MercadoPago.DataStructures.Plan
{
    public struct FreeTrial
    {
        #region Properties

        private int frequency;
        private string frequencyType;

        #endregion

        #region Accessors
        public int Frequency 
        { 
            get { return  frequency; } 
            set {  frequency = value; } 
        }
        public string FrequencyType 
        { 
            get { return  frequencyType; } 
            set {  frequencyType = value; } 
        }
        #endregion

    }
}
