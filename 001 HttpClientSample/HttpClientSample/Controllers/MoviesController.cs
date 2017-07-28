using HttpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HttpClient.Controllers
{
    public class MoviesController : ApiController
    {
        MovieEntities _contextEntities = new MovieEntities();
        // Получение всех требуемых киносеансов
        public IEnumerable<Movie> Get()
        {
            //List<Movie> movies = _contextEntities.Movies.Where(x=>x.TimeBegin>DateTime.Now).ToList();
            List<Movie> movies = _contextEntities.Movies.ToList();
            return movies;
        }

        // Создание нового киносеанса
        public HttpResponseMessage Post([FromBody]Movie movie)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, movie);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // Обновление киносеанса по id
        public HttpResponseMessage Put(int id, [FromBody]Movie movie)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, movie);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // Удаление киносеансов по id
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
