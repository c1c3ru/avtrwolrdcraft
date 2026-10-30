//Type is in global namespace

public class SpineObjects : ObjectAnimProperty
{
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x60
	public String[] _animList; //Field offset: 0x68
	[HideInInspector]
	public int currentAnimIndex; //Field offset: 0x70
	[HideInInspector]
	public float skeltonAnimTimeLeft; //Field offset: 0x74

	public SpineObjects() { }

	[CompilerGenerated]
	private float <PlayCostumeAnimations>g__GetAnimLenght|5_0(string animName) { }

	public virtual void PlayAnimation() { }

	public void PlayCostumeAnimations() { }

}

