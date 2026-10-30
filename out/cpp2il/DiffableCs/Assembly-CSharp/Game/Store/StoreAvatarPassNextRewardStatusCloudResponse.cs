namespace Game.Store;

public class StoreAvatarPassNextRewardStatusCloudResponse : Response
{
	internal class AvatarPassStatus
	{
		internal enum StatusType
		{
			None = 0,
			RewardAvailable = 1,
			WaitingForReward = 2,
			Canceled = 3,
			PendingRenewal = 4,
		}

		public StatusType type; //Field offset: 0x10
		public long timestamp; //Field offset: 0x18

		public AvatarPassStatus() { }

	}

	public readonly AvatarPassStatus avatarPassStatus; //Field offset: 0x58
	public readonly Item itemToClaimNext; //Field offset: 0x60

	public StoreAvatarPassNextRewardStatusCloudResponse(string responseText) { }

}

