using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_6._1.Entities;

namespace Task_6._1.BLL.Contracts
{
    public interface IAwardBL
    {
        //БАЗА
        void Add(string _title);
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
