namespace PWC.AvatarMaker;

public class AWSpineColorModel
{
	public Color DisplayColor; //Field offset: 0x10
	public Color[] Colors; //Field offset: 0x20

	public AWSpineColorModel() { }

	public Color GetColor(int index) { }

	public Color[] GetColorsCopy() { }

	public int GetColorsCount() { }

}

