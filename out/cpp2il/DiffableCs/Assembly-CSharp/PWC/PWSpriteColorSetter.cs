namespace PWC;

public class PWSpriteColorSetter : MonoBehaviour
{
	[SerializeField]
	private PWSpriteColorType _colorType; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x28
	[SerializeField]
	private Color _color; //Field offset: 0x30

	public PWSpriteColorSetter() { }

	private void Awake() { }

}

