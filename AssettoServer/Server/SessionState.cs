﻿using System;
using System.Collections.Generic;
using AssettoServer.Server.Configuration;

namespace AssettoServer.Server;

public class SessionState
{
    public SessionConfiguration Configuration { get; init; }
    public int EndTime { get; set; } // TODO
    public long StartTimeMilliseconds { get; set; }
    public int TimeLeftMilliseconds => (int)(StartTimeMilliseconds + Configuration.Time * 60_000 - _server.ServerTimeMilliseconds);
    public int SessionTimeMilliseconds => (int)(_server.ServerTimeMilliseconds - StartTimeMilliseconds);
    public int TargetLap { get; set; } = 0;
    public int LeaderLapCount { get; set; } = 0;
    public bool LeaderHasCompletedLastLap { get; set; } = false;
    public bool SessionOverFlag { get; set; } = false;
    public Dictionary<byte, EntryCarResult>? Results { get; set; }
    public IEnumerable<EntryCar>? Grid { get; set; }

    private readonly ACServer _server;

    public SessionState(SessionConfiguration configuration, ACServer server)
    {
        Configuration = configuration;
        _server = server;
    }
}

public class EntryCarResult
{
    public int BestLap { get; set; } = 999999999;
    public int NumLaps { get; set; } = 0;
    public int TotalTime { get; set; } = 0;
    public int LastLap { get; set; } = 999999999;
    public bool HasCompletedLastLap { get; set; } = false;
}
