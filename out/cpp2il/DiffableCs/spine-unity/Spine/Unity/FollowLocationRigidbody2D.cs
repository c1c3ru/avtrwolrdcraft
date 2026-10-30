namespace Spine.Unity;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowLocationRigidbody2D : MonoBehaviour
{
	public Transform reference; //Field offset: 0x20
	public bool followFlippedX; //Field offset: 0x28
	private Rigidbody2D ownRigidbody; //Field offset: 0x30

	public FollowLocationRigidbody2D() { }

	private void Awake() { }

	private void FixedUpdate() { }

}

