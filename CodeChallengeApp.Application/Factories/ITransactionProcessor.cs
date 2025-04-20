using CodeChallengeApp.Domain.Entities;

namespace CodeChallengeApp.Application.Factories
{
    public interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }
}
