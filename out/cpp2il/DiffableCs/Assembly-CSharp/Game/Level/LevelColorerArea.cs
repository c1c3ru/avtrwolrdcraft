namespace Game.Level;

public class LevelColorerArea : LevelConsumerAreaBase
{
	[SerializeField]
	private Color _color; //Field offset: 0x54
	[Header("Event On Getting Color")]
	[SerializeField]
	private UnityEvent<Color> _onGettingColor; //Field offset: 0x68

	public LevelColorerArea() { }

	public Color GetColor() { }

}

