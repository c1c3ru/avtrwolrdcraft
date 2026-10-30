namespace Spine.Unity;

[AddComponentMenu("Spine/SkeletonUtilityBone")]
[ExecuteAlways]
[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonUtilityBone")]
public class SkeletonUtilityBone : MonoBehaviour
{
	internal enum Mode
	{
		Follow = 0,
		Override = 1,
	}

	internal enum UpdatePhase
	{
		Local = 0,
		World = 1,
		Complete = 2,
	}

	public string boneName; //Field offset: 0x20
	public Transform parentReference; //Field offset: 0x28
	public Mode mode; //Field offset: 0x30
	public bool position; //Field offset: 0x34
	public bool rotation; //Field offset: 0x35
	public bool scale; //Field offset: 0x36
	public bool zPosition; //Field offset: 0x37
	[Range(0, 1)]
	public float overrideAlpha; //Field offset: 0x38
	public SkeletonUtility hierarchy; //Field offset: 0x40
	public Bone bone; //Field offset: 0x48
	public bool transformLerpComplete; //Field offset: 0x50
	public bool valid; //Field offset: 0x51
	private Transform cachedTransform; //Field offset: 0x58
	private Transform skeletonTransform; //Field offset: 0x60
	private bool incompatibleTransformMode; //Field offset: 0x68

	public bool IncompatibleTransformMode
	{
		 get { } //Length: 8
	}

	public SkeletonUtilityBone() { }

	public void AddBoundingBox(string skinName, string slotName, string attachmentName) { }

	public static bool BoneTransformModeIncompatible(Bone bone) { }

	public void DoUpdate(UpdatePhase phase) { }

	public bool get_IncompatibleTransformMode() { }

	private void HandleOnReset() { }

	private void OnDisable() { }

	private void OnEnable() { }

	public void Reset() { }

}

