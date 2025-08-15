namespace Bistre.Shared.Messaging.Contracts;

public interface IMessageProducer
{
    Task SendMessageAsync<TModel>(TModel model);
}