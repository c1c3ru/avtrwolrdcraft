namespace PazuCore;

public class PositionToLandscapeScreen : MonoBehaviour
{
	[SerializeField]
	private Vector2 _tablet; //Field offset: 0x20
	[SerializeField]
	private Vector2 _wide; //Field offset: 0x28
	[SerializeField]
	private Vector2 _veryWide; //Field offset: 0x30
	public Action OnApplyCompleted; //Field offset: 0x38

	public PositionToLandscapeScreen() { }

	private void ApplyValuesForCurrentScreen() { }

	private void SetPosition(Vector2 position) { }

	private void Start() { }

}

