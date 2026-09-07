using CannedNet.Models.Messages.Contracts.Enums;
using System.Text.Json.Serialization;

namespace CannedNet.Models.Messages.Contracts.Responses;

public class MessageResponse
{
    [JsonPropertyName(name: "id")]
    public required long MessageId { get; init; }

    [JsonPropertyName(name: "fromPlayerId")]
    public required long RemoteAccountId { get; init; }


    [JsonPropertyName(name: "sentTime")]
    public required DateTimeOffset CreatedAt { get; init; }


    [JsonPropertyName(name: "type")]
    public required MessageType Type { get; init; }


    [JsonPropertyName(name: "data")]
    public required string Data { get; init; }


    [JsonPropertyName(name: "roomId")]
    public long? RoomId { get; init; }

    [JsonPropertyName(name: "playerEventId")]
    public long? PlayerEventId { get; init; }
}