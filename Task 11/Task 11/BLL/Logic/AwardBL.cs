using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_11.BLL.Contracts;
using Task_11.DAL;
using Task_11.DAL.Contracts;
using Task_11.Entities;

namespace Task_11.BLL.Logic
{
    public class AwardBL : IAwardBL
    {
        private readonly IAwardDAO _awardDAO = FactoryDAO.CreateAwardDAO();
        //БАЗА
        public void Add(Award _award)
        {
            this._awardDAO.Add(_award);
        }
        public bool Remove(string _awardID)
        {
            return this._awardDAO.Remove(_awardID);
        }
        public Award GetByID(string _awardID)
        {
            return this._awardDAO.GetByID(_awardID);
        }

        public IEnumerable<Award> GetAll()
        {
            return this._awardDAO.GetAll();
        }
        //ОПЕРАЦИИ С ВЛАДЕЛЬЦЕМ НАГРАДЫ
        public void AddOwner(string _ownerID, string _awardID)
        {
            this._awardDAO.AddOwner(_ownerID, _awardID);
        }

        public void RemoveOwner(string _ownerID, string _awardID)
        {
            this._awardDAO.RemoveOwner(_ownerID, _awardID);
        }
        //ИЗМЕНЕНИЕ
        public void EditTitle(string _awardID, string _title)
        {
            this._awardDAO.EditTitle(_awardID, _title);
        }
        //ПРОВЕРКИ      
        public bool IsExist(string _awardID)
        {
            return this._awardDAO.IsExist(_awardID);
        }
    }
}