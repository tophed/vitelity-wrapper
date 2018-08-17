using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Vitelity.Commands;
using Vitelity.Models;
using Xunit;

namespace Vitelity.Tests
{
    public class DIDInventoryShould
    {
        [Fact]
        public async Task DeserializeListNpaResponse()
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
                        <did>
                            <number>7077062660</number>
                            <ratecenter>ANNAPOLIS</ratecenter>
                            <state>CA</state>
                        </did>
                        <did>
                            <number>7073887621</number>
                            <ratecenter>ARCATA</ratecenter>
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
                    },
                    new DidInfo
                    {
                        Number = "7077062660",
                        RateCenter = "ANNAPOLIS",
                        State = "CA"
                    },
                    new DidInfo
                    {
                        Number = "7073887621",
                        RateCenter = "ARCATA",
                        State = "CA"
                    }
                }
            };

            var mock = new Mock<IDIDInventoryCommands>();

            mock.Setup(m => m.ListNpa(It.IsAny<string>())).ReturnsAsync(fakeResponse);

            var inventory = new DIDInventory(mock.Object);

            var actual = await inventory.ListNpa(It.IsAny<string>());

            expected.Numbers.Sort();
            actual.Numbers.Sort();

            Assert.Equal(expected.Status, actual.Status);
            Assert.True(expected.Numbers.SequenceEqual(actual.Numbers));
        }

        [Fact]
        public async Task DeserializeListTollFreeResponse()
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

            var mock = new Mock<IDIDInventoryCommands>();

            mock.Setup(m => m.ListTollFree()).ReturnsAsync(fakeResponse);

            var inventory = new DIDInventory(mock.Object);

            var actual = await inventory.ListTollFreeNumbers();

            expected.Numbers.Sort();
            actual.Numbers.Sort();

            Assert.Equal(expected.Status, actual.Status);
            Assert.True(expected.Numbers.SequenceEqual(actual.Numbers));
        }
    }
}