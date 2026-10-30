namespace Game.Level;

public class LevelBlender : LevelItem
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x348
	private bool _isOn; //Field offset: 0x350
	private bool _isOnForPD; //Field offset: 0x351

	public LevelBlender() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void PlaySound() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void StopSound() { }

}

