namespace PWC.Level;

public class LevelVideoPlayer : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private VideoPlayer _videoPlayer; //Field offset: 0x60
	private bool _isOn; //Field offset: 0x68
	private bool _isFirstTimeOnPauseEvent; //Field offset: 0x69

	public LevelVideoPlayer() { }

	private void OnApplicationPause(bool pause) { }

	private void OnBecameInvisible() { }

	private void OnBecameVisible() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void SetState(bool isOn, bool playSound) { }

}

