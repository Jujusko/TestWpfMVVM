using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Interests>
            Interests
        { get; private set; } = new ObservableCollection<Interests>();
    }
}
