namespace Game.Level;

public class LevelColorableArea : LevelConsumerAreaBase
{
	[SerializeField]
	private LevelRuntimeColoredSpriteHandler _colorHandler; //Field offset: 0x58

	public LevelColorableArea() { }

	public void SetColor(Color color, PWSpriteColorType colorType) { }

}

