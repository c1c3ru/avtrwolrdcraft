namespace Game.Store;

public class AutoShrinkText : MonoBehaviour
{
	[SerializeField]
	private int _maxWidth; //Field offset: 0x20
	[SerializeField]
	private int _maxFontSize; //Field offset: 0x24
	[SerializeField]
	private int _minFontSize; //Field offset: 0x28
	private Text text; //Field offset: 0x30

	public AutoShrinkText() { }

	private void Awake() { }

	public void ShrinkText() { }

}

