using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_10._1.DAL.Contracts;
using Task_10._1.Entities;

namespace Task_10._1.DAL.Logic
{
    internal class AwardDAO : IAwardDAO
    {
        private readonly List<Award> _awards = InMemoryStorage.Awards;
        //БАЗА
        public void Add(Award _award)
        {
            this._awards.Add(_award);
        }
        public bool Remove(string _awardID)
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
        public Award GetByID(string _awardID)
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
        public void AddOwner(string _ownerID, string _awardID)
        {
            GetByID(_awardID).OwnerID.Add(_ownerID);
        }

        public void RemoveOwner(string _ownerID, string _awardID)
        {
            GetByID(_awardID).OwnerID.Remove(_ownerID);
        }
        //ИЗМЕНЕНИЕ
        public void EditTitle(string _awardID, string _title)
        {
            GetByID(_awardID).Title=_title;
        }
        //ПРОВЕРКИ      
        public bool IsExist(string _awardID)
        {
            return this._awards.Exists(_award => _award.AwardID == _awardID);
        }
    }
}