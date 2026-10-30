namespace PWC.Level;

public class LevelSecretIdConditionsUnlockableObjectHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Object, String> <>9__6_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <CheckItemSecretId>b__6_0(object nameObj) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public LevelConsumerAreaBase itemConsumerArea; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal bool <OnItemEndDrop>b__0(LevelConsumerAreaBase x) { }

	}

	[SerializeField]
	private LevelUnlockableObject unlockableObject; //Field offset: 0x20
	[SerializeField]
	private SecretFullId[] _secretIds; //Field offset: 0x28
	[SerializeField]
	private string _soundName; //Field offset: 0x30

	public LevelSecretIdConditionsUnlockableObjectHandler() { }

	private void Awake() { }

	private bool CheckItemSecretId(LevelItem levelItem, int consumerAreaId) { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem item) { }

	private bool PerformLabelsTest() { }

}

