namespace PWC.Json;

public class PJVector2
{
	public float x; //Field offset: 0x10
	public float y; //Field offset: 0x14

	public PJVector2() { }

	public PJVector2(float x, float y) { }

	public PJVector2(Vector2 vector2) { }

	public PJVector2(Vector3 vector3) { }

	public static PJVector2 CreateTruncated(Vector2 vector) { }

	public Vector2 GetVector2() { }

}

