namespace Spine.Unity;

[RequireComponent(typeof(Rigidbody))]
public class FollowLocationRigidbody : MonoBehaviour
{
	public Transform reference; //Field offset: 0x20
	private Rigidbody ownRigidbody; //Field offset: 0x28

	public FollowLocationRigidbody() { }

	private void Awake() { }

	private void FixedUpdate() { }

}

