namespace PWC.Multiplayer;

public class MPPlayerNotification : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public int playerUID; //Field offset: 0x10
		public bool isJoin; //Field offset: 0x14

		public <>c__DisplayClass5_0() { }

		internal void <ShowJoinedOrLeft>b__0(MPPlayerNotification x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public MPPlayerNotification instance; //Field offset: 0x10

		public <>c__DisplayClass6_0() { }

		internal void <Show>b__0() { }

	}

	internal enum StateType
	{
		None = 0,
		PlayerJoined = 2,
		PlayerLeft = 3,
	}

	[SerializeField]
	private GameObject _joinState; //Field offset: 0x20
	[SerializeField]
	private GameObject _leftState; //Field offset: 0x28
	[SerializeField]
	private Image _avatarPicture; //Field offset: 0x30

	public MPPlayerNotification() { }

	private void SetState(int playerUID, StateType stateType) { }

	private static void Show(Action<MPPlayerNotification> onShowAction) { }

	public static void ShowJoinedOrLeft(int playerUID, bool isJoin) { }

}

