using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_11.BLL.Contracts;
using Task_11.BLL.Logic;

namespace Task_11.BLL
{
    public static class FactoryBL
    {
        public static IAwardBL CreateAwardBL()
        {
            return new AwardBL();
        }

        public static IUserBL CreateUserBL()
        {
            return new UserBL();
        }
        public static IImageBL CreateImageBL()
        {
            return new ImageBL();
        }
    }
}