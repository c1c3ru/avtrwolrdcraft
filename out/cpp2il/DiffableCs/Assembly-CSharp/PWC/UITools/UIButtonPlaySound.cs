namespace PWC.UITools;

public class UIButtonPlaySound : MonoBehaviour
{
	[SerializeField]
	private string _soundName; //Field offset: 0x20
	[SerializeField]
	private bool _isLoop; //Field offset: 0x28
	private Button _button; //Field offset: 0x30

	public UIButtonPlaySound() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void Play() { }

}

