using Challenge.DAO;
using Challenge.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        DAOArticle dao;

        public ArticleController(IConfiguration config)
        {
            dao = new DAOArticle(config);
        }

        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return new List<Article>();
        }

        [HttpPut]
        [Route("[action]/{idArticle}")]
        public Article Like(int idArticle)
        {
            Article article = dao.GetById(idArticle);

            if (article != null)
            {
                article.Like++;
                dao.Update(article);
            }
            else
            {
                article = new Article();
                article.Id = idArticle;
                article.Like = 1;

                dao.Insert(article);
            }

            return article;
        }

        [HttpGet]
        [Route("[action]/{idArticle}")]
        public Article GetLikes(int idArticle)
        {
            Article article = dao.GetById(idArticle);
            return article;
        }
    }
}