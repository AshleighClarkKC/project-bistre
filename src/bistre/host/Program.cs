var builder = DistributedApplication.CreateBuilder(args);

var rabbitMq = builder.AddRabbitMQ("mq");

builder.AddProject<Projects.Bistre_Services_General>("general-service")
    .WithReference(rabbitMq);

builder.Build().Run();
