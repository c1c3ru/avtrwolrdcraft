namespace PWC.WobbleEffect;

public abstract class WobbleEffectBase : MonoBehaviour
{
	protected static readonly int WorldPositionId; //Field offset: 0x0
	private const float MinDragDelta = 0,1; //Field offset: 0x0
	private const float DragToWobbleScale = 0,03; //Field offset: 0x0
	private const float MaxWobbleAmount = 0,3; //Field offset: 0x0
	private const float WobbleDuration = 0,5; //Field offset: 0x0
	protected static readonly int WobbleAmountId; //Field offset: 0x4
	private GameCamera _gameCamera; //Field offset: 0x20
	private Vector2 _lastCameraPosition; //Field offset: 0x28
	private float _wobbleAmount; //Field offset: 0x30
	private int _tweenId; //Field offset: 0x34
	private bool _isTweening; //Field offset: 0x38
	private bool _isCameraDragging; //Field offset: 0x39
	private bool _isSubscribedToCamera; //Field offset: 0x3A
	private bool _isSubscribedToWorldPostInit; //Field offset: 0x3B

	protected override bool RefreshPivotOnDragBegin
	{
		 get { } //Length: 8
	}

	private static WobbleEffectBase() { }

	protected WobbleEffectBase() { }

	[CompilerGenerated]
	private void <Wobble>b__26_0(float wobbleAmount) { }

	[CompilerGenerated]
	private void <Wobble>b__26_1() { }

	protected abstract void ApplyWobble(float wobbleAmount) { }

	protected abstract void ApplyWorldPosition(Vector2 worldPosition) { }

	protected override bool get_RefreshPivotOnDragBegin() { }

	private void OnBeginDrag() { }

	private void OnChangePosition(Vector2 position) { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

	private void OnEndDrag() { }

	private void OnWorldPostInit() { }

	private void StopTween() { }

	private void SubscribeToCamera() { }

	private void UnsubscribeFromCamera() { }

	private void Wobble() { }

}

