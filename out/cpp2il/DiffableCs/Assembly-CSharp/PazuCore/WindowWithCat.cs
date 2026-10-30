namespace PazuCore;

public class WindowWithCat : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public Action onFinish; //Field offset: 0x10
		public WindowWithCat <>4__this; //Field offset: 0x18

		public <>c__DisplayClass11_0() { }

		internal void <PlayCloseAnimation>b__0() { }

	}

	[SerializeField]
	private GameObject _window; //Field offset: 0x20
	[SerializeField]
	private BottomCat _bottomCat; //Field offset: 0x28
	[SerializeField]
	private bool _fitToScreen; //Field offset: 0x30
	private Vector3 _startScale; //Field offset: 0x34
	[CompilerGenerated]
	private bool <IsTweenInProgress>k__BackingField; //Field offset: 0x40

	public private bool IsTweenInProgress
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public WindowWithCat() { }

	[CompilerGenerated]
	private void <PlayOpenAnimation>b__10_0() { }

	private void FitToScreen() { }

	[CompilerGenerated]
	public bool get_IsTweenInProgress() { }

	public void Init() { }

	public void PlayCloseAnimation(Action onFinish) { }

	public void PlayOpenAnimation() { }

	[CompilerGenerated]
	private void set_IsTweenInProgress(bool value) { }

}

