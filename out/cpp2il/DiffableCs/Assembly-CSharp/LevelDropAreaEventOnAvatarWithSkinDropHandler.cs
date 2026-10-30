//Type is in global namespace

[HideParentPropertiesInInspector(new IL2CPP_TYPE_STRING[] {"_invokeDropEventOnPostInit", "_invokePickUpEventOnPostInit"})]
public class LevelDropAreaEventOnAvatarWithSkinDropHandler : LevelDropAreaEventOnItemDropHandler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, String> <>9__9_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <IsConditionMet>b__9_0(string skin) { }

	}

	[SerializeField]
	private String[] _skinNames; //Field offset: 0x80
	[SerializeField]
	private bool _allSkinsMustMatch; //Field offset: 0x88
	[SerializeField]
	private bool _isSpesificAvatar; //Field offset: 0x89
	[ConditionalField("_isSpesificAvatar", True, True, (array) null)]
	[SerializeField]
	private int _avatarID; //Field offset: 0x8C

	public LevelDropAreaEventOnAvatarWithSkinDropHandler() { }

	protected virtual void Awake() { }

	protected virtual bool IsConditionMet(LevelItem levelItem) { }

	protected virtual void OnAvatarEndDrop(LevelAvatarRestAreaBase _, ILevelAvatar levelAvatar) { }

	protected virtual void OnAvatarPickUp(LevelAvatarRestAreaBase _, ILevelAvatar levelAvatar) { }

	protected virtual void OnItemEndDrop(LevelItem levelItem) { }

	protected virtual void OnItemPickUp(LevelItem levelItem) { }

}

