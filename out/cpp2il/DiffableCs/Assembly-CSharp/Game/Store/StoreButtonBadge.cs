namespace Game.Store;

public class StoreButtonBadge : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<StorePackType, Boolean> <>9__2_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <Awake>b__2_0(StorePackType x) { }

	}

	private const string PLAYERPREFS_KEY = "AWStore_DidUserClickOnStoreButton"; //Field offset: 0x0
	private static int _packsCount; //Field offset: 0x0

	public StoreButtonBadge() { }

	private void Awake() { }

	public static void MarkAsClicked() { }

}

