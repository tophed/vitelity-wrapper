using Vitelity.Commands;
using Xunit;

namespace Vitelity.Tests
{
    public class CommandUrlBuilderShould
    {
        [Fact]
        public void MakeCorrectUrlForListNpa()
        {
            var fakeCreds = new Credentials
            {
                Username = "username",
                Password = "password"
            };

            var fakeNpa = "123";

            var sut = new CommandUrlBuilder(fakeCreds);

            var expected = "https://api.vitelity.net/api.php?login=username&pass=password&xml=yes&cmd=listnpa&npa=123";

            var actual = sut.ListNpa(fakeNpa);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MakeCorrectUrlForListTollFree()
        {
            var fakeCreds = new Credentials
            {
                Username = "username",
                Password = "password"
            };

            var sut = new CommandUrlBuilder(fakeCreds);

            var expected = "https://api.vitelity.net/api.php?login=username&pass=password&xml=yes&cmd=listtollfree";

            var actual = sut.ListTollFree();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MakeCorrectUrlForGetLocalDID()
        {
            var fakeCreds = new Credentials
            {
                Username = "username",
                Password = "password"
            };

            var fakeDid = "5555555555";

            var sut = new CommandUrlBuilder(fakeCreds);

            var expected = "https://api.vitelity.net/api.php?login=username&pass=password&xml=yes&cmd=getlocaldid&did=5555555555";

            var actual = sut.GetLocalDID(fakeDid);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MakeCorrectUrlForGetTollFree()
        {
            var fakeCreds = new Credentials
            {
                Username = "username",
                Password = "password"
            };

            var fakeDid = "5555555555";

            var sut = new CommandUrlBuilder(fakeCreds);

            var expected = "https://api.vitelity.net/api.php?login=username&pass=password&xml=yes&cmd=gettollfree&did=5555555555";

            var actual = sut.GetTollFree(fakeDid);

            Assert.Equal(expected, actual);
        }
    }
}