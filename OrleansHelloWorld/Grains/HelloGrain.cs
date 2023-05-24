// ----------------------------------------------------------------
// Copyright 	©2023 Charke All Rights Reserved.
// FileName: 	HelloGrain
// Guid:	 	0d75b503-d0d0-42b0-b4db-86be40ff7f46
// Author:	 	charke
// Email:	 	charke_cc@163.com
// CreateTime:	2023/5/24 22:45:13
// ----------------------------------------------------------------

using GrainInterfaces;
using Microsoft.Extensions.Logging;

namespace Grains;

public class HelloGrain : Grain, IHello
{
    private readonly ILogger _logger;

    public HelloGrain(ILogger<HelloGrain> logger) => _logger = logger;

    ValueTask<string> IHello.SayHello(string greeting)
    {
        _logger.LogInformation(
            "SayHello message received: greeting = '{Greeting}'", greeting);

        return ValueTask.FromResult(
            $"""
            Client said: '{greeting}', so HelloGrain says: Hello!
            """);
    }
}