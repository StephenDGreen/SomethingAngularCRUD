using Moq;
using Something.Application;
using Something.Domain;
using Something.Persistence;
using Something.Security;
using SomethingTests.Infrastructure.Factories;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Xunit;
using Domain = Something.Domain.Models;


namespace SomethingTests
{
    public class UserManagerTests
    {


        [Fact]
        public void UserManager_GetUserPrinciple_ReturnsUserPrinciple()
        {
            var userManager = new SomethingUserManager();

            var actual = userManager.GetUserPrinciple();

            Assert.IsType<System.Security.Claims.ClaimsPrincipal>(actual);
        }

        [Fact]
        public void UserManager_GetUserToken_ReturnsJwtToken()
        {
            var userManager = new SomethingUserManager();
            var jwtHandler = new JwtSecurityTokenHandler();

            string actual = userManager.GetUserToken();

            Assert.True(jwtHandler.CanReadToken(actual));
        }
    }
}
