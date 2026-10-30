namespace PWC.Level;

public class LevelCharacterMakeupData
{
	public CharacterCategoryType CategoryType; //Field offset: 0x10
	public string SkinName; //Field offset: 0x18
	public Color Color; //Field offset: 0x20
	public bool IsGradient; //Field offset: 0x30
	public Color SecondColor; //Field offset: 0x34

	public LevelCharacterMakeupData() { }

}

