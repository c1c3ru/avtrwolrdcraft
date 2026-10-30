namespace StarsPass;

public class StarsPassCircleTooltipButton : ButtonBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public StarsPassCircleTooltipButton <>4__this; //Field offset: 0x10
		public float currentScale; //Field offset: 0x18
		public float animTime; //Field offset: 0x1C

		public <>c__DisplayClass15_0() { }

		internal void <PlayCircleJumpReachedAnimation>b__0() { }

	}

	private static StoreTweenToolipHandle currentStoreTweenTooltipHandle; //Field offset: 0x0
	[SerializeField]
	private RectTransform _bubble; //Field offset: 0x20
	[SerializeField]
	private bool _shouldStickToScrollRect; //Field offset: 0x28
	[SerializeField]
	private TextMeshProUGUI _bubbleText; //Field offset: 0x30
	[SerializeField]
	private Button _circleButton; //Field offset: 0x38
	[SerializeField]
	private Image _circleImage; //Field offset: 0x40
	[SerializeField]
	private Color _milestoneReachedColor; //Field offset: 0x48
	private Vector2 _anchoredPosition; //Field offset: 0x58
	private StoreTweenToolipHandle _tweenTooltipHandle; //Field offset: 0x60
	private int _starsRequirementIndex; //Field offset: 0x68
	private int _totalStarsInPass; //Field offset: 0x6C
	private int _starsToUnlockMilestone; //Field offset: 0x70

	public StarsPassCircleTooltipButton() { }

	[CompilerGenerated]
	private void <OnClick>b__14_0() { }

	public void Init() { }

	public void MarkCircleAsReached() { }

	protected virtual void OnClick() { }

	private void OnDestroy() { }

	public void PlayCircleJumpReachedAnimation(float animTime) { }

	public void SetStarsRequirement(int starsRequirementIndex) { }

}

