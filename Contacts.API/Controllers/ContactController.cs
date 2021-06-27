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

        /// <summary>
        /// Gets the contact for the specified id.
        /// </summary>
        /// <param name="id">The contact id.</param>
        /// <returns>The contact with the provided id.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ContactModel>> GetContact(int id)
        {
            var result = await _mediator.Send(new GetContactQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Gets the list of contacts with a phone type of "home", ordered by last then first name.
        /// </summary>
        /// <returns>The list of callers.</returns>
        [HttpGet("call-list")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<HomeContactModel>>> GetCallList()
        {
            var result = await _mediator.Send(new GetCallListQuery());
            return Ok(result);
        }

        /// <summary>
        /// Gets the list of contacts.
        /// </summary>
        /// <returns>The list of contacts.</returns>
        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<ContactModel>>> GetContacts()
        {
            var result = await _mediator.Send(new GetContactsQuery());
            return Ok(result);
        }

        /// <summary>
        /// Creates a new contact.
        /// </summary>
        /// <param name="model">The contact to create.</param>
        /// <returns>The id for the created contact.</returns>
        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateContact(CreateOrUpdateContactModel model)
        {
            var result = await _mediator.Send(new CreateContactCommand(model));
            return Ok(result);
        }

        /// <summary>
        /// Updates the contact for the specified id.
        /// </summary>
        /// <param name="id">The id of the contact to update.</param>
        /// <param name="model">The updated contact.</param>
        /// <returns>The id for the updated contact.</returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateContact(int id, CreateOrUpdateContactModel model)
        {
            var result = await _mediator.Send(new UpdateContactCommand(id, model));
            return Ok(result);
        }

        /// <summary>
        /// Deletes the contact for the specified id.
        /// </summary>
        /// <param name="id">The id of the contact to delete.</param>
        /// <returns>Empty</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteContact(int id)
        {
            await _mediator.Send(new DeleteContactCommand(id));
            return Ok();
        }
    }
}
