namespace StarsPass;

public class StarsPassCarouselPackItem : StarsPassPackItem
{
	[SerializeField]
	private GameObject _claimButton; //Field offset: 0x50
	[SerializeField]
	private Button _imageButton; //Field offset: 0x58
	[SerializeField]
	private PacksWidgetsAnimator _packsWidgetsAnimator; //Field offset: 0x60
	[CompilerGenerated]
	private Action<PacksWidgetsAnimator> ClickChoosePackAction; //Field offset: 0x68

	public event Action<PacksWidgetsAnimator> ClickChoosePackAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public StarsPassCarouselPackItem() { }

	[CompilerGenerated]
	public void add_ClickChoosePackAction(Action<PacksWidgetsAnimator> value) { }

	protected virtual void ApplyPackStatus(MilestoneStatus state) { }

	public void OnClickPack(PacksWidgetsAnimator packsSwiperAnim) { }

	public void OnPackClaimed(int packIndex) { }

	[CompilerGenerated]
	public void remove_ClickChoosePackAction(Action<PacksWidgetsAnimator> value) { }

}

