﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_6._1.Entities;
using Task_6._1.DAL.Contracts;

namespace Task_6._1.DAL.InMemoryStorage
{
    internal class AwardDAO : IAwardDAO
    {
        private readonly List<Award> _awards = ActuallyStorage.Awards;
        //БАЗА
        public void Add(Award _award)
        {
           _award.AwardID=this._awards.Count+1;
            this._awards.Add(_award);
        }
        public bool Remove(int _awardID)
        {
            try
            {
                return this._awards.Remove(this.GetByID(_awardID));
            }
            catch
            {
                return false;
            }
        }
        public Award GetByID(int _awardID)
        {
            return this._awards.FirstOrDefault(_award => _award.AwardID == _awardID);
        }

        public IEnumerable<Award> GetAll()
        {
            foreach (Award _award in _awards)
            {
                yield return _award;
            }
        }
        //ОПЕРАЦИИ С ВЛАДЕЛЬЦЕМ НАГРАДЫ
        public void AddOwner(int _ownerID, int _awardID)
        {
            GetByID(_awardID).OwnerID.Add(_ownerID);
        }

        public void RemoveOwner(int _ownerID, int _awardID)
        {
            GetByID(_awardID).OwnerID.Remove(_ownerID);
        }
        //ИЗМЕНЕНИЕ
        public void EditTitle(int _awardID, string _title)
        {
            throw new NotImplementedException();
        }
        //ПРОВЕРКИ      
        public bool IsExist(int _awardID)
        {
            return this._awards.Exists(_award => _award.AwardID == _awardID);
        }              
    }
}
