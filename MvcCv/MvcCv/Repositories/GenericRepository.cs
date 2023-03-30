using Microsoft.Ajax.Utilities;
using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Management;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T : class,new()
    {
        DbCvEntities2 db = new DbCvEntities2();

        // T den gelen değeri liste olarak döndürecek
        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        /// <summary>
        /// ID'ye göre getirme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
        /// <summary>
        /// Experission ile silmek istediğimiz yeri buluyoruz
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}