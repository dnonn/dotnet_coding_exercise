using Contacts.API.Application.Commands;
using Contacts.API.Application.Models;
using Contacts.API.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Contacts.API.Controllers
{
    [ApiController]
    [Route("contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ContactModel>> GetContact(int id)
        {
            var result = await _mediator.Send(new GetContactQuery(id));
            return Ok(result);
        }

        [HttpGet("call-list")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<HomeContactModel>>> GetCallList()
        {
            var result = await _mediator.Send(new GetCallListQuery());
            return Ok(result);
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<ContactModel>>> GetContacts()
        {
            var result = await _mediator.Send(new GetContactsQuery());
            return Ok(result);
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateContact(CreateOrUpdateContactModel model)
        {
            var result = await _mediator.Send(new CreateContactCommand(model));
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateContact(int id, CreateOrUpdateContactModel model)
        {
            var result = await _mediator.Send(new UpdateContactCommand(id, model));
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteContact(int id)
        {
            await _mediator.Send(new DeleteContactCommand(id));
            return Ok();
        }
    }
}
