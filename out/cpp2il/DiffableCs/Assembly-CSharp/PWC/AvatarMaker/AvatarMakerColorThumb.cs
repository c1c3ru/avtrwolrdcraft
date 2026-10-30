namespace PWC.AvatarMaker;

public class AvatarMakerColorThumb : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	internal class ColorButtonConfig
	{
		public AWSpineColorModel colorModel; //Field offset: 0x10
		public int categoryType; //Field offset: 0x18
		public Func<Int32> getMultiColorIndexAction; //Field offset: 0x20
		public bool isPremium; //Field offset: 0x28

		public ColorButtonConfig() { }

	}

	[CompilerGenerated]
	private static Action<ColorButtonConfig> OnColorThumbClickAction; //Field offset: 0x0
	[SerializeField]
	private Image _fillUp; //Field offset: 0x20
	[SerializeField]
	private Image _fillDown; //Field offset: 0x28
	[SerializeField]
	private GameObject _premiumFrame; //Field offset: 0x30
	private ColorButtonConfig _buttonConfig; //Field offset: 0x38

	public static event Action<ColorButtonConfig> OnColorThumbClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public AvatarMakerColorThumb() { }

	[CompilerGenerated]
	public static void add_OnColorThumbClickAction(Action<ColorButtonConfig> value) { }

	public void Init(ColorButtonConfig buttonConfig) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnColorThumbClickAction(Action<ColorButtonConfig> value) { }

}

