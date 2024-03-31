using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_11.Entities;

namespace Task_11.DAL
{
    internal static class InMemoryStorage
    {
        internal static List<Award> Awards => new List<Award>();
        internal static List<User> Users => new List<User>();
        internal static List<Image> Images => new List<Image>();
    }
}