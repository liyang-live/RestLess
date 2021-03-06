﻿using System;
using System.Net;
using System.Net.Http;
using RestLess.Tests.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using RichardSzalay.MockHttp;

namespace RestLess.Tests.Tests
{
    [TestFixture]
    public class Api04Tests
    {
        [Test]
        public void ShouldThrowNotRestInterface()
        {
            string url = "http://example.org";
            var mockHttp = new MockHttpMessageHandler();

            mockHttp.Expect(HttpMethod.Get, url + "/api/posts")
                    .Respond(HttpStatusCode.OK);

            var settings = new RestSettings()
            {
                HttpMessageHandlerFactory = () => mockHttp
            };

            Action job = () => RestClient.For<IApi04>(url, settings);
            job.ShouldThrow<ArgumentException>();
        }
    }
}
