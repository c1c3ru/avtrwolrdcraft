namespace StarsPass;

public class PacksWidgetsAnimator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public int index; //Field offset: 0x10
		public PacksWidgetsAnimator <>4__this; //Field offset: 0x18

		public <>c__DisplayClass35_0() { }

		internal void <FadeInDots>b__0(float value) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass36_0
	{
		public Image frontImage; //Field offset: 0x10
		public Image rightImage; //Field offset: 0x18
		public Image leftImage; //Field offset: 0x20

		public <>c__DisplayClass36_0() { }

		internal void <FadeInWidgets>b__0(float value) { }

		internal void <FadeInWidgets>b__1(float value) { }

		internal void <FadeInWidgets>b__2(float value) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass39_0
	{
		public Image frontImage; //Field offset: 0x10
		public Transform lastChild; //Field offset: 0x18
		public Image incomingImage; //Field offset: 0x20

		public <>c__DisplayClass39_0() { }

		internal void <WidgetsCarouselAnim>b__0(float value) { }

		internal void <WidgetsCarouselAnim>b__1() { }

		internal void <WidgetsCarouselAnim>b__2(float value) { }

	}

	[CompilerGenerated]
	private sealed class <RotateCarouselLoop>d__32 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PacksWidgetsAnimator <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <RotateCarouselLoop>d__32(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private const int LEFT_WIDGET_INDEX = 0; //Field offset: 0x0
	private const int RIGHT_WIDGET_INDEX = 1; //Field offset: 0x0
	private const int FRONT_WIDGET_INDEX = 2; //Field offset: 0x0
	[SerializeField]
	private GameObject _widgetsCarouselHolder; //Field offset: 0x20
	[SerializeField]
	private GameObject _titleTextObject; //Field offset: 0x28
	[SerializeField]
	private Color _enableColor; //Field offset: 0x30
	[SerializeField]
	private Color _disableColor; //Field offset: 0x40
	[SerializeField]
	private Image[] _dots; //Field offset: 0x50
	[SerializeField]
	private Image[] _widgetImages; //Field offset: 0x58
	[SerializeField]
	private float _currentWidgetSize; //Field offset: 0x60
	[SerializeField]
	private float _bgWidgetsSize; //Field offset: 0x64
	[SerializeField]
	private float _timeBetweenAnims; //Field offset: 0x68
	[SerializeField]
	private float _swipeTime; //Field offset: 0x6C
	[SerializeField]
	private float _timeToMoveToLeft; //Field offset: 0x70
	[SerializeField]
	private float _fadeValue; //Field offset: 0x74
	[SerializeField]
	private GameObject _chosenWidgetObject; //Field offset: 0x78
	[SerializeField]
	private Image _chosenWidgetImage; //Field offset: 0x80
	[SerializeField]
	private float _chosenWidgetScaleTo; //Field offset: 0x88
	[SerializeField]
	private float _chosenWidgetAnimTime; //Field offset: 0x8C
	private Transform _widgetsParent; //Field offset: 0x90
	private int _currentDotIndex; //Field offset: 0x98
	private List<Sprite> _packsWidgets; //Field offset: 0xA0
	private Vector2[] _widgetsPositions; //Field offset: 0xA8
	private Image _currentImage; //Field offset: 0xB0
	private Sprite _chosenWidgetSprite; //Field offset: 0xB8
	private List<Int32> _packsIndexes; //Field offset: 0xC0
	private StarsPassViewManager _starsPassViewManager; //Field offset: 0xC8
	private float _currentFade; //Field offset: 0xD0
	private bool _isRotateCarousel; //Field offset: 0xD4
	private bool _isCarouselRunning; //Field offset: 0xD5
	private WaitForSeconds _rotateDelay; //Field offset: 0xD8
	private Coroutine _rotateCoroutine; //Field offset: 0xE0

	public PacksWidgetsAnimator() { }

	public void AddPackIndexToPacksList(int packIndex) { }

	public void ChooseWidget(Sprite chosenWidget) { }

	public void ConfirmChosenWidget() { }

	public void EnableChosenWidgetObject() { }

	public void FadeInDots(float animDuration) { }

	public void FadeInWidgets(float animDuration) { }

	public List<Int32> GetPacksIndexesList() { }

	public List<Sprite> GetWidgetsSpriteList() { }

	private void HideCarouselUI() { }

	public void Init(StarsPassViewManager starsPassViewManager) { }

	private void OnDestroy() { }

	public void OpenWidgetChooser() { }

	[IteratorStateMachine(typeof(<RotateCarouselLoop>d__32))]
	private IEnumerator RotateCarouselLoop() { }

	public void SetChosenWidgetImage() { }

	public void SetCurrentFade(float fade) { }

	public void SetIsRotateCarousel(bool isTrue) { }

	public void SetWidgetImages(List<Sprite> widgetsSpriteList) { }

	public void StopTweens() { }

	private void SyncDots() { }

	private void WidgetsCarouselAnim() { }

}

