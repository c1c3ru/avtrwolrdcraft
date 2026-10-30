namespace StarsPass;

public abstract class StarsPassPackItem : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public StarsPassPackItem <>4__this; //Field offset: 0x10
		public Action onComplete; //Field offset: 0x18

		public <>c__DisplayClass13_0() { }

		internal void <PlayUnlockingAnimation>b__0(float value) { }

		internal void <PlayUnlockingAnimation>b__1() { }

	}

	[SerializeField]
	protected Image[] _images; //Field offset: 0x20
	[SerializeField]
	protected TextMeshProUGUI[] _texts; //Field offset: 0x28
	[SerializeField]
	protected GameObject _ownedBadge; //Field offset: 0x30
	[SerializeField]
	protected float _unlockingTimeDuration; //Field offset: 0x38
	[SerializeField]
	private StarsPassCircleTooltipButton _tooltipButton; //Field offset: 0x40
	protected int _milestoneIndex; //Field offset: 0x48

	public int MilestoneIndex
	{
		 get { } //Length: 8
	}

	protected StarsPassPackItem() { }

	protected abstract void ApplyPackStatus(MilestoneStatus state) { }

	public int get_MilestoneIndex() { }

	public float GetUnlockingTimeDuration() { }

	public void InitTooltip(int starsRequirement) { }

	public void PlayUnlockingAnimation(Action onComplete) { }

	protected void SetAssetsFadeValue(float value) { }

	public void SetMilestoneIndex(int index) { }

	public void SetPackStatus(MilestoneStatus state) { }

}

