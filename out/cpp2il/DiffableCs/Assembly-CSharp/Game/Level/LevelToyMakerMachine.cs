namespace Game.Level;

public class LevelToyMakerMachine : LevelSimpleSpawner
{
	[SerializeField]
	private LevelToggleableGameObject _baseIconToggle; //Field offset: 0x98
	[SerializeField]
	private LevelToggleableSprite _shoesDisplay; //Field offset: 0xA0
	[SerializeField]
	private LevelToggleableSprite _shirtDisplay; //Field offset: 0xA8
	[SerializeField]
	private LevelToggleableSprite _hatDisplay; //Field offset: 0xB0
	[SerializeField]
	private Sprite[] _baseSprites; //Field offset: 0xB8
	[SerializeField]
	private Sprite[] _shoesSprites; //Field offset: 0xC0
	[SerializeField]
	private Sprite[] _shirtSprites; //Field offset: 0xC8
	[SerializeField]
	private Sprite[] _hatSprites; //Field offset: 0xD0
	[Header("Secret Configurations")]
	[SerializeField]
	private int _baseSecretConfiguration; //Field offset: 0xD8
	[SerializeField]
	private int _shoesSecretConfiguration; //Field offset: 0xDC
	[SerializeField]
	private int _shirtSecretConfiguration; //Field offset: 0xE0
	[SerializeField]
	private int _hatSecretConfiguration; //Field offset: 0xE4
	[SerializeField]
	protected PDPrefabReference _secretPrefabReference; //Field offset: 0xE8
	private int _baseIndex; //Field offset: 0xF0
	private int _shoesIndex; //Field offset: 0xF4
	private int _shirtIndex; //Field offset: 0xF8
	private int _hatIndex; //Field offset: 0xFC

	public LevelToyMakerMachine() { }

	protected virtual void Awake() { }

	public void DecreaseHat() { }

	public void DecreaseShirt() { }

	public void DecreaseShoes() { }

	public virtual LevelSpawn GetPrefabToSpawn() { }

	public void IncreaseHat() { }

	public void IncreaseShirt() { }

	public void IncreaseShoes() { }

	private bool IsSecretConfiguration() { }

	private void OnDestroy() { }

	protected virtual void OnPostSpawn(LevelItem levelItem) { }

	public void SetBaseIndex(int index) { }

	public void SetHatIndex(int index) { }

	public void SetShirtIndex(int index) { }

	public void SetShoesIndex(int index) { }

	private static int WrapIndex(int index, int length) { }

}

