namespace UnityEngine;

[NativeHeader("Modules/Physics2D/Joint2D.h")]
[RequireComponent(typeof(Transform), typeof(Rigidbody2D))]
public class Joint2D : Behaviour
{

	public Rigidbody2D connectedBody
	{
		 get { } //Length: 60
	}

	public Joint2D() { }

	public Rigidbody2D get_connectedBody() { }

}

