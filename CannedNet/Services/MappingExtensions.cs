using CannedNet.Models.Messages.Contracts.Responses;
using CannedNet.Models.Messages.Entities;

namespace CannedNet.Services;

public static class MappingExtensions
{
    public static MessageResponse Map(this Message message)
    {
        var messageResponse = new MessageResponse
        {
            MessageId = message.MessageId,
            RemoteAccountId = message.RemoteAccountId,
            CreatedAt = message.CreatedAt,
            Type = message.Type,
            Data = message.Data,
            RoomId = message.RoomId,
            PlayerEventId = message.PlayerEventId
        };

        return messageResponse;
    }

    public static IReadOnlyList<MessageResponse> Map(this IReadOnlyList<Message> messages)
        => [.. messages.Select(message => message.Map())];
}