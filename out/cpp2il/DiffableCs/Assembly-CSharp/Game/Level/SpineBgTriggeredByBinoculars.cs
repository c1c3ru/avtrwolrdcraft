namespace Game.Level;

public class SpineBgTriggeredByBinoculars : MonoBehaviour
{
	[SerializeField]
	private SkeletonAnimation _dolphin; //Field offset: 0x20
	[SerializeField]
	private SkeletonAnimation _stars; //Field offset: 0x28
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x30

	public SpineBgTriggeredByBinoculars() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnDolphinComplete(TrackEntry trackEntry) { }

	private void OnSoundEvent(TrackEntry trackEntry, Event e) { }

	private void OnStarsComplete(TrackEntry trackEntry) { }

	public void TriggerSpineBgAnimation() { }

}

