namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCFitToScreen : AFCUnityMessageDrivenHandlerBase
{
	[SerializeField]
	private EffectType _effectType; //Field offset: 0x24
	[SerializeField]
	private RectTransform _screen; //Field offset: 0x28

	public AFCFitToScreen() { }

	private void Fit() { }

	public virtual void PerformAction() { }

}

