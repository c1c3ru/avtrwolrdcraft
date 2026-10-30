namespace PWC.AvatarSpine;

public class AvatarSpineColorsConfig : ScriptableObject
{
	internal class PartConfig
	{
		public string textureName; //Field offset: 0x10
		public Color[] colors; //Field offset: 0x18

		public PartConfig() { }

	}

	public SpineType spineType; //Field offset: 0x18
	public string skinName; //Field offset: 0x20
	public PartConfig[] parts; //Field offset: 0x28

	public AvatarSpineColorsConfig() { }

}

