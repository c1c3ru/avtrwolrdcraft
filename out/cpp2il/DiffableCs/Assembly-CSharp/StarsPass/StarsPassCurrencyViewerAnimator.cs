namespace StarsPass;

public class StarsPassCurrencyViewerAnimator : MonoBehaviour
{
	private int _tweenId; //Field offset: 0x20
	private bool _isMoving; //Field offset: 0x24
	private int _claimCount; //Field offset: 0x28
	private RectTransform _rectTransform; //Field offset: 0x30
	private Vector2 _localPosition; //Field offset: 0x38
	private float _upPosYValue; //Field offset: 0x40
	private float _downPosYValue; //Field offset: 0x44
	private float _animSpeed; //Field offset: 0x48
	private float _goDownValue; //Field offset: 0x4C

	public StarsPassCurrencyViewerAnimator() { }

	[CompilerGenerated]
	private void <AnimateDown>b__10_0(float localYPosition) { }

	[CompilerGenerated]
	private void <AnimateDown>b__10_1() { }

	[CompilerGenerated]
	private void <AnimateUp>b__11_0(float localYPosition) { }

	[CompilerGenerated]
	private void <AnimateUp>b__11_1() { }

	public void AnimateDown() { }

	public void AnimateUp() { }

	public void Init() { }

}

