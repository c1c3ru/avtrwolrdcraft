namespace Game.Level;

[AddComponentMenu(null)]
public class LevelSimpleSoundOnClickItem : LevelItem
{
	[SerializeField]
	protected bool _isLoop; //Field offset: 0x342
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x348
	[SerializeField]
	protected string _soundName; //Field offset: 0x350
	[SerializeField]
	protected float _volume; //Field offset: 0x358
	[SerializeField]
	protected ParticleSystem _particleSystem; //Field offset: 0x360

	public LevelSimpleSoundOnClickItem() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void ParticleSystemSetActive(bool value) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

