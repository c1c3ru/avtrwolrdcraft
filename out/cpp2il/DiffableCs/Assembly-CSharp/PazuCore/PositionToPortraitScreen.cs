namespace PazuCore;

public class PositionToPortraitScreen : MonoBehaviour
{
	[SerializeField]
	private Vector2 _tablet; //Field offset: 0x20
	[SerializeField]
	private Vector2 _tall; //Field offset: 0x28
	[SerializeField]
	private Vector2 _veryTall; //Field offset: 0x30
	public Action OnApplyCompleted; //Field offset: 0x38

	public PositionToPortraitScreen() { }

	private void ApplyValuesForCurrentScreen() { }

	private void SetPosition(Vector2 position) { }

	private void Start() { }

}

