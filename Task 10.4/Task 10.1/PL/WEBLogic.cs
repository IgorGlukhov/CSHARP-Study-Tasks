using Task_10._1.BLL;
using Task_10._1.BLL.Contracts;
namespace Task_10._1.PL
{
    public class WEBLogic
    {
        public static IUserBL UserBL = FactoryBL.CreateUserBL();
        public static IAwardBL AwardBL = FactoryBL.CreateAwardBL();
        public static IImageBL ImageBL = FactoryBL.CreateImageBL();
        public static bool CheckLogin(string _login, string _password)
        {
                return _login== _password;
        }
        public static bool CheckUser(string _id)
        {
                return UserBL.IsExist(_id);
        }
        public static bool CheckAward(string _id)
        {
                return AwardBL.IsExist(_id);
        }
    }
}