namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCGraphicCullingHandler : MonoBehaviour
{
	[SerializeField]
	private MaskableGraphic[] _graphics; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onFullyVisibleEvent; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onFullyHiddenEvent; //Field offset: 0x30
	[SerializeField]
	private bool _canCallMultipleTimes; //Field offset: 0x38
	[SerializeField]
	private bool _allowCallEventOnEnableFrame; //Field offset: 0x39
	private bool _didCallFullyVisibleEvent; //Field offset: 0x3A
	private bool _didCallFullyHiddenEvent; //Field offset: 0x3B
	private bool _isFullyVisible; //Field offset: 0x3C
	private bool _isFullyHidden; //Field offset: 0x3D
	private int _enabledFrame; //Field offset: 0x40

	public AFCGraphicCullingHandler() { }

	private void Awake() { }

	private void CallFullyHiddenEvent() { }

	private void CallFullyVisibleEvent() { }

	private void OnCullStateChanged(bool _) { }

	private void OnDestroy() { }

	private void OnEnable() { }

	private void UpdateStatus() { }

}

