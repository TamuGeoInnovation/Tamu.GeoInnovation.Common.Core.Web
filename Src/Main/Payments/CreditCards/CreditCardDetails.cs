namespace USC.GISResearchLab.Common.Core.Web.Payments.CreditCards
{
    /// <summary>
    /// Summary description for OrderObject
    /// </summary>
    public class CreditCardDetails
    {

        #region Properties

        private string _NameOnCard;
        public string NameOnCard
        {
            get { return _NameOnCard; }
            set { _NameOnCard = value; }
        }

        private string _CardType;
        public string CardType
        {
            get { return _CardType; }
            set { _CardType = value; }
        }

        private string _CardNumber;
        public string CardNumber
        {
            get { return _CardNumber; }
            set { _CardNumber = value; }
        }

        private int _CardExpirationMonth;
        public int CardExpirationMonth
        {
            get { return _CardExpirationMonth; }
            set { _CardExpirationMonth = value; }
        }

        private int _CardExpirationYear;
        public int CardExpirationYear
        {
            get { return _CardExpirationYear; }
            set { _CardExpirationYear = value; }
        }

        private string _CardVerificationCode;
        public string CardVerificationCode
        {
            get { return _CardVerificationCode; }
            set { _CardVerificationCode = value; }
        }

        private string _StreetAddress;
        public string StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }

        private string _StreetAddress2;
        public string StreetAddress2
        {
            get { return _StreetAddress2; }
            set { _StreetAddress2 = value; }
        }

        private string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        private string _State;
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        private string _Zip;
        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }

        private string _Country;
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        #endregion


        public CreditCardDetails()
        {
            CardNumber  = "";
            CardType  = "";
            CardVerificationCode  = "";
            NameOnCard  = "";
            StreetAddress = "";
            StreetAddress2 = "";
            City = "";
            State = "";
            Zip = "";
            Country = "";
        }
    }
}
