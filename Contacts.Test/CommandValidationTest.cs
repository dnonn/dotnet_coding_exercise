using Contacts.Application.Commands;
using Contacts.Application.Models;
using Contacts.Domain.Repositories;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Contacts.Test
{
    public class CommandValidationTest
    {
        private readonly Mock<IContactRepository> _contactRepository;

        private readonly Mock<IMediator> _mediator;

        public CommandValidationTest()
        {
            _contactRepository = new Mock<IContactRepository>();
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Validation_fails_if_contact_not_present_in_update()
        {
            // Arrange
            var validator = new UpdateContactCommandValidator();
            var command = new UpdateContactCommand(1, null);
            
            // Act
            var validationResult = await validator.ValidateAsync(command);

            // Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public async Task Validation_fails_if_contact_not_present_in_create()
        {
            // Arrange
            var validator = new CreateContactCommandValidator();
            var command = new CreateContactCommand(null);
            
            // Act
            var validationResult = await validator.ValidateAsync(command);

            // Assert
            Assert.False(validationResult.IsValid);
        }
        
        [Fact]
        public async Task Validation_fails_if_email_is_null()
        {
            // Arrange
            var validator = new CreateContactCommandValidator();
            var command = FakeCreateContactCommand();
            command.Contact.Email = null;
            
            // Act
            var validationResult = await validator.ValidateAsync(command);

            // Assert
            Assert.False(validationResult.IsValid);
        }
        
        [Fact]
        public async Task Validation_fails_if_name_is_null()
        {
            // Arrange
            var validator = new CreateContactCommandValidator();
            var command = FakeCreateContactCommand();
            command.Contact.Name = null;
            
            // Act
            var validationResult = await validator.ValidateAsync(command);

            // Assert
            Assert.False(validationResult.IsValid);
        }
        
        [Fact]
        public async Task Validation_fails_if_address_is_null()
        {
            // Arrange
            var validator = new CreateContactCommandValidator();
            var command = FakeCreateContactCommand();
            command.Contact.Address = null;
            
            // Act
            var validationResult = await validator.ValidateAsync(command);

            // Assert
            Assert.False(validationResult.IsValid);
        }
        
        [Fact]
        public async Task Validation_fails_if_phone_is_null()
        {
            // Arrange
            var validator = new CreateContactCommandValidator();
            var command = FakeCreateContactCommand();
            command.Contact.Phone = null;
            
            // Act
            var validationResult = await validator.ValidateAsync(command);

            // Assert
            Assert.False(validationResult.IsValid);
        }

        private CreateContactCommand FakeCreateContactCommand()
        {
            return new CreateContactCommand(
                new CreateOrUpdateContactModel
                {
                    Name = new NameModel
                    {
                        First = "David",
                        Middle = "Michael",
                        Last = "Nonn"
                    },
                    Address = new AddressModel
                    {
                        City = "Tucson",
                        State = "Arizona",
                        Street = "9046 N. Palm Brook Dr.",
                        Zip = "85743"
                    },
                    Phone = new List<PhoneModel>()
                    {
                        new PhoneModel
                        {
                            Number = "520-390-2731",
                            Type = "home"
                        },
                        new PhoneModel
                        {
                            Number = "520-390-2732",
                            Type = "work"
                        },
                        new PhoneModel
                        {
                            Number = "520-390-2733",
                            Type = "mobile"
                        },
                    },
                    Email = "david.michael.nonn@gmail.com"
                });
        }
    }
}
