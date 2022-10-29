using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.Models
{
    public class Registration
    {
        [Key]
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        public int phone { get; set; }

        [StringLength(255)]
        public string priority { get; set; }

        [StringLength(255)]
        public string service { get; set; }

        public DateTime create_date { get; set; }

        public DateTime pickup_date { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        public Registration()
        {

        }

        public Registration(string Name, string Email, int Phone, string Priority, string Service, DateTime Create_date, DateTime Pickup_date, string Status)
        {
            name = Name;
            email = Email;
            phone = Phone;
            priority = Priority;
            service = Service;
            create_date = Create_date;
            pickup_date = Pickup_date;
            status = Status;
        }
    }
}
