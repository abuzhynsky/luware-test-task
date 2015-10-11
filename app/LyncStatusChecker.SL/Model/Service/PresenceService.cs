using System;
using System.Threading.Tasks;
using LyncStatusChecker.SL.Model.Exceptions;
using LyncStatusChecker.SL.Model.Repository;

namespace LyncStatusChecker.SL.Model.Service
{
    public class PresenceService
    {
        private readonly IPresenceRepository _repository;

        public PresenceService(IPresenceRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            _repository = repository;
        }

        public async Task<Presence> Get(string sipUri)
        {
            var presenceResult = await _repository.Get(sipUri);

            if (presenceResult.IsUnknown())
            {
                throw new UserNotFoundException(sipUri);
            }

            return presenceResult.ToPresence();
        } 
    }
}