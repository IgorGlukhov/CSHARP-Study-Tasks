using Task_10._1.BLL;
using Task_10._1.BLL.Contracts;
namespace Task_10._1.PL
{
    public class WEBLogic
    {
        public static IUserBL UserBL = FactoryBL.CreateUserBL();
        public static IAwardBL AwardBL = FactoryBL.CreateAwardBL();
        public static IImageBL ImageBL = FactoryBL.CreateImageBL();
        public static bool CheckUser(string _id)
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
        public static bool CheckAward(string _id)
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