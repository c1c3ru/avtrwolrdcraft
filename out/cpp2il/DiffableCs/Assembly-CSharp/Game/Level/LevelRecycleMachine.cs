namespace Game.Level;

public class LevelRecycleMachine : MonoBehaviour
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x20
	[SerializeField]
	private Renderer _lid; //Field offset: 0x28
	[SerializeField]
	private LevelDropArea _inputDropArea; //Field offset: 0x30
	[SerializeField]
	private LevelDropArea _outputDropArea; //Field offset: 0x38
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x40
	[SerializeField]
	private PDPrefabReference[] _outcomes; //Field offset: 0x48
	private int _outcomeIndex; //Field offset: 0x50
	private bool _isInProgress; //Field offset: 0x54

	public LevelRecycleMachine() { }

	[CompilerGenerated]
	private void <OnInputDropItemEndDrop>b__12_0(TrackEntry _) { }

	private void Awake() { }

	private void CanConsumeInput(LevelItem levelItem, ref bool canConsume) { }

	private void OnDestroy() { }

	private void OnInputDropItemBeginDrop(LevelItem levelItem) { }

	private void OnInputDropItemEndDrop(LevelItem levelItem) { }

	private void SpawnOutcome() { }

}

