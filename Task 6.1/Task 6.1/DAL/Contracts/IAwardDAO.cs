using System.Collections.Generic;
using Task_6._1.Entities;

namespace Task_6._1.DAL.Contracts
{
    public interface IAwardDAO
    {
        //БАЗА
            void Add(Award _award);
            bool Remove(int _awardID);
            Award GetByID(int _awardID);
            IEnumerable<Award> GetAll();
        //ОПЕРАЦИИ С ВЛАДЕЛЬЦЕМ НАГРАДЫ
            void AddOwner(int _ownerID, int _awardID);
            void RemoveOwner(int _ownerID, int _awardID);
        //ИЗМЕНЕНИЕ 
            void EditTitle(int _awardID, string _title);
        //ПРОВЕРКИ
            bool IsExist(int _awardID); 
    }
}
