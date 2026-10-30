namespace Spine.Unity;

public sealed class ISkeletonAnimationDelegate : MulticastDelegate
{

	public ISkeletonAnimationDelegate(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(ISkeletonAnimation animated, AsyncCallback callback, object object) { }

	public override void EndInvoke(IAsyncResult result) { }

	public override void Invoke(ISkeletonAnimation animated) { }

}

