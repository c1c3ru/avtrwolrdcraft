namespace Game.Level;

public class LevelMannequinArea : LevelAvatarClothingAreaBase
{
	[SerializeField]
	private CharacterClothingType[] _clothingTypes; //Field offset: 0x78
	public UnityEvent<String> OnPutClothingEvent; //Field offset: 0x80
	public UnityEvent<String> OnRemoveClothingEvent; //Field offset: 0x88

	public LevelMannequinArea() { }

	protected virtual void Awake() { }

	protected virtual void OnPutClothing(string skinName) { }

	protected virtual void OnRemoveClothing(string skinName) { }

}

