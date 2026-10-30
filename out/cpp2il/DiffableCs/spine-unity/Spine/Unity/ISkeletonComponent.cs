namespace Spine.Unity;

public interface ISkeletonComponent : ISpineComponent
{

	public Skeleton Skeleton
	{
		 get { } //Length: 0
	}

	public SkeletonDataAsset SkeletonDataAsset
	{
		 get { } //Length: 0
	}

	public Skeleton get_Skeleton() { }

	public SkeletonDataAsset get_SkeletonDataAsset() { }

}

