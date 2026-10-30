namespace Spine.Unity;

[AddComponentMenu("Spine/BoneFollower")]
[ExecuteAlways]
[HelpURL("http://esotericsoftware.com/spine-unity#BoneFollower")]
public class BoneFollower : MonoBehaviour
{
	internal enum AxisOrientation
	{
		XAxis = 1,
		YAxis = 2,
	}

	public SkeletonRenderer skeletonRenderer; //Field offset: 0x20
	[SpineBone(null, "skeletonRenderer", True, False)]
	public string boneName; //Field offset: 0x28
	public bool followXYPosition; //Field offset: 0x30
	public bool followZPosition; //Field offset: 0x31
	public bool followBoneRotation; //Field offset: 0x32
	[Tooltip("Follows the skeleton's flip state by controlling this Transform's local scale.")]
	public bool followSkeletonFlip; //Field offset: 0x33
	[FormerlySerializedAs("followScale")]
	[Tooltip("Follows the target bone's local scale.")]
	public bool followLocalScale; //Field offset: 0x34
	[Tooltip("Includes the parent bone's lossy world scale. BoneFollower cannot inherit rotated/skewed scale because of UnityEngine.Transform property limitations.")]
	public bool followParentWorldScale; //Field offset: 0x35
	[Tooltip("Applies when 'Follow Skeleton Flip' is disabled but 'Follow Bone Rotation' is enabled. When flipping the skeleton by scaling its Transform, this follower's rotation is adjusted instead of its scale to follow the bone orientation. When one of the axes is flipped,  only one axis can be followed, either the X or the Y axis, which is selected here.")]
	public AxisOrientation maintainedAxisOrientation; //Field offset: 0x38
	[FormerlySerializedAs("resetOnAwake")]
	public bool initializeOnAwake; //Field offset: 0x3C
	public bool valid; //Field offset: 0x3D
	public Bone bone; //Field offset: 0x40
	private Transform skeletonTransform; //Field offset: 0x48
	private bool skeletonTransformIsParent; //Field offset: 0x50

	public SkeletonRenderer SkeletonRenderer
	{
		 get { } //Length: 8
		 set { } //Length: 36
	}

	public BoneFollower() { }

	public void Awake() { }

	public SkeletonRenderer get_SkeletonRenderer() { }

	public void HandleRebuildRenderer(SkeletonRenderer skeletonRenderer) { }

	public override void Initialize() { }

	public override void LateUpdate() { }

	private void OnDestroy() { }

	public void set_SkeletonRenderer(SkeletonRenderer value) { }

	public bool SetBone(string name) { }

}

