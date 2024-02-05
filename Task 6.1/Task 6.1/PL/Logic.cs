using System;
using System.Collections.Generic;
using System.Linq;
using Task_6._1.BLL;
using Task_6._1.BLL.Contracts;
using Task_6._1.Entities;

namespace Task_6._1.PL
{
    internal static class Logic
    {
        private readonly static IUserBL UserBL = FactoryBL.CreateUserBL();

        private readonly static IAwardBL AwardBL = FactoryBL.CreateAwardBL();
        internal static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Create new user");
            Console.WriteLine("2. Create new award");
            Console.WriteLine("3. Give award to user");
            Console.WriteLine("4. Take award from user");
            Console.WriteLine("5. Show all users");
            Console.WriteLine("6. Show all awards");
            Console.WriteLine("7. Remove user");
            Console.WriteLine("8. Remove award");
            Console.Write("Your choice: ");
        }
        internal static void SelectMenuOption(string choice)
        {
            switch (choice)
            {
                case "1":
                case "create user":
                case "Create user":
                    CreateUser();
                    PressAnyKey();
                    break;

                case "2":
                case "create award":
                case "Create award":
                    CreateAward();
                    PressAnyKey();
                    break;

                case "3":
                case "give award":
                case "Give award":
                    GiveAwardToUser();
                    PressAnyKey();
                    break;
                case "4":
                case "take award":
                case "Take award":
                    TakeAwardFromUser();
                    PressAnyKey();
                    break;

                case "5":
                case "show users":
                case "Show users":
                    ShowAllUsers();
                    PressAnyKey();
                    break;

                case "6":
                case "show awards":
                case "Show awards":
                    ShowAllAwards();
                    PressAnyKey();
                    break;

                case "7":
                case "remove user":
                case "Remove user":
                    RemoveUser();
                    PressAnyKey();
                    break;
                case "8":
                case "remove award":
                case "Remove award":
                    RemoveAward();
                    PressAnyKey();
                    break;

                default:
                    Console.WriteLine("\tIncorrect input");
                    PressAnyKey();
                    break;
            }    
        }
        //БАЗА 
        private static void CreateUser()
        {
            Console.Write("\tType user name: ");
            string _userName = Console.ReadLine();

            Console.Write("\tType date of birthday in format dd/MM/yyyy: ");
            string _birthday = Console.ReadLine();

            try
            {
                UserBL.Add(_userName, _birthday);

                Console.WriteLine("\tUser has been added successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("\t" + e.Message);
            }
        }
        private static void RemoveUser()
        {
            Console.Write("\tType user ID: ");
            if (!IsInt(Console.ReadLine(), out int _id))
            {
                return;
            }

            if (!CheckUser(_id))
            {
                return;
            }
            IEnumerable<Award> _allAwards = AwardBL.GetAll();
            foreach (Award _award in _allAwards)
            {
                _award.OwnerID.Remove(_id);
            }

            UserBL.Remove(_id);

            Console.WriteLine($"\tUser with {_id.ToString()} ID has been removed successfully");
        }
        private static void CreateAward()
        {
            Console.Write("\tType a title of award: ");
            string _title = Console.ReadLine();
            try
            {
                AwardBL.Add(_title);

                Console.WriteLine("\tAward has been added successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("\t" + e.Message);
            }
        }
        private static void RemoveAward()
        {
            Console.Write("\tType award ID: ");
            if (!IsInt(Console.ReadLine(), out int _id))
            {
                return;
            }

            if (!CheckAward(_id))
            {
                return;
            }
            IEnumerable<User> _allUsers = UserBL.GetAll();
            foreach (User _user in _allUsers)
            {
                _user.AwardID.Remove(_id);
            }

            AwardBL.Remove(_id);

            Console.WriteLine($"\tAward with {_id.ToString()} ID has been removed successfully");
        }
        //ИЗМЕНЕНИЕ СВЯЗИ ВЛАДЕЛЬЦА С НАГРАДОЙ
        private static void GiveAwardToUser()
        {
            Console.Write("\tType id of award: ");
            if (!IsInt(Console.ReadLine(), out int _awardId))
            {
                return;
            }

            if (!CheckAward(_awardId))
            {
                return;
            }

            Console.Write("\tType id of user: ");
            if (!IsInt(Console.ReadLine(), out int _userId))
            {
                return;
            }

            if (!CheckUser(_userId))
            {
                return;
            }

            UserBL.AddAward(_userId, _awardId);

            AwardBL.AddOwner(_userId, _awardId);

            Console.WriteLine("\tAward has been given successfully");
        }
        private static void TakeAwardFromUser()
        {
            Console.Write("\tType id of award: ");
            if (!IsInt(Console.ReadLine(), out int _awardId))
            {
                return;
            }

            if (!CheckAward(_awardId))
            {
                return;
            }

            Console.Write("\tType id of user: ");
            if (!IsInt(Console.ReadLine(), out int _userId))
            {
                return;
            }

            if (!CheckUser(_userId))
            {
                return;
            }

            UserBL.RemoveAward(_userId, _awardId);

            AwardBL.RemoveOwner(_userId, _awardId);

            Console.WriteLine("\tAward has been taken successfully");
        }
        //ПРОВЕРКИ
        private static bool IsInt(string _input, out int _value)
        {
            if (!int.TryParse(_input, out _value))
            {
                Console.WriteLine("\tEntered not a numeber");
                return false;
            }
            else
            {
                return true;
            }
        }
        private static bool CheckUser(int _id)
        {
            if (UserBL.IsExist(_id))
            {
                return true;
            }
            else
            {
                Console.WriteLine("\tCannot find user with that id");
                return false;
            }
        }
        private static bool CheckAward(int _id)
        {
            if (AwardBL.IsExist(_id))
            {
                return true;
            }
            else
            {
                Console.WriteLine("\tCannot find user with that id");
                return false;
            }
        }
        //ИНТЕРФЕЙС
        private static void PressAnyKey()
        {
            Console.ReadKey();
        }
        
        private static void ShowAllAwards()
        {
            IEnumerable<Award> _allAwards = AwardBL.GetAll();

            int _count = _allAwards.Count();

            if (_count == 0)
            {
                Console.WriteLine("\tEmpty");
            }

            foreach (Award _award in _allAwards)
            {
                Console.WriteLine($"{_award.AwardID.ToString()}. Title: {_award.Title}");
                Console.WriteLine("Owners: ");

                if (_award.OwnerID.Count == 0)
                {
                    Console.WriteLine("\tEmpty");

                }
                else
                {
                    foreach (int _ownerId in _award.OwnerID)
                    {
                        Console.WriteLine("\t" + UserBL.GetByID(_ownerId).Name + " ");
                    }
                }
            }
        }
        private static void ShowAllUsers()
        {
            IEnumerable<User> _allUsers = UserBL.GetAll();

            int _count = _allUsers.Count();

            if (_count == 0)
            {
                Console.WriteLine("\tEmpty");
            }

            foreach (User _user in _allUsers)
            {
                Console.WriteLine(
                    "{0}. Name: {1}\tDate of birth: {2}\tAge: {3}",
                    _user.UserID.ToString(),
                    _user.Name,
                    _user.DateOfBirth.ToShortDateString(),
                    _user.Age.ToString());

                Console.WriteLine("Awards: ");

                if (_user.AwardID.Count == 0)
                {
                    Console.WriteLine("\tEmpty");
                }
                else
                {
                    foreach (int _awardId in _user.AwardID)
                    {
                        Console.WriteLine("\t" + AwardBL.GetByID(_awardId).Title + " ");
                    }
                }
            }
        }     
    }
}
