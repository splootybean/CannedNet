using CannedNet.Models.Messages.Contracts.Enums;

namespace CannedNet.Models.Messages.Entities;

public sealed class Message
{
    public static readonly HashSet<MessageType> MESSAGE_VALID_MESSAGE_TYPES =
    [
        MessageType.GameJoinFailed,
        MessageType.RequestGameInvite,
        MessageType.RequestGameInviteDeclined,
        MessageType.FriendCodeUsed,
        MessageType.FriendStatusOnline,
    ];

    public long MessageId { get; private set; }
    public long AccountId { get; private set; }
    public long RemoteAccountId { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public MessageType Type { get; private set; }
    public string Data { get; private set; } = string.Empty;
    public long? RoomId { get; private set; }
    public long? PlayerEventId { get; private set; }

    public bool Read { get; private set; }

    internal Message() => CreatedAt = DateTimeOffset.UtcNow;

    // REDO ALL LATER : )
    public static Message Create(long accountId, long remoteAccountId, MessageType type, string data, long? roomId, long? playerEventId)
    {
        if (!MESSAGE_VALID_MESSAGE_TYPES.Contains(type))
            throw new InvalidOperationException();

        var message = CreateInternal(accountId, remoteAccountId, type, data, roomId, playerEventId);

        return message;
    }

    public static Message CreateInternal(long accountId, long remoteAccountId, MessageType type, string data, long? roomId, long? playerEventId)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(accountId, nameof(accountId));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(remoteAccountId, nameof(remoteAccountId));

        var message = new Message
        {
            AccountId = accountId,
            RemoteAccountId = remoteAccountId,
            Type = type,
            Data = data,
            RoomId = roomId,
            PlayerEventId = playerEventId
        };

        return message;
    }

    public void MarkRead()
        => Read = true;
}