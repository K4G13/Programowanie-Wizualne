using Core;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/phone")]
    public class PhoneController : Controller
    {
        private readonly IBLC blc;

        public PhoneController(IBLC blc)
        {
            this.blc = blc;
        }
        [HttpGet]
        [Route("/api/phone/get")]
        public ActionResult Get()
        {
            var phones = blc.GetPhones();
            return Ok(phones);
        }
        [HttpPost]
        [Route("/api/phone/create")]
        public ActionResult Create([FromBody] CreatePhoneDto phone)
        {
            IPhone _phone = blc.NewPhone();
            _phone.DiagonalScreenSize = phone.DiagonalScreenSize;
            _phone.Name = phone.Name;
            _phone.DisplayType = phone.DisplayType;
            IProducer? producer = blc.GetProducer(phone.ProducerId);
            if (producer == null)
            {
                return BadRequest("Producer of given ID does not exist");
            }
            _phone.Producer = producer;
            blc.SavePhone(_phone);
            return Ok(_phone);
        }

        [HttpPut]
        [Route("/api/phone/update/{phoneId:int}")]
        public ActionResult Update([FromBody] CreatePhoneDto phone, [FromRoute] int phoneId)
        {
            if (phone.DisplayType > DisplayType.IPS) 
            {
                return BadRequest("Display type must be int 0 - AMOLED, 1 - OLED, 2 - IPS");
            }

            int result = blc.UpdatePhone(phoneId, phone);
            if (result == 1) 
            {
                return BadRequest("Phone of given id does not exist");
            }
            if (result == 2)
            {
                return BadRequest("Producer of given id does not exist");
            }
            IPhone updatedPhone = blc.GetPhone(phoneId);
            return Ok(updatedPhone);
        }

        [HttpGet]
        [Route("/api/phone/delete/{phoneId:int}")]
        public ActionResult Delete([FromRoute] int phoneId)
        {
            IPhone? phone = blc.GetPhone(phoneId);
            if (phone == null)
            {
                return BadRequest("Phone of given id does not exist");
            }
            blc.DeletePhone(phone);
            return Ok("Phone deleted succesfully");
        }
    }
}
