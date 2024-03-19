using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_10._1.Entities;

namespace Task_10._1.DAL.Contracts
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
