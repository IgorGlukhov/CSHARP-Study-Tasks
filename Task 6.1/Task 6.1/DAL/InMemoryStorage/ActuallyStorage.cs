using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_6._1.Entities;

namespace Task_6._1.DAL.InMemoryStorage
{
    internal static class ActuallyStorage
    {
        internal static List<Award> Awards => new List<Award>();
        internal static List<User> Users => new List<User>();
    }
}
