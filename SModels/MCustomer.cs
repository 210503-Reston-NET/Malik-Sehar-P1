namespace Models
{
    /// <summary>
    /// this model contains constructor for customer
    /// </summary>
    public class MCustomer
    {
        public MCustomer(string name, string phoneNo, string address, string password)
        {
            this.Name = name;
            this.PhoneNo = phoneNo;
            this.Address = address;
            this.Password = password;
        }
        public MCustomer(string phoneNo, string password){
            this.PhoneNo = phoneNo;
            this.Password = password;
        }
        public MCustomer(int id,string name, string phoneNo, string address, string password) : this(name, phoneNo, address, password)
        {
            this.Id = id;
        }
        public MCustomer(){
            
        }
        public int Id {get; set;}
        public string Name {get; set;}
        public string Password { get; set; }
        public string PhoneNo {get; set;}
        public string Address {get; set;}

        public override string ToString()
        {
            return $"Customer Name: {Name} \n Address: {Address}\n PhoneNo: {PhoneNo}";
        }
    }
}