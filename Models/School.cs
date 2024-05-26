using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Kolokvijum2.Models
{
    public class School
    {

        public School()
        {
            //this.Students = new ObservableCollection<Student>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; } 
        
        public virtual IEnumerable<Student> Students { get; set; }
    }
}
