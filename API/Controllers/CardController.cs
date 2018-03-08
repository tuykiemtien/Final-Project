using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;

namespace API.Controllers
{
    public class CardController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetAllCard()
        {
            List<CardDTO> list = db.Cards.Select(e => new CardDTO()
            {
                CardId = e.CardId,
                CustomerId = e.CustomerId,
                ProductId = e.ProductId,
                ProductNumber = e.ProductNumber
            }).ToList();

            if (list.Count > 0)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult GetCardByCustomer(string customerId)
        {
            List<CardDTO> list = db.Cards.Where( a => a.CustomerId == customerId).Select(e => new CardDTO()
            {
                CardId = e.CardId,
                CustomerId = e.CustomerId,
                ProductId = e.ProductId,
                ProductNumber = e.ProductNumber
            }).ToList();

            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult PostNewCard(CardDTO e)
        {
            Card newCard = new Card()
            {
                CardId = e.CardId,
                CustomerId = e.CustomerId,
                ProductId = e.ProductId,
                ProductNumber = e.ProductNumber
            };
            db.Cards.Add(newCard);
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult PutCard(CardDTO e)
        {
            Card card = db.Cards.FirstOrDefault(s => s.CardId == e.CardId);

            card.CustomerId = e.CustomerId;
            card.ProductId = e.ProductId;
            card.ProductNumber = e.ProductNumber;

            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }


        public IHttpActionResult DeleteCard(int id)
        {
            Card card = db.Cards.FirstOrDefault(s => s.CardId == id);
            if (card != null)
            {
                db.Cards.Remove(card);
                if (db.SaveChanges() > 0)
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
