namespace Spine.Unity;

[AddComponentMenu("Spine/UI/BoneFollowerGraphic")]
[DisallowMultipleComponent]
[ExecuteAlways]
[HelpURL("http://esotericsoftware.com/spine-unity#BoneFollowerGraphic")]
[RequireComponent(typeof(RectTransform))]
public class BoneFollowerGraphic : MonoBehaviour
{
	public SkeletonGraphic skeletonGraphic; //Field offset: 0x20
	public bool initializeOnAwake; //Field offset: 0x28
	[SpineBone(null, "skeletonGraphic", True, False)]
	public string boneName; //Field offset: 0x30
	public bool followBoneRotation; //Field offset: 0x38
	[Tooltip("Follows the skeleton's flip state by controlling this Transform's local scale.")]
	public bool followSkeletonFlip; //Field offset: 0x39
	[Tooltip("Follows the target bone's local scale.")]
	public bool followLocalScale; //Field offset: 0x3A
	[Tooltip("Includes the parent bone's lossy world scale. BoneFollower cannot inherit rotated/skewed scale because of UnityEngine.Transform property limitations.")]
	public bool followParentWorldScale; //Field offset: 0x3B
	public bool followXYPosition; //Field offset: 0x3C
	public bool followZPosition; //Field offset: 0x3D
	[Tooltip("Applies when 'Follow Skeleton Flip' is disabled but 'Follow Bone Rotation' is enabled. When flipping the skeleton by scaling its Transform, this follower's rotation is adjusted instead of its scale to follow the bone orientation. When one of the axes is flipped,  only one axis can be followed, either the X or the Y axis, which is selected here.")]
	public AxisOrientation maintainedAxisOrientation; //Field offset: 0x40
	public Bone bone; //Field offset: 0x48
	private Transform skeletonTransform; //Field offset: 0x50
	private bool skeletonTransformIsParent; //Field offset: 0x58
	public bool valid; //Field offset: 0x59

	public SkeletonGraphic SkeletonGraphic
	{
		 get { } //Length: 8
		 set { } //Length: 36
	}

	public BoneFollowerGraphic() { }

	public void Awake() { }

	public SkeletonGraphic get_SkeletonGraphic() { }

	public override void Initialize() { }

	public override void LateUpdate() { }

	public void set_SkeletonGraphic(SkeletonGraphic value) { }

	public bool SetBone(string name) { }

}

