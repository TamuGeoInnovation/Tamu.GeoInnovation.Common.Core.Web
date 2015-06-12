namespace USC.GISResearchLab.Common.Core.Web.Payments.Purchasers
{
    /// <summary>
    /// Summary description for PurchaserDetails
    /// </summary>
    public class PurchaserDetails
    {

        #region Properties

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public string Salutation { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string MiddleName { get; set; }


        private string _IPAddress;
        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }

        #endregion


        public PurchaserDetails()
        {
            MiddleName = "";
            Salutation = "";
            Email  = "";
            FirstName = "";
            LastName = "";
            Phone = "";
            IPAddress = "";
            Address1 = "";
            Address2 = "";
            City = "";
            State = "";
            Zip = "";
            Country = "";
        }
    }
}
