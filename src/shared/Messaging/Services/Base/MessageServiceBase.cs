using static Bistre.Shared.Constants.ApplicationConstants;
using Bistre.Shared.Enumerations;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using Bistre.Shared.Extensions;

namespace Bistre.Shared.Messaging.Services.Base;

public class MessageServiceBase(IConfiguration configuration, ConnectionMethod connectionMethod)
{
    private ConnectionFactory? ConnectionFactory { get; set; } = ConfigureConnectionFactory(configuration, connectionMethod);
    
    private static ConnectionFactory ConfigureConnectionFactory(IConfiguration configuration, ConnectionMethod connectionMethod)
        => connectionMethod switch
        {
            ConnectionMethod.ConnectionString => new ConnectionFactory
            {
                Uri = new Uri(configuration.GetConnectionString(DEFAULT_MQ_SECTION_KEY)
                    ?? throw new NullReferenceException($"ERR: The \"{nameof(connectionMethod)}\" has been set to ConnectionString but no Connection String was provided."))
            },
            ConnectionMethod.ConfigurationSection => new ConnectionFactory
            {
                HostName = configuration[$"{DEFAULT_MQ_SECTION_KEY}: {MQ_SECTION_HOSTNAME_KEY}"] ?? "localhost",
                Port = int.Parse(configuration[$"{DEFAULT_MQ_SECTION_KEY}:{MQ_SECTION_PORT_KEY}"]!),
                UserName = configuration[$"{DEFAULT_MQ_SECTION_KEY}: {MQ_SECTION_USERNAME_KEY}"] ?? string.Empty,
                Password = configuration[$"{DEFAULT_MQ_SECTION_KEY}: {MQ_SECTION_PASSWORD_KEY}"] ?? string.Empty,
                VirtualHost = configuration[$"{DEFAULT_MQ_SECTION_KEY}: {MQ_SECTION_VIRTUAL_HOST_KEY}"] ?? "/",
            },
            _ => throw new ArgumentException($"ERR: Invalid \"{nameof(connectionMethod)}\" value provided.")
        };

    public async Task<IConnection> CreateConnectionAsync()
        => !ConnectionFactory.IsNull()
            ? await ConnectionFactory!.CreateConnectionAsync()
            : throw new NullReferenceException($"ERR: This Message Service's \"{nameof(ConnectionFactory)}\" has not been properly intialized.");
}