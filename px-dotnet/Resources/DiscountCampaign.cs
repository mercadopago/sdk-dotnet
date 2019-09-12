using System.Collections.Generic;

namespace MercadoPago.Resources
{
    public class DiscountCampaign : MPBase
    {
        #region Actions

        public static DiscountCampaign Find(float transactionAmount, string payerEmail)
        {
            return Find(transactionAmount, payerEmail, null, WITHOUT_CACHE, null);
        }

        public static DiscountCampaign Find(float transactionAmount, string payerEmail, bool useCache, MPRequestOptions requestOptions)
        {
            return Find(transactionAmount, payerEmail, null, useCache, requestOptions);
        }

        public static DiscountCampaign Find(float transactionAmount, string payerEmail, string couponCode)
        {
            return Find(transactionAmount, payerEmail, couponCode, WITHOUT_CACHE, null);
        }

        [GETEndpoint("/v1/discount_campaigns")]
        public static DiscountCampaign Find(float transactionAmount, string payerEmail, string couponCode, bool useCache, MPRequestOptions requestOptions)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("transaction_amount", transactionAmount.ToString());
            queryParams.Add("payer_email", payerEmail);
            queryParams.Add("coupon_code", couponCode);
            
            return ProcessMethod<DiscountCampaign>(typeof(DiscountCampaign), null, "Find", queryParams, useCache, requestOptions);
        }

        #endregion

        #region Properties

        private string _id;
        private string _name;
        private float? _percentOff;
        private float? _amountOff;
        private float? _couponAmount;
        private string _currencyId;

        #endregion

        #region Accessors

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public float? PercentOff
        {
            get { return _percentOff; }
            set { _percentOff = value; }
        }

        public float? AmountOff
        {
            get { return _amountOff; }
            set { _amountOff = value; }
        }

        public float? CouponAmount
        {
            get { return _couponAmount; }
            set { _couponAmount = value; }
        }

        public string CurrencyId
        {
            get { return _currencyId; }
            set { _currencyId = value; }
        }

        #endregion
    }
}