using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperationType
    {
        ///<summary>Typification by default of a purchase being paid using MercadoPago</summary>
        regular_payment,
        ///<summary>Funds transfer between two users</summary>
        money_transfer,
        ///<summary>Automatic recurring payment due to an active user subscription</summary>
        recurring_payment,
        ///<summary>Money income in the user's account</summary>
        account_fund,
        ///<summary>Addition of money to an existing payment, done in MercadoPago's site</summary>
        payment_addition,
        ///<summary>Recharge of a user's cellphone account</summary>
        cellphone_recharge,
        ///<summary>Payment done through a Point Of Sale</summary>
        pos_payment

    }
}
