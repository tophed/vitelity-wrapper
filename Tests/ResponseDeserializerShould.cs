using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Vitelity.Commands;
using Vitelity.Models;
using Vitelity.Utility;
using Xunit;

namespace Vitelity.Tests
{
    public class ResponseDeserializerShould
    {
        [Fact]
        public void DeserializeSuccessfulListNpaResponse()
        {
            var fakeResponse = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                <content>
                    <status>ok</status>
                    <numbers>
                        <did>
                            <number>7077062311</number>
                            <ratecenter>ANNAPOLIS</ratecenter>
                            <state>CA</state>
                        </did>
                    </numbers>
                </content>";

            var expected = new ListNpaResponse
            {
                Status = "ok",
                Numbers = new List<DidInfo>
                {
                    new DidInfo
                    {
                        Number = "7077062311",
                        RateCenter = "ANNAPOLIS",
                        State = "CA"
                    }
                }
            };

            var sut = new ResponseDeserializer();

            var actual = sut.DeserializeListNpaResponse(fakeResponse);

            var actualNumber = actual.Numbers.FirstOrDefault();

            var expectedNumber = expected.Numbers.FirstOrDefault();

            Assert.IsType(typeof(ListNpaResponse), actual);
            Assert.Equal(expected.Status, actual.Status);
            Assert.NotNull(actualNumber);
            Assert.Equal(expectedNumber.Number, actualNumber.Number);
            Assert.Equal(expectedNumber.RateCenter, actualNumber.RateCenter);
            Assert.Equal(expectedNumber.State, actualNumber.State);
        }

        [Fact]
        public void DeserializeSuccessfulListTollFreeResponse()
        {
            var fakeResponse = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                <content>
                    <status>ok</status>
                    <numbers>
                        <did>5555555555</did>
                        <did>6666666666</did>
                        <did>7777777777</did>
                    </numbers>
                </content>";

            var expected = new ListTollFreeResponse
            {
                Status = "ok",
                Numbers = new List<string>
                {
                    "5555555555", "6666666666", "7777777777"
                }
            };

            var sut = new ResponseDeserializer();

            var actual = sut.DeserializeListTollFreeResponse(fakeResponse);

            Assert.NotNull(actual.Numbers);

            expected.Numbers.Sort();
            actual.Numbers.Sort();

            Assert.IsType(typeof(ListTollFreeResponse), actual);
            Assert.Equal(expected.Status, actual.Status);
            Assert.True(expected.Numbers.SequenceEqual(actual.Numbers));
        }

        [Fact]
        public void DeserializeListNpaResponseWithError()
        {
            var fakeResponse = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                <content>
                    <status>fail</status>
                    <error>missing</error>
                </content>";

            var expected = new ListNpaResponse
            {
                Status = "fail",
                Error = "missing"
            };

            var sut = new ResponseDeserializer();

            var actual = sut.DeserializeListNpaResponse(fakeResponse);

            Assert.IsType(typeof(ListNpaResponse), actual);
            Assert.Equal(expected.Status, actual.Status);
            Assert.Equal(expected.Error, actual.Error);
        }

        [Fact]
        public void DeserializeListTollFreeResponseWithError()
        {
            var fakeResponse = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                <content>
                    <status>fail</status>
                    <error>missing</error>
                </content>";

            var expected = new ListTollFreeResponse
            {
                Status = "fail",
                Error = "missing"
            };

            var sut = new ResponseDeserializer();

            var actual = sut.DeserializeListTollFreeResponse(fakeResponse);

            Assert.IsType(typeof(ListTollFreeResponse), actual);
            Assert.Equal(expected.Status, actual.Status);
            Assert.Equal(expected.Error, actual.Error);
        }

        [Fact]
        public void DeserializeBasicResponseWithError()
        {
            var fakeResponse = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                <content>
                    <status>fail</status>
                    <error>unavailable</error>
                </content>";

            var expected = new BasicResponse
            {
                Status = "fail",
                Error = "unavailable"
            };

            var sut = new ResponseDeserializer();

            var actual = sut.DeserializeBasicResponse(fakeResponse);

            Assert.IsType(typeof(BasicResponse), actual);
            Assert.Equal(expected.Status, actual.Status);
            Assert.Equal(expected.Error, actual.Error);
        }

        [Fact]
        public void DeserializeBasicResponseWithSuccess()
        {
            var fakeResponse = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                <content>
                    <status>ok</status>
                    <response>success</response>
                </content>";

            var expected = new BasicResponse
            {
                Status = "ok",
                Response = "success"
            };

            var sut = new ResponseDeserializer();

            var actual = sut.DeserializeBasicResponse(fakeResponse);

            Assert.IsType(typeof(BasicResponse), actual);
            Assert.Equal(expected.Status, actual.Status);
            Assert.Equal(expected.Response, actual.Response);
        }
    }
}