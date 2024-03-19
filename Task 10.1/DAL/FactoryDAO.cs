using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_10._1.DAL.Contracts;

namespace Task_10._1.DAL
{
    public static class FactoryDAO
    {
        public static IAwardDAO CreateAwardDAO()
        {
            return new Logic.AwardDAO();
        }

        public static IUserDAO CreateUserDAO()
        {
            return new Logic.UserDAO();
        }
    }
}