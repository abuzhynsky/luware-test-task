using System.Threading.Tasks;
using FluentAssertions;
using LyncStatusChecker.SL.Model.Enum;
using LyncStatusChecker.SL.Model.Exceptions;
using LyncStatusChecker.SL.Model.Repository;
using LyncStatusChecker.SL.Model.Repository.Dto;
using LyncStatusChecker.SL.Model.Service;
using Moq;
using Ploeh.AutoFixture;
using Xunit;

namespace LyncStatusChecker.SL.Tests
{
    public class PresenceServiceTests
    {
        private readonly PresenceService _presenceService;
        private readonly PresenceResult _existingPresenceResult;

        private const string ExistingUserSip = "sip:mjakob@luware.net";
        private const string MissingUserSip = "sip:missingUser@luware.net";

        public PresenceServiceTests()
        {
            var fixture = new Fixture();

            _existingPresenceResult = fixture.Create<PresenceResult>();

            var unknownPresence = fixture.Create<PresenceResult>();
            unknownPresence.PresenceState = 0;

            var presenceRepositoryMock = new Mock<IPresenceRepository>();
            presenceRepositoryMock.Setup(_ => _.Get(ExistingUserSip)).ReturnsAsync(_existingPresenceResult);
            presenceRepositoryMock.Setup(_ => _.Get(MissingUserSip)).ReturnsAsync(unknownPresence);

            _presenceService = new PresenceService(presenceRepositoryMock.Object);
        }

        [Fact]
        public async Task WhenGetMissingUserShouldThrow()
        {
            await Assert.ThrowsAsync<UserNotFoundException>(() => _presenceService.Get(MissingUserSip));
        }

        [Fact]
        public async Task WhenGetExistingUserShouldNotThrow()
        {
            var presence = await _presenceService.Get(ExistingUserSip);
            Assert.NotNull(presence);

            presence.DisplayName.Should().Be(_existingPresenceResult.DisplayName);
            presence.SipUri.Should().Be(_existingPresenceResult.SipUri);
            presence.State.Should().Be(_existingPresenceResult.PresenceState.ToLyncStatus());
        }
    }
}