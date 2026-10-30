namespace PazuCore;

public class SizeDeltaToPortraitScreen : MonoBehaviour
{
	[SerializeField]
	private Vector2 _tablet; //Field offset: 0x20
	[SerializeField]
	private Vector2 _tall; //Field offset: 0x28
	[SerializeField]
	private Vector2 _veryTall; //Field offset: 0x30

	public SizeDeltaToPortraitScreen() { }

	private void SetSizeDelta(Vector2 sizeDelta) { }

	private void Start() { }

}

