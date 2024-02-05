using Task_6._1.DAL.Contracts;


namespace Task_6._1.DAL
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
