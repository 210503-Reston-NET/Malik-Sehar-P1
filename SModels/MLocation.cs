namespace Models
{
    public class MLocation
    {
        public MLocation(string name, string address){
            this.Name = name;
            this.Address = address;
        }
        //Constructor chaining
        public MLocation(int id, string name, string address) : this(name, address)
        {
            this.Id = id;
        }
        public MLocation(){}
        public int ProId {get; set;}
        public int Id {get; set;}
        public string Name {get; set;}

        public string Address {get; set;}

        public override string ToString()
        {
            return $"ID: {Id} \n Store Name: {Name}\n Address: {Address}";
        }
    }
}