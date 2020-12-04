using Challenge.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.DAO
{
    public class DAOArticle
    {
        private ApplicationDbContext db;

        public DAOArticle(IConfiguration config)
        {
            db = new ApplicationDbContext(config);
        }
        public Article GetById(int id)
        {
            return db.Find<Article>(id);
        }

        public void Insert(Article article)
        {
            db.Add<Article>(article);
            var validationContext = new ValidationContext(article);
            Validator.ValidateObject(article, validationContext);
            db.SaveChanges();
        }

        public void Update(Article article)
        {
            db.Attach<Article>(article);
            db.Entry<Article>(article).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var validationContext = new ValidationContext(article);
            Validator.ValidateObject(article, validationContext);
            db.SaveChanges();
        }

        public long Count(int id)
        {
            return db.Set<Article>().Where(w => w.Id == id).LongCount();
        }
    }
}
