using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.DAO;

namespace Gradebook.Data.Interfaces
{
    interface IPersonService
    {
        Person getPersonByPersonID(int personID);
    }
}
