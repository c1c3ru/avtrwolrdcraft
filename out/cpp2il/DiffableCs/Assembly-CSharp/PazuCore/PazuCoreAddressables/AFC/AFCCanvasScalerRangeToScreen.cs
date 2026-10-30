namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCCanvasScalerRangeToScreen : AFCScreenHandlerBase
{
	internal enum PropertyType
	{
		None = 0,
		MatchWidthOrHeight = 1,
		Width = 2,
		Height = 3,
	}

	[SerializeField]
	private UScreenType _screenType; //Field offset: 0x24
	[SerializeField]
	private PropertyType _propertyType; //Field offset: 0x28
	[Header("Screen Ratio Range")]
	[SerializeField]
	private float _screenRatioFrom; //Field offset: 0x2C
	[SerializeField]
	private float _screenRatioTo; //Field offset: 0x30
	[Header("Property Value Range")]
	[SerializeField]
	private float _propertyFrom; //Field offset: 0x34
	[SerializeField]
	private float _propertyTo; //Field offset: 0x38

	public AFCCanvasScalerRangeToScreen() { }

	public virtual void Apply() { }

}

