namespace UnityEngine;

[NativeHeader("Modules/Physics2D/Public/Rigidbody2D.h")]
[RequireComponent(typeof(Transform))]
public sealed class Rigidbody2D : Component
{

	public RigidbodyType2D bodyType
	{
		[NativeMethod("SetBodyType_Binding")]
		 set { } //Length: 68
	}

	public float gravityScale
	{
		 get { } //Length: 60
		 set { } //Length: 76
	}

	public bool isKinematic
	{
		 set { } //Length: 76
	}

	public Vector2 position
	{
		 get { } //Length: 76
		 set { } //Length: 72
	}

	public float rotation
	{
		 get { } //Length: 60
		 set { } //Length: 76
	}

	public Vector2 velocity
	{
		 get { } //Length: 76
		 set { } //Length: 72
	}

	public Rigidbody2D() { }

	public float get_gravityScale() { }

	public Vector2 get_position() { }

	private void get_position_Injected(out Vector2 ret) { }

	public float get_rotation() { }

	public Vector2 get_velocity() { }

	private void get_velocity_Injected(out Vector2 ret) { }

	public void MovePosition(Vector2 position) { }

	private void MovePosition_Injected(ref Vector2 position) { }

	public void MoveRotation(float angle) { }

	[NativeMethod("MoveRotation")]
	private void MoveRotation_Angle(float angle) { }

	[NativeMethod("SetBodyType_Binding")]
	public void set_bodyType(RigidbodyType2D value) { }

	public void set_gravityScale(float value) { }

	public void set_isKinematic(bool value) { }

	public void set_position(Vector2 value) { }

	private void set_position_Injected(ref Vector2 value) { }

	public void set_rotation(float value) { }

	public void set_velocity(Vector2 value) { }

	private void set_velocity_Injected(ref Vector2 value) { }

}

