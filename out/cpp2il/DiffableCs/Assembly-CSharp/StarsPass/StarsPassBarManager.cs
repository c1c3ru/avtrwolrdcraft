namespace StarsPass;

public class StarsPassBarManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public StarsPassBarManager <>4__this; //Field offset: 0x10
		public StarsProgress to; //Field offset: 0x18
		public float milestoneFillDuration; //Field offset: 0x2C
		public int lastShownStarValue; //Field offset: 0x30
		public Action onComplete; //Field offset: 0x38

		public <>c__DisplayClass32_0() { }

		internal void <AnimateBarProgress>g__AnimateMilestoneSegment|0(int milestoneIndex, int startStars) { }

		internal void <AnimateBarProgress>g__FinishBarProgress|1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_1
	{
		public int milestoneStarsRequired; //Field offset: 0x10
		public bool isFinalMilestone; //Field offset: 0x14
		public int milestoneIndex; //Field offset: 0x18
		public <>c__DisplayClass32_0 CS$<>8__locals1; //Field offset: 0x20

		public <>c__DisplayClass32_1() { }

		internal void <AnimateBarProgress>b__2(float value) { }

		internal void <AnimateBarProgress>b__3() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass33_0
	{
		public StarsPassBarManager <>4__this; //Field offset: 0x10
		public int milestoneIndex; //Field offset: 0x18

		public <>c__DisplayClass33_0() { }

		internal void <OnMilestoneComplete>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass40_0
	{
		public StarsPassBarManager <>4__this; //Field offset: 0x10
		public float animTime; //Field offset: 0x18

		public <>c__DisplayClass40_0() { }

		internal void <AnimateLeftStarBlob>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_0
	{
		public StarsPassBarManager <>4__this; //Field offset: 0x10
		public float animTime; //Field offset: 0x18
		public Action onComplete; //Field offset: 0x20
		public Action <>9__2; //Field offset: 0x28

		public <>c__DisplayClass41_0() { }

		internal void <AnimateGiftBoxJump>b__0() { }

		internal void <AnimateGiftBoxJump>b__1() { }

		internal void <AnimateGiftBoxJump>b__2() { }

	}

	private const string GIFT_BOX_CLAIM_IDLE_ANIM = "Claim_Idle"; //Field offset: 0x0
	private const string GIFT_BOX_STATIC_ANIM = "Static"; //Field offset: 0x0
	private const float DEFAULT_MILESTONE_FILL_DURATION = 0,65; //Field offset: 0x0
	private const string GIFT_BOX_CLAIM_START_ANIM = "Claim_Start"; //Field offset: 0x0
	[SerializeField]
	private Image _fillImage; //Field offset: 0x20
	[SerializeField]
	private Image _fillRightCorner; //Field offset: 0x28
	[SerializeField]
	private GameObject _claimObject; //Field offset: 0x30
	[SerializeField]
	private GameObject _newBadge; //Field offset: 0x38
	[SerializeField]
	private TextMeshProUGUI _currentStarsText; //Field offset: 0x40
	[SerializeField]
	private TextMeshProUGUI _targetStarsText; //Field offset: 0x48
	[SerializeField]
	private TextMeshProUGUI _currentMilestoneText; //Field offset: 0x50
	[SerializeField]
	private TextMeshProUGUI _targetMilestoneText; //Field offset: 0x58
	[SerializeField]
	private GameObject _leftStarObject; //Field offset: 0x60
	[SerializeField]
	private GameObject _targetStarObject; //Field offset: 0x68
	[SerializeField]
	private SkeletonGraphic _giftBoxSkeletonGraphic; //Field offset: 0x70
	[SerializeField]
	private bool _isClaimObjectVisible; //Field offset: 0x78
	[SerializeField]
	private float _milestoneFillDuration; //Field offset: 0x7C
	private List<Int32> _milestonesStarsRequirementList; //Field offset: 0x80
	private Vector3 _leftStarScale; //Field offset: 0x88
	private Vector3 _targetStarScale; //Field offset: 0x94
	private bool _starScalesCaptured; //Field offset: 0xA0
	private bool _isAnimating; //Field offset: 0xA1

	public StarsPassBarManager() { }

	public void AnimateBarProgress(Action onComplete) { }

	public void AnimateGiftBoxJump(float time, Action onComplete) { }

	public void AnimateLeftStarBlob(float time) { }

	public void BeginBarAnimation() { }

	private void FinalizeBarToCurrentTotal() { }

	public int GetMilestoneStarsRequirement(int milestoneIndex) { }

	public void Init(bool syncToCurrentTotal = false) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnMilestoneComplete(int milestoneIndex) { }

	private void RefreshClaimObject() { }

	private void SetBarFillAmount(float value) { }

	private void SetClaimObjectActive(bool hasClaimableGift) { }

	private void SetMilestonesStarsRequirement() { }

	public void SetNewBadgeActive(bool isActive) { }

	public void StopGiftAnim() { }

	public void StopLeftStarTween() { }

	private void SyncBar(int currentMilestoneIndex, int currentStarsIndex) { }

	private void UpdateFillRightCornerPosition(float value) { }

	private void UpdateMilestonesTexts(int currentMilestoneIndex) { }

	private void UpdateStarsBar(float currentStars, int milestoneIndex) { }

	private void UpdateTargetStarsIndexText(int currentMilestones) { }

}

