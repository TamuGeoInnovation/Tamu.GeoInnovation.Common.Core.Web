namespace USC.GISResearchLab.Common.Core.Web.Payments.CreditCards
{
    /// <summary>
    /// Summary description for OrderObject
    /// </summary>
    public class CreditCardDetails
    {

        #region Properties

        public string NameOnCard { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public int CardExpirationMonth { get; set; }
        public int CardExpirationYear { get; set; }
        public string CardVerificationCode { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        #endregion


        public CreditCardDetails()
        {
            CardNumber = "";
            CardType = "";
            CardVerificationCode = "";
            NameOnCard = "";
            StreetAddress = "";
            StreetAddress2 = "";
            City = "";
            State = "";
            Zip = "";
            Country = "";
        }
    }
}
