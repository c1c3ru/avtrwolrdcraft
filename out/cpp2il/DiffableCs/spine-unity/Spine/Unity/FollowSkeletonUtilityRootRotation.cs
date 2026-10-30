namespace Spine.Unity;

public class FollowSkeletonUtilityRootRotation : MonoBehaviour
{
	private const float FLIP_ANGLE_THRESHOLD = 100; //Field offset: 0x0
	public Transform reference; //Field offset: 0x20
	private Vector3 prevLocalEulerAngles; //Field offset: 0x28

	public FollowSkeletonUtilityRootRotation() { }

	private void CompensatePositionToXRotation() { }

	private void CompensatePositionToYRotation() { }

	private void FixedUpdate() { }

	private void Start() { }

}

