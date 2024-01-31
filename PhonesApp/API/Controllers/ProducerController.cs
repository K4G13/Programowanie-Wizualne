using Microsoft.AspNetCore.Mvc;
using Interfaces;
using BLC;
using Core;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/producer")]
    public class ProducerController : Controller
    {

        private readonly IBLC blc;

        public ProducerController(IBLC blc)
        {
            this.blc = blc;
        }

        [HttpGet("/api/producer/getall")]
        public ActionResult Get()
        {
            var producers = blc.GetProducers();
            return Ok(producers);
        }
        [HttpGet("/api/producer/get/{id}")]
        public ActionResult Get(int id)
        {

            var producer = blc.GetProducer(id);
            if (producer == null)
            {
                return BadRequest("Producer of given id does not exist");

            }
            else
            {
                return Ok(producer);
            }
        }

        [HttpPost("/api/producer/create")]
        public ActionResult Create(CreateProducerDto producer)
        {
            IProducer _producer = blc.NewProducer();
            _producer.Name = producer.Name;
            _producer.CountryOfOrigin = producer.CountryOfOrigin;
            blc.SaveProducer(_producer);
            return Ok(_producer);
        }

        [HttpGet("/api/producer/delete/{id}")]
        public ActionResult Delete(int id)
        {
            IProducer? _producer = blc.GetProducer(id);
            if (_producer == null)
            {
                return BadRequest("Producer of given id does not exist");
            }
            else
            {
                blc.DeleteProducer(_producer);
                return Ok($"Producer of id {id} deleted succesfully");
            }
        }

        [HttpPut("/api/producerupdate/{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] CreateProducerDto producer)
        {
            IProducer? _producer = blc.GetProducer(id);
            if (_producer == null)
            {
                return BadRequest("Producer of given id does not exist");
            }

            bool result = blc.UpdateProducer(id, producer);
            if (result == false)
            {
                return BadRequest("Producer of given id does not exist");
            }
            IProducer updatedProducer = blc.GetProducer(id);
            return Ok(updatedProducer);

        }
    }
}
