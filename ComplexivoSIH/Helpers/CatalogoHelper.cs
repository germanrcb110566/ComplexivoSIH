using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComplexivoSIH.Models;

namespace ComplexivoSIH.Helpers
{
    public class CatalogoHelper
    {
        public IEnumerable<SelectListItem> GetMCatalogo()
        {
            var data = new SIHEntities();
            return data.mCatalogo.Select(x => new SelectListItem
            {
                Text = x.catalogo,
                Value = x.mcatalogo_id.ToString()
            }).ToList();

        }
        public IEnumerable<SelectListItem> GetMCatalogo(int mCatalogo_Id)
        {
            var data = new SIHEntities();
            return data.mCatalogo.Where(y => y.mcatalogo_id == mCatalogo_Id).Select(x => new SelectListItem
            {
                Text = x.catalogo,
                Value = x.mcatalogo_id.ToString()
            }).ToList();

        }
        public IEnumerable<SelectListItem> GetCatalogo(int mCatalogo_Id)
        {
            var data = new SIHEntities();
            return data.Catalogo.Where(y => y.catalogo_id == mCatalogo_Id).Select(x => new SelectListItem
            {
                Text = x.nombre,
                Value = x.catalogo_id.ToString()
            }).ToList();

        }


    }
}