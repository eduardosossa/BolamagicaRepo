using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BolaMagica.Models;

namespace BolaMagica.Controllers
{
    public class BallsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Balls
        public IQueryable<Ball> GetBalls()
        {
            return db.Balls;
        }

        // GET: api/Balls/5
        [ResponseType(typeof(Ball))]
        public IHttpActionResult GetBall(int id)
        {
            Ball ball = db.Balls.Find(id);
            if (ball == null)
            {
                return NotFound();
            }

            return Ok(ball);
        }

        // PUT: api/Balls/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBall(int id, Ball ball)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ball.BallId)
            {
                return BadRequest();
            }

            db.Entry(ball).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BallExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Balls
        [ResponseType(typeof(Ball))]
        public IHttpActionResult PostBall(Ball ball)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Balls.Add(ball);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ball.BallId }, ball);
        }

        // DELETE: api/Balls/5
        [ResponseType(typeof(Ball))]
        public IHttpActionResult DeleteBall(int id)
        {
            Ball ball = db.Balls.Find(id);
            if (ball == null)
            {
                return NotFound();
            }

            db.Balls.Remove(ball);
            db.SaveChanges();

            return Ok(ball);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BallExists(int id)
        {
            return db.Balls.Count(e => e.BallId == id) > 0;
        }
    }
}