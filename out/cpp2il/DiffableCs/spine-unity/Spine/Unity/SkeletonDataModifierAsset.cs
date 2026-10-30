namespace Spine.Unity;

public abstract class SkeletonDataModifierAsset : ScriptableObject
{

	protected SkeletonDataModifierAsset() { }

	public abstract void Apply(SkeletonData skeletonData) { }

}

