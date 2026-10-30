namespace Spine.Unity;

[AddComponentMenu("Spine/Point Follower")]
[ExecuteAlways]
[HelpURL("http://esotericsoftware.com/spine-unity#PointFollower")]
public class PointFollower : MonoBehaviour, IHasSkeletonRenderer, ISpineComponent, IHasSkeletonComponent
{
	public SkeletonRenderer skeletonRenderer; //Field offset: 0x20
	[SpineSlot(null, "skeletonRenderer", False, True, False)]
	public string slotName; //Field offset: 0x28
	[SpineAttachment(True, False, False, "slotName", "skeletonRenderer", null, True, True)]
	public string pointAttachmentName; //Field offset: 0x30
	public bool followRotation; //Field offset: 0x38
	public bool followSkeletonFlip; //Field offset: 0x39
	public bool followSkeletonZPosition; //Field offset: 0x3A
	private Transform skeletonTransform; //Field offset: 0x40
	private bool skeletonTransformIsParent; //Field offset: 0x48
	private PointAttachment point; //Field offset: 0x50
	private Bone bone; //Field offset: 0x58
	private bool valid; //Field offset: 0x60

	public bool IsValid
	{
		 get { } //Length: 8
	}

	public override ISkeletonComponent SkeletonComponent
	{
		 get { } //Length: 8
	}

	public override SkeletonRenderer SkeletonRenderer
	{
		 get { } //Length: 8
	}

	public PointFollower() { }

	public bool get_IsValid() { }

	public override ISkeletonComponent get_SkeletonComponent() { }

	public override SkeletonRenderer get_SkeletonRenderer() { }

	private void HandleRebuildRenderer(SkeletonRenderer skeletonRenderer) { }

	public void Initialize() { }

	public void LateUpdate() { }

	private void OnDestroy() { }

	private void UpdateReferences() { }

}

