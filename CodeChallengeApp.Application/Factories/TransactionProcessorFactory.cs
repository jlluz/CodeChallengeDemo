using CodeChallengeApp.Domain.Entities;

namespace CodeChallengeApp.Application.Factories
{
    public class TransactionProcessorFactory : ITransactionProcessorFactory
    {
        public ITransactionProcessor GetProcessor(TransactionTypeEnum type)
        {
            return type switch
            {
                TransactionTypeEnum.Debit => new DebitTransactionProcessor(),
                TransactionTypeEnum.Credit => new CreditTransactionProcessor(),
                _ => throw new ArgumentException("Unsupported transaction type")
            };
        }
    }
}

