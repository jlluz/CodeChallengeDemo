using CodeChallengeApp.Domain.Entities;

namespace CodeChallengeApp.Application.Factories
{
    public interface ITransactionProcessorFactory
    {
        ITransactionProcessor GetProcessor(TransactionTypeEnum type);
    }
}
