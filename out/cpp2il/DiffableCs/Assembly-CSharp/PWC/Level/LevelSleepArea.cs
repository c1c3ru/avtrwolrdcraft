namespace PWC.Level;

public class LevelSleepArea : LevelAvatarRestAreaBase, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public PDSceneObject placeSceneObject; //Field offset: 0x10

		public <>c__DisplayClass2_0() { }

		internal bool <SetGUIDsForPlaces>b__0(PDSceneObject so) { }

	}

	[SerializeField]
	protected Transform[] _places; //Field offset: 0x78

	public LevelSleepArea() { }

	[CompilerGenerated]
	internal static void <Awake>g__EnsureCA|1_0(GameObject target) { }

	[CompilerGenerated]
	internal static bool <GetFirstAvatar>g__TryGetAvatar|5_0(Transform parent, out ILevelAvatar avatar) { }

	[CompilerGenerated]
	internal static void <ReleaseAvatars>g__DropAvatarIfExists|6_0(Transform parent) { }

	protected virtual void Awake() { }

	public Transform GetAvailablePlace(string placeGuid = null) { }

	public virtual ILevelAvatar GetFirstAvatar() { }

	public virtual bool HasItemsOnSelf() { }

	public virtual bool IsAvailableForAvatar() { }

	public override void OnSpawnDuringGameplay() { }

	public virtual void ReleaseAvatars() { }

	private void SetGUIDsForPlaces() { }

}

