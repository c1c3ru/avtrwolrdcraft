namespace Game.Level;

public class LevelOnAvatarFoundEvent : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<LevelType, String> <>9__9_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <SearchAvatar>b__9_0(LevelType level) { }

	}

	[SerializeField]
	private List<Int32> _characterID; //Field offset: 0x20
	[SerializeField]
	private UnityEvent OnAvatarsFound; //Field offset: 0x28
	[SerializeField]
	private UnityEvent OnAvatarsNotFound; //Field offset: 0x30
	[SerializeField]
	private LevelType[] _checkOnLevels; //Field offset: 0x38
	[SerializeField]
	private bool _checkOnStart; //Field offset: 0x40
	private int _characterFoundCount; //Field offset: 0x44

	public LevelOnAvatarFoundEvent() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public void SearchAvatar() { }

}

