namespace Game.Level;

public struct LevelZiplineSeatBezierGroupData
{
	public Vector2 point1; //Field offset: 0x0
	public Vector2 handle1; //Field offset: 0x8
	public Vector2 handle2; //Field offset: 0x10
	public Vector2 point2; //Field offset: 0x18

	private float EvaluateImplement(float t) { }

	public bool TryEvaluate(float xPosition, out float outY) { }

}

