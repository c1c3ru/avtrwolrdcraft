namespace Game.Level.MovingTraingBackground;

public class LevelStationButtonState
{
	[SerializeField]
	private Color _color; //Field offset: 0x10
	[SerializeField]
	private PWSpriteColorType _colorType; //Field offset: 0x20
	[SerializeField]
	private Sprite _sprite; //Field offset: 0x28

	public Color Color
	{
		 get { } //Length: 12
	}

	public PWSpriteColorType ColorType
	{
		 get { } //Length: 8
	}

	public Sprite Sprite
	{
		 get { } //Length: 8
	}

	public LevelStationButtonState() { }

	public Color get_Color() { }

	public PWSpriteColorType get_ColorType() { }

	public Sprite get_Sprite() { }

}

