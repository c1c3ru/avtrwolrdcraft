namespace PWC;

[RequireComponent(typeof(RectTransform))]
public class UISlideAnimator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public UISlideAnimator <>4__this; //Field offset: 0x10
		public bool value; //Field offset: 0x18

		public <>c__DisplayClass23_0() { }

		internal void <Animate>b__0(Vector3 position) { }

		internal void <Animate>b__1() { }

	}

	[Header("Slide")]
	[SerializeField]
	[Tooltip("Local-space offset applied when sliding in. The currency viewer used (0, -160).")]
	private Vector2 _showOffset; //Field offset: 0x20
	[SerializeField]
	private float _moveDuration; //Field offset: 0x28
	[Header("Auto return")]
	[SerializeField]
	[Tooltip("When sliding in, automatically slide back to the resting position afterwards.")]
	private bool _autoReturn; //Field offset: 0x2C
	[SerializeField]
	[Tooltip("Seconds to hold at the shown position before the automatic return.")]
	private float _holdDelayBeforeReturn; //Field offset: 0x30
	[Header("Easing")]
	[SerializeField]
	private LeanTweenType _showEase; //Field offset: 0x34
	[SerializeField]
	private LeanTweenType _hideEase; //Field offset: 0x38
	[CompilerGenerated]
	private Action OnAnimationStart; //Field offset: 0x40
	[CompilerGenerated]
	private Action OnAnimationEnd; //Field offset: 0x48
	private RectTransform _rectTransform; //Field offset: 0x50
	private Vector3 _restingPosition; //Field offset: 0x58
	private bool _initialized; //Field offset: 0x64
	private bool _isMoving; //Field offset: 0x65
	private int _tweenId; //Field offset: 0x68

	public event Action OnAnimationEnd
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action OnAnimationStart
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public bool IsMoving
	{
		 get { } //Length: 8
	}

	public UISlideAnimator() { }

	[CompilerGenerated]
	public void add_OnAnimationEnd(Action value) { }

	[CompilerGenerated]
	public void add_OnAnimationStart(Action value) { }

	public void Animate(bool value) { }

	private void EnsureInitialized() { }

	public bool get_IsMoving() { }

	public void Hide() { }

	[CompilerGenerated]
	public void remove_OnAnimationEnd(Action value) { }

	[CompilerGenerated]
	public void remove_OnAnimationStart(Action value) { }

	public void Show() { }

	private void Start() { }

}

