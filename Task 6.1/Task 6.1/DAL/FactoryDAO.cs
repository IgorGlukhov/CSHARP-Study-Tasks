using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_6._1.DAL.Contracts;


namespace Task_6._1.DAL
{
    public static class FactoryDAO
    {
        public static IAwardDAO CreateAwardDAO()
        {
            return new InMemoryStorage.AwardDAO();
        }

        public static IUserDAO CreateUserDAO()
        {
            return new InMemoryStorage.UserDAO();
        }
    }
}
