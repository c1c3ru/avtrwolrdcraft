namespace PWC.LoadingScreen;

public class LoadingScreenScreen : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public LoadingScreenScreen <>4__this; //Field offset: 0x10
		public bool value; //Field offset: 0x18
		public Action onComplete; //Field offset: 0x20

		public <>c__DisplayClass5_0() { }

		internal void <Fade>b__0(float alphaValue) { }

		internal void <Fade>b__1() { }

	}

	[SerializeField]
	protected CanvasGroup _canvasGroup; //Field offset: 0x20
	[SerializeField]
	protected Image _background; //Field offset: 0x28
	[SerializeField]
	private GameObject _clockHours; //Field offset: 0x30
	[SerializeField]
	private GameObject _clockMinutes; //Field offset: 0x38
	[SerializeField]
	private GameObject _clockNose; //Field offset: 0x40

	public LoadingScreenScreen() { }

	private void AnimateClock(bool value) { }

	public override void Fade(bool value, Action onComplete = null) { }

}

