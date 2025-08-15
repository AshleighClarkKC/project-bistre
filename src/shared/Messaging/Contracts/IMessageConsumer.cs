namespace Bistre.Shared.Messaging.Contracts;

public interface IMessageConsumer
{
    TModel ReceiveMessageAsync<TModel>();
}