namespace Ochre.Messaging.Contracts;

public interface IMessageConsumer
{
    TModel ReceiveMessageAsync<TModel>();
}