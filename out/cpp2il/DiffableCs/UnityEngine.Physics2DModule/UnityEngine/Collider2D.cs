namespace UnityEngine;

[NativeHeader("Modules/Physics2D/Public/Collider2D.h")]
[RequireComponent(typeof(Transform))]
[RequiredByNativeCode(Optional = True)]
public class Collider2D : Behaviour
{

	public Bounds bounds
	{
		 get { } //Length: 104
	}

	public bool isTrigger
	{
		 set { } //Length: 68
	}

	public Vector2 offset
	{
		 get { } //Length: 76
		 set { } //Length: 72
	}

	public bool usedByComposite
	{
		 set { } //Length: 68
	}

	public bool usedByEffector
	{
		 set { } //Length: 68
	}

	public Collider2D() { }

	public Bounds get_bounds() { }

	private void get_bounds_Injected(out Bounds ret) { }

	public Vector2 get_offset() { }

	private void get_offset_Injected(out Vector2 ret) { }

	public void set_isTrigger(bool value) { }

	public void set_offset(Vector2 value) { }

	private void set_offset_Injected(ref Vector2 value) { }

	public void set_usedByComposite(bool value) { }

	public void set_usedByEffector(bool value) { }

}

