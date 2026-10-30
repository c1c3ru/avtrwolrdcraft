namespace Game.Level;

public class LevelFireExtinguisher : LevelSimpleDragActionItemBase
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x358
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x360
	[SerializeField]
	private string _soundName; //Field offset: 0x368
	private bool _isOn; //Field offset: 0x370

	public LevelFireExtinguisher() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	protected virtual void OnTargetEnter(ILevelConsumer target) { }

	protected virtual void OnTargetExit(ILevelConsumer target) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncParticleSystem() { }

	private void SyncSoundPlayer() { }

}

