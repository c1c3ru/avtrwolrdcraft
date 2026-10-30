namespace Spine.Unity;

[ExecuteAlways]
[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonUtilityConstraint")]
[RequireComponent(typeof(SkeletonUtilityBone))]
public abstract class SkeletonUtilityConstraint : MonoBehaviour
{
	protected SkeletonUtilityBone bone; //Field offset: 0x20
	protected SkeletonUtility hierarchy; //Field offset: 0x28

	protected SkeletonUtilityConstraint() { }

	public abstract void DoUpdate() { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

}

