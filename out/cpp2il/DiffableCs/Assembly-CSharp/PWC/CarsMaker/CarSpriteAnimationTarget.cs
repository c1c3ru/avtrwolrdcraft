namespace PWC.CarsMaker;

public class CarSpriteAnimationTarget
{
	public Transform Target; //Field offset: 0x10
	public Vector3 PositionOffset; //Field offset: 0x18
	public Vector3 RotationOffset; //Field offset: 0x24
	public float SpinDegreesPerSecond; //Field offset: 0x30
	public string ShaderFloatName; //Field offset: 0x38
	public float ShaderFloatValue; //Field offset: 0x40
	public CarSpriteShaderFloatSource ShaderFloatSource; //Field offset: 0x44

	public CarSpriteAnimationTarget() { }

}

