namespace PWC.Level;

[RequireComponent(typeof(GameSoundPlayer))]
[RequireComponent(typeof(SkeletonAnimation))]
public class LevelSpineEventSoundPlayer : MonoBehaviour
{
	private const string LoopSuffix = "_Loop"; //Field offset: 0x0
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	private GameSoundPlayer _soundPlayer; //Field offset: 0x28
	private TrackEntry _soundTrackEntry; //Field offset: 0x30
	private string _currentLoopSoundName; //Field offset: 0x38

	public LevelSpineEventSoundPlayer() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnSpineEvent(TrackEntry trackEntry, Event spineEvent) { }

	private void OnTrackComplete(TrackEntry trackEntry) { }

	private void OnTrackStopped(TrackEntry trackEntry) { }

	private void PlaySound(TrackEntry trackEntry, string soundName) { }

	private void StopSound() { }

}

