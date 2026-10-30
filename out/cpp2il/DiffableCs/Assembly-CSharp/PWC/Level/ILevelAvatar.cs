namespace PWC.Level;

public interface ILevelAvatar
{

	public event Action<Event> OnSpineEventAction
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public int ID
	{
		 get { } //Length: 0
	}

	public bool IsNewAvatar
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Action<LevelItem> OnPutItemInBoneAction
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	[CompilerGenerated]
	public void add_OnSpineEventAction(Action<Event> value) { }

	public void DestroyAvatar(bool releaseChildrenItems) { }

	public BoneFollower FollowBone(Transform target, string boneName, bool followRotation = false, bool followScale = false) { }

	public int get_ID() { }

	public bool get_IsNewAvatar() { }

	public Action<LevelItem> get_OnPutItemInBoneAction() { }

	public LevelItem GetLevelItem() { }

	public PDPrefab GetPDPrefab() { }

	public SkeletonAnimation GetSkeletonAnimation() { }

	public AvatarSpineSkinsManagerBase GetSkinsManager() { }

	public void Init(int id) { }

	public void OnItemPutInBone(LevelItem levelItem) { }

	public void OnPostSaveProgress() { }

	public void PlayProperIdleAnimation() { }

	public void PutInBone(LevelItem levelItem, string boneName, ItemOnAvatarType itemOnAvatarType, out BoneFollower boneFollower, bool snap = false, bool followRotation = true, bool followScale = true, bool callEvents = true, Nullable<Vector2> pivot = null) { }

	[CompilerGenerated]
	public void remove_OnSpineEventAction(Action<Event> value) { }

	public void SaveAvatarData(List<String> newExtraScenesId = null) { }

	public void set_IsNewAvatar(bool value) { }

	public void set_OnPutItemInBoneAction(Action<LevelItem> value) { }

	public void SitAvatarOn(LevelSitArea sitArea, bool snap) { }

}

