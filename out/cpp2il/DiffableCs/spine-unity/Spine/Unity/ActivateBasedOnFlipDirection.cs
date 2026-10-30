namespace Spine.Unity;

public class ActivateBasedOnFlipDirection : MonoBehaviour
{
	public SkeletonRenderer skeletonRenderer; //Field offset: 0x20
	public SkeletonGraphic skeletonGraphic; //Field offset: 0x28
	public GameObject activeOnNormalX; //Field offset: 0x30
	public GameObject activeOnFlippedX; //Field offset: 0x38
	private HingeJoint2D[] jointsNormalX; //Field offset: 0x40
	private HingeJoint2D[] jointsFlippedX; //Field offset: 0x48
	private ISkeletonComponent skeletonComponent; //Field offset: 0x50
	private bool wasFlippedXBefore; //Field offset: 0x58

	public ActivateBasedOnFlipDirection() { }

	private void CompensateMovementAfterFlipX(Transform toActivate, Transform toDeactivate) { }

	private void FixedUpdate() { }

	private void HandleFlip(bool isFlippedX) { }

	private void ResetJointPositions(HingeJoint2D[] joints) { }

	private void Start() { }

}

