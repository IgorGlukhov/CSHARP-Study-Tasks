using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_10._1.BLL.Contracts;
using Task_10._1.DAL;
using Task_10._1.DAL.Contracts;
using Task_10._1.Entities;

namespace Task_10._1.BLL.Logic
{
    public class AwardBL : IAwardBL
    {
        private readonly IAwardDAO _awardDAO = FactoryDAO.CreateAwardDAO();
        //БАЗА
        public void Add(string _title)
        {
            this._awardDAO.Add(new Award() { Title = _title });
        }
        public bool Remove(int _awardID)
        {
            return this._awardDAO.Remove(_awardID);
        }
        public Award GetByID(int _awardID)
        {
            return this._awardDAO.GetByID(_awardID);
        }

        public IEnumerable<Award> GetAll()
        {
            return this._awardDAO.GetAll();
        }
        //ОПЕРАЦИИ С ВЛАДЕЛЬЦЕМ НАГРАДЫ
        public void AddOwner(int _ownerID, int _awardID)
        {
            this._awardDAO.AddOwner(_ownerID, _awardID);
        }

        public void RemoveOwner(int _ownerID, int _awardID)
        {
            this._awardDAO.RemoveOwner(_ownerID, _awardID);
        }
        //ИЗМЕНЕНИЕ
        public void EditTitle(int _awardID, string _title)
        {
            this._awardDAO.EditTitle(_awardID, _title);
        }
        //ПРОВЕРКИ      
        public bool IsExist(int _awardID)
        {
            return this._awardDAO.IsExist(_awardID);
        }
    }
}