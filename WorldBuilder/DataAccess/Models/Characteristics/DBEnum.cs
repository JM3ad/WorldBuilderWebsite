using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Characteristics
{
    public interface DBEnum
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
