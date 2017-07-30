
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HttpClientSample.Models;

namespace HttpClient.Controllers
{
    public class MoviesController : ApiController
    {
        MoviesEntities _moviesEntities = new MoviesEntities();

        TicketEntities _ticketEntities = new TicketEntities();

        // Получение всех требуемых киносеансов
        public IEnumerable<Movie> Get()
        {
            List<Movie> movies = _moviesEntities.Movies.Where(x=>x.TimeBegin>DateTime.Now).ToList();
            //List<Movie> movies = _moviesEntities.Movies.ToList();
            return movies;
        }

        // Создание нового киносеанса
        public HttpResponseMessage Post([FromBody]Order order)
        {
            try
            {
                _ticketEntities.Tickets.Add(new Ticket{BuyTime = DateTime.Now,Count = order.Count,IdMovies = order.Movie.Guid});
                _ticketEntities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, order);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // Обновление киносеанса по id
        public HttpResponseMessage Put(int id, [FromBody]Ticket ticket)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, ticket);
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
