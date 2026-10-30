namespace Game.Level;

public class LevelDrinkMachineButton : LevelDrinkDispenser
{
	[SerializeField]
	private Color _color; //Field offset: 0xA0
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0xB0
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0xB8
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0xC0
	[SerializeField]
	private LevelDrinkMachineManager _manager; //Field offset: 0xC8
	[SerializeField]
	private LevelToggleableSprite _toggleableSprite; //Field offset: 0xD0
	private int _index; //Field offset: 0xD8

	public LevelDrinkMachineButton() { }

	public void Init(int index) { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void TurnOffButton() { }

	private void UpdateManager() { }

}

