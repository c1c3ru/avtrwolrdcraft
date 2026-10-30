namespace Spine.Unity;

public interface IHasSkeletonComponent : ISpineComponent
{

	public ISkeletonComponent SkeletonComponent
	{
		 get { } //Length: 0
	}

	public ISkeletonComponent get_SkeletonComponent() { }

}

