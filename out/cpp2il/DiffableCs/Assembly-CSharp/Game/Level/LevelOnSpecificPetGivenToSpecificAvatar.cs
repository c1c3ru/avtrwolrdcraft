namespace Game.Level;

public class LevelOnSpecificPetGivenToSpecificAvatar : MonoBehaviour
{
	[SerializeField]
	private SpineType _spineType; //Field offset: 0x20
	[SerializeField]
	private int _pet_ID; //Field offset: 0x24
	[SerializeField]
	private int _avatarID; //Field offset: 0x28
	public UnityEvent OnPetGivenToAvatar; //Field offset: 0x30

	public LevelOnSpecificPetGivenToSpecificAvatar() { }

	private void Awake() { }

	private void LevelOnPostInit() { }

	private void OnDestroy() { }

	private void OnPlacedOnAvatar(LevelCAPetOnCharacterHandlerBase givenPet, ICATarget target) { }

}

