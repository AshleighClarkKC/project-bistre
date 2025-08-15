namespace Ochre.Messaging.Contracts;

public interface IMessageProducer
{
    Task SendMessageAsync<TModel>(TModel model);
}