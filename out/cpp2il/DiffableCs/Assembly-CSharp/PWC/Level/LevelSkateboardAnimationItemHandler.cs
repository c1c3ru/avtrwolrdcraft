namespace PWC.Level;

public class LevelSkateboardAnimationItemHandler : LevelSkateboardAnimationItemHandlerBase
{
	[SerializeField]
	private GameObject _boneFollowerObject; //Field offset: 0x48
	[SerializeField]
	private GameObject _staticSkateboard; //Field offset: 0x50
	private bool _isBoneFollowerStarted; //Field offset: 0x58
	private BoneFollower _boneFollower; //Field offset: 0x60

	public LevelSkateboardAnimationItemHandler() { }

	private void DestroyBoneFollower() { }

	public virtual void EndBoneFollower() { }

	public virtual void PlayRailAnimation(bool isStart) { }

	public virtual void PlaySuitableIdle(SkatingMode mode, bool isAdd = false) { }

	public virtual void StartBoneFollower(ILevelAvatar avatar) { }

}

