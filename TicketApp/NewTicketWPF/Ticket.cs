namespace NewTicketWPF
{
    public class Ticket
    {
        #region field
        private string _name;
        private bool _used;
        private int _id;
        private bool _sold;
        private int _btnState;
        #endregion

        #region constructors
        public Ticket(int id)
        {
            _used = false;
            _id = id;
        }
        public Ticket(int id, string name, bool used)
        {
            _used = used;
            _id = id;
            _name = name;
        }
        public Ticket(int id, string name, bool used, bool sold, int visibility)
        {
            _used = used;
            _id = id;
            _name = name;
            _sold = sold;
            ButtonState = (System.Windows.Visibility)visibility;
            ButtonStateInt = (int)ButtonState;
        }
        #endregion

        #region properties
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        
        public System.Windows.Visibility ButtonState { get; set; }

        public int ButtonStateInt { get; set; }
       
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public bool Sold
        {
            get
            {
                return _sold;
            }
            set
            {
                _sold = value;
            }
        }
        public bool Used
        {
            get
            {
                return _used;
            }
            set
            {
                if(Used)
                {
                    _used = true;
                }
                _used = value;
            }
        }
        public string IDS
        {
            get { return ID.ToString(); }
        }

        public string GetSoldState
        {
            get
            {
                if (Sold)
                {
                    return "Sold";
                }
                else
                {
                    return "Free to sell";
                }
            }
        }
        public string GetStatus
        {
            get 
            {
                if (Used)
                {
                    return "Used";
                }
                else
                {
                    return "Not Used";
                }
            }
        }
        #endregion


    }
}
