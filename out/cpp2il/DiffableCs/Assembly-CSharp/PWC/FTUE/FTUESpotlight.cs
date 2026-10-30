namespace PWC.FTUE;

public class FTUESpotlight : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public FTUESpotlight <>4__this; //Field offset: 0x10
		public Action onCompleteAction; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		internal void <TryAnimateIn>b__0(float radius) { }

		internal void <TryAnimateIn>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public FTUESpotlight <>4__this; //Field offset: 0x10
		public bool destroyOnComplete; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal void <AnimateOut>b__0(float radius) { }

		internal void <AnimateOut>b__1() { }

	}

	public static bool IsOn; //Field offset: 0x0
	[SerializeField]
	private UISpotlight _uiSpotlight; //Field offset: 0x20
	[SerializeField]
	private float _radius; //Field offset: 0x28
	[SerializeField]
	private float _softness; //Field offset: 0x2C
	private float _screenRatio; //Field offset: 0x30
	private int _tweenID; //Field offset: 0x34
	private GameCameraBase _currentGameCamera; //Field offset: 0x38

	public FTUESpotlight() { }

	public void AnimateOut(bool destroyOnComplete, float duration = 0,1) { }

	private void CancelTweenIfNeeded() { }

	private void SetRadius(float radius) { }

	public bool TryAnimateIn(Vector2 position, float minRadius = 0,2, Action onCompleteAction = null) { }

}

