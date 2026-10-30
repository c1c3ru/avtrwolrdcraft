namespace PWC.Street;

public class StreetCamera : GameCamera
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public StreetCamera <>4__this; //Field offset: 0x10
		public StreetHouse house; //Field offset: 0x18

		public <>c__DisplayClass10_0() { }

		internal void <TweenToHouse>b__0() { }

	}

	private const float TWEEN_DURATION = 0,25; //Field offset: 0x0
	[CompilerGenerated]
	private Action<StreetHouse> OnTweenToXPositionCompleteAction; //Field offset: 0xC8
	[SerializeField]
	private RectTransform _area; //Field offset: 0xD0

	public event Action<StreetHouse> OnTweenToXPositionCompleteAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public StreetCamera() { }

	[CompilerGenerated]
	public void add_OnTweenToXPositionCompleteAction(Action<StreetHouse> value) { }

	public void Init() { }

	protected virtual void OnBeginDrag() { }

	protected virtual void OnEndDrag() { }

	[CompilerGenerated]
	public void remove_OnTweenToXPositionCompleteAction(Action<StreetHouse> value) { }

	public void TweenToHouse(StreetHouse house) { }

	public void TweenToPosition(float xPosition, Action onCompleteAction = null) { }

	protected virtual void Update() { }

}

