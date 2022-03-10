using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonFacade _facade;

        public PersonController(IPersonFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonResponse>> Get() => Response(await _facade.FindAllAsync());


        [HttpGet("{id}")]
        public async Task<ActionResult<PersonPhoneResponse>> Get(int id)
        {
            return Response(await _facade.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PersonPhoneRequest request)
        {
            PersonPhone personPhone = new PersonPhone();
            personPhone.BusinessEntityID = request.BusinessEntityID;
            personPhone.PhoneNumber = request.PhoneNumber;
            personPhone.PhoneNumberTypeID = request.PhoneNumberTypeID;
            return Response(await _facade.SavePersonPhone(personPhone));
        }

        [HttpPut("{BusinessEntityID}/{PhoneNumber}/{PhoneNumberTypeID}")]
        public async Task<IActionResult> UpdatePersonPhone(int BusinessEntityID, string PhoneNumber, int PhoneNumberTypeID, [FromBody] PersonPhoneRequest request)
        {
            PersonPhone personPhone = new PersonPhone();
            personPhone.BusinessEntityID = request.BusinessEntityID;
            personPhone.PhoneNumber = request.PhoneNumber;
            personPhone.PhoneNumberTypeID = request.PhoneNumberTypeID;

            return Response(await _facade.UpdatePersonPhone(BusinessEntityID, PhoneNumber, PhoneNumberTypeID, personPhone));
        }

        [HttpDelete("{BusinessEntityID}/{PhoneNumber}/{PhoneNumberTypeID}")]
        public async Task<IActionResult> DeletePersonPhone(int BusinessEntityID, string PhoneNumber, int PhoneNumberTypeID)
        {
            return Response(await _facade.DeletePersonPhone(BusinessEntityID, PhoneNumber, PhoneNumberTypeID));
        }
    }
}
