using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHightSchoolOfAvellanedaSystem.Domain
{
    public class Email : Entity
    {
        public int Id { get; set; }
        public string email { get; set; }
        public long dni { get; set; }
        public int dvh { get; set; }

    }
}
