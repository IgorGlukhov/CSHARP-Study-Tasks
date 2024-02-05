using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_6._1.BLL.Contracts;
using Task_6._1.BLL.Logic;

namespace Task_6._1.BLL
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
    }
}
