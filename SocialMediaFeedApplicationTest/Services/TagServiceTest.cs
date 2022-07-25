using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SocialMediaApplication.Controllers;
using SocialMediaApplication.Services;

namespace SocialMediaApplicationTest.Services
{
    public class TagServiceTest
    {
        private readonly TagController _controller;
        Mock<TagService> servicemock = new Mock<TagService>();

        public TagServiceTest()
        {
            _controller = new TagController(servicemock.Object);
        }

        [Fact]
        public async Task Tag_Return_Success()
        {

            var feedId = 11;
            var userId = 1;

            servicemock.Setup(x => x.Tag(userId, feedId)).ReturnsAsync(new { msg = "User " + userId + " Tagged " + feedId + " Successfully" });

            var ActualOutput = await _controller.TagFeed(userId,feedId);
            var result = ActualOutput as OkObjectResult;

            Assert.IsType<OkObjectResult>(ActualOutput);

        }


    }
}