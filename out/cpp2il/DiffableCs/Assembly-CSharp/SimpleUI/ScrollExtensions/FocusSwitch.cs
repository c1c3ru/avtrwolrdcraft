namespace SimpleUI.ScrollExtensions;

public class FocusSwitch : MonoBehaviour
{
	public DynamicScrollPoint scrollPoint; //Field offset: 0x20
	[Range(0, 1)]
	public float switchDistance; //Field offset: 0x28
	public BoundBool OnSwitchState; //Field offset: 0x30

	public FocusSwitch() { }

	private void Awake() { }

	private void CheckState(float distance) { }

}

