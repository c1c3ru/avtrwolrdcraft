//Type is in global namespace

public class LevelFlippableSliderHandler : MonoBehaviour
{
	public const float SCALE_WHILE_DRAGGING = 1,1; //Field offset: 0x0
	[SerializeField]
	private float _dragFlipXDelta; //Field offset: 0x20
	private LevelSlider _levelSlider; //Field offset: 0x28
	private Vector2 lastPosition; //Field offset: 0x30
	private bool _isFlipped; //Field offset: 0x38
	private bool _isDragging; //Field offset: 0x39
	private int _dragScaleTweenId; //Field offset: 0x3C

	public LevelFlippableSliderHandler() { }

	[CompilerGenerated]
	private void <PlayScaleTween>b__14_0() { }

	private void Awake() { }

	public Vector3 GetDefaultScaleForCurrentFlipState() { }

	private void OnDestroy() { }

	private void OnSliderSyncPositionAction(LevelSlider levelSlider, Vector2 newPosition) { }

	private void PlayScaleTween(Vector3 scale, float duration) { }

	private void SetFlipped(bool isFlipped, bool force = false) { }

	public void SetFlippedExternal(bool isFlipped) { }

	public void StopScaleTween() { }

	private void SyncIsFlippedState() { }

}

