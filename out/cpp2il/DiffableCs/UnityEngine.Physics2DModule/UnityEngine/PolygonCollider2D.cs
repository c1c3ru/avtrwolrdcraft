namespace UnityEngine;

[NativeHeader("Modules/Physics2D/Public/PolygonCollider2D.h")]
public sealed class PolygonCollider2D : Collider2D
{

	public int pathCount
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public Vector2[] points
	{
		[NativeMethod("GetPoints_Binding")]
		 get { } //Length: 60
	}

	public PolygonCollider2D() { }

	public int get_pathCount() { }

	[NativeMethod("GetPoints_Binding")]
	public Vector2[] get_points() { }

	public Vector2[] GetPath(int index) { }

	public int GetPath(int index, List<Vector2> points) { }

	[NativeMethod("GetPath_Binding")]
	private Vector2[] GetPath_Internal(int index) { }

	[NativeMethod("GetPathList_Binding")]
	private int GetPathList_Internal(int index, List<Vector2> points) { }

	public void set_pathCount(int value) { }

	public void SetPath(int index, Vector2[] points) { }

	public void SetPath(int index, List<Vector2> points) { }

	[NativeMethod("SetPath_Binding")]
	private void SetPath_Internal(int index, Vector2[] points) { }

	[NativeMethod("SetPathList_Binding")]
	private void SetPathList_Internal(int index, List<Vector2> points) { }

}

