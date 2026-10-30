namespace ScreenScripts;

public class FitToScreen : MonoBehaviour
{
	[HideInInspector]
	public bool CanShowAspectRationBool; //Field offset: 0x20
	[HideInInspector]
	public bool IsRectTransform; //Field offset: 0x21
	[SerializeField]
	private bool _initiateInStart; //Field offset: 0x22
	[SerializeField]
	private EffectType _effectType; //Field offset: 0x24
	[ConditionalField("IsRectTransform", True, True, (array) null)]
	[SerializeField]
	private RectTransform _screen; //Field offset: 0x28
	[ConditionalField("CanShowAspectRationBool", True, True, (array) null)]
	[SerializeField]
	private bool _keepAspectRatio; //Field offset: 0x30

	[HideInInspector]
	public EffectType EffectType
	{
		 get { } //Length: 8
	}

	public FitToScreen() { }

	public void Fit() { }

	public EffectType get_EffectType() { }

	private void Start() { }

}

