namespace StarsPass;

public class StarsPassLongBar : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public int currentMilestoneIndex; //Field offset: 0x10
		public StarsPassLongBar <>4__this; //Field offset: 0x18
		public float fillTo; //Field offset: 0x20
		public int lastShownTotalToPersist; //Field offset: 0x24

		public <>c__DisplayClass24_0() { }

		internal void <AnimateLongBarFill>b__1(float value) { }

		internal void <AnimateLongBarFill>g__AnimateFillSegment|0(int milestoneIndex, float segmentFrom) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_1
	{
		public float segmentTo; //Field offset: 0x10
		public float milestoneBoundaryFill; //Field offset: 0x14
		public int milestoneIndex; //Field offset: 0x18
		public bool isFinalSegment; //Field offset: 0x1C
		public <>c__DisplayClass24_0 CS$<>8__locals1; //Field offset: 0x20
		public Action <>9__3; //Field offset: 0x28

		public <>c__DisplayClass24_1() { }

		internal void <AnimateLongBarFill>b__2() { }

		internal void <AnimateLongBarFill>b__3() { }

	}

	private const float MILESTONE_EDGE_PADDING = 50; //Field offset: 0x0
	[SerializeField]
	private RectTransform _fillRectTransform; //Field offset: 0x20
	[SerializeField]
	private RectTransform _longBarRectTransform; //Field offset: 0x28
	[SerializeField]
	private Transform _longBarHolderTransform; //Field offset: 0x30
	[SerializeField]
	private GameObject _rightFillCornerObject; //Field offset: 0x38
	[SerializeField]
	private GameObject _longBarStartPoint; //Field offset: 0x40
	[SerializeField]
	private GameObject _milestoneToolTipCirclePrefab; //Field offset: 0x48
	[SerializeField]
	private float _bigBarFillDuration; //Field offset: 0x50
	[SerializeField]
	private float _reachedMilestoneDelayTime; //Field offset: 0x54
	private StarsPassBarManager _starsBarManager; //Field offset: 0x58
	private StarsPassViewManager _starsPassViewManager; //Field offset: 0x60
	private Image _fillImage; //Field offset: 0x68
	private Image _rightCornerImage; //Field offset: 0x70
	private RectTransform _rightCornerRect; //Field offset: 0x78
	private List<GameObject> _barFillPointsPositions; //Field offset: 0x80
	private List<StarsPassCircleTooltipButton> _circlesTooltipsList; //Field offset: 0x88
	private float _firstPointPosX; //Field offset: 0x90
	private float _lastPointPosX; //Field offset: 0x94
	private float _cornerTextureWidth; //Field offset: 0x98
	private int _milestonesAmount; //Field offset: 0x9C

	public StarsPassLongBar() { }

	private void AlignMilestonesCirclesToolTips() { }

	private void AnimateLongBarFill(float fillFrom, float fillTo, int previousMilestoneIndex, int currentMilestoneIndex, int lastShownTotalToPersist) { }

	private void ApplyInstantFill(float fillTo, bool focusOnLastReachedGift = true) { }

	private float CalculateFillAmount(int starsIndex, int milestoneIndex) { }

	private float GetLastReachedGiftFill() { }

	public void Init(StarsPassViewManager starsPassViewManager) { }

	private void OnDestroy() { }

	private void SetFirstAndLastPointsPositions() { }

	private void SetLongBarSize() { }

	private void SpawnMilestonesCirclesToolTips() { }

	private void SyncLongBar() { }

	private void UpdateLongBarFill(float fillAmount) { }

	private void UpdateLongBarRightCornerPosition(float fillAmount) { }

}

