namespace UnityEngine;

[NativeHeader("Modules/Physics2D/Public/EdgeCollider2D.h")]
public sealed class EdgeCollider2D : Collider2D
{

	public int pointCount
	{
		 get { } //Length: 60
	}

	public Vector2[] points
	{
		 get { } //Length: 60
	}

	public EdgeCollider2D() { }

	public int get_pointCount() { }

	public Vector2[] get_points() { }

}

