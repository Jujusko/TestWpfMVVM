using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWpfTutor6.DBModel
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance  { get; set; }
        public virtual ICollection<Tranzaction> Tranzactions { get; set; }
    }
}
