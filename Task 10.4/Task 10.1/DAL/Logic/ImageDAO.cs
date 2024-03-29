using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_10._1.DAL.Contracts;
using Task_10._1.Entities;

namespace Task_10._1.DAL.Logic
{
        internal class ImageDAO : IImageDAO
        {
            private readonly List<Image> _images = InMemoryStorage.Images;
            //БАЗА
            public void Add(Image _image)
            {
                this._images.Add(_image);
            }
            public bool Remove(string _imageID)
            {
                try
                {
                    return this._images.Remove(this.GetByID(_imageID));
                }
                catch
                {
                    return false;
                }
            }
            public Image GetByID(string _imageID)
            {
                return this._images.FirstOrDefault(_image => _image.ImageID == _imageID);
            }

            public IEnumerable<Image> GetAll()
            {
                foreach (Image _image in _images)
                {
                    yield return _image;
                }
            }
            //ИЗМЕНЕНИЕ
            public void EditTitle(string _imageID, string _title)
            {
                GetByID(_imageID).Title = _title;
            }
            //ПРОВЕРКИ      
            public bool IsExist(string _imageID)
            {
                return this._images.Exists(_image => _image.ImageID == _imageID);
            }
        }
}