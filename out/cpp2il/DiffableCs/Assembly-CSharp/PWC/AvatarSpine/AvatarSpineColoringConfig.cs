namespace PWC.AvatarSpine;

[IsReadOnly]
public struct AvatarSpineColoringConfig
{
	public readonly AvatarSpineColoringType avatarSpineColoringType; //Field offset: 0x0
	public readonly AvatarSpineRotationConfig rotationConfig; //Field offset: 0x8
	public readonly PWSpriteColorType colorType; //Field offset: 0x10
	public readonly int multiColorCount; //Field offset: 0x14

	public AvatarSpineColoringConfig(AvatarSpineColoringType avatarSpineColoringType, AvatarSpineRotationConfig rotationConfig, PWSpriteColorType colorType, int multiColorCount = 0) { }

	public static AvatarSpineColoringConfig CreateGradient(PWSpriteColorType colorType, AvatarSpineRotationConfig rotationConfig = null) { }

	public static AvatarSpineColoringConfig CreateMulti(PWSpriteColorType colorType, int multiColorCount) { }

	public static AvatarSpineColoringConfig CreateSingle(PWSpriteColorType colorType) { }

}

