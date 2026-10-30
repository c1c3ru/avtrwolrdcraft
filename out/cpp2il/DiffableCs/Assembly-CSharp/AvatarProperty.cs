//Type is in global namespace

public class AvatarProperty : ObjectAnimProperty
{
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x60
	[HideInInspector]
	public LevelCharacter levelCharacter; //Field offset: 0x68
	public int avatarId; //Field offset: 0x70
	public String[] animList; //Field offset: 0x78
	[HideInInspector]
	public int currentAnimIndex; //Field offset: 0x80
	[HideInInspector]
	public float skeltonAnimTimeLeft; //Field offset: 0x84
	public List<String> skins; //Field offset: 0x88

	public AvatarProperty() { }

	[CompilerGenerated]
	private float <PlayCostumeAnimations>g__GetAnimLenght|9_0(string animName) { }

	public virtual void PlayAnimation() { }

	public void PlayCostumeAnimations() { }

	public void SetNewAvatar(LevelCharacter levelCharacter) { }

	public void SetSkins() { }

	public void SyncAvatar() { }

}

