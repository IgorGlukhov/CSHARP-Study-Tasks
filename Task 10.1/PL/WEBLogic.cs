using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using Task_10._1.BLL;
using Task_10._1.BLL.Contracts;
using Task_10._1.Entities;

namespace Task_10._1.PL
{
    public class WEBLogic
    {
        public static IUserBL UserBL = FactoryBL.CreateUserBL();

        public static IAwardBL AwardBL = FactoryBL.CreateAwardBL();
        public static bool IsInt(string _input, out int _value)
        {
            if (!int.TryParse(_input, out _value))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckUser(int _id)
        {
            if (UserBL.IsExist(_id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckAward(int _id)
        {
            if (AwardBL.IsExist(_id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}