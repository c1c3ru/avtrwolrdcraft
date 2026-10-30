namespace UnityEngine;

[NativeHeader("Modules/Physics2D/AnchoredJoint2D.h")]
public class AnchoredJoint2D : Joint2D
{

	public Vector2 connectedAnchor
	{
		 get { } //Length: 76
	}

	public AnchoredJoint2D() { }

	public Vector2 get_connectedAnchor() { }

	private void get_connectedAnchor_Injected(out Vector2 ret) { }

}

