using System.Collections.Generic;
using Task_6._1.Entities;

namespace Task_6._1.DAL
{
    internal static class InMemoryStorage
    {
        internal static List<Award> Awards => new List<Award>();
        internal static List<User> Users => new List<User>();
    }
}
