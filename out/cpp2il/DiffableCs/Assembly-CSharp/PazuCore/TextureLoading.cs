namespace PazuCore;

public class TextureLoading : MonoBehaviour
{
	[SerializeField]
	protected RectTransform _shine; //Field offset: 0x20
	private float _width; //Field offset: 0x28
	private Vector2 _shineStartPosition; //Field offset: 0x2C
	private Vector2 _shineEndPosition; //Field offset: 0x34
	private float _speed; //Field offset: 0x3C
	private bool _isInited; //Field offset: 0x40

	public TextureLoading() { }

	private Vector2 GetShineEndPosition() { }

	private Vector2 GetShineStartPosition() { }

	public void Hide() { }

	private void InitIfNeeded() { }

	public void Show() { }

	private void Update() { }

}

