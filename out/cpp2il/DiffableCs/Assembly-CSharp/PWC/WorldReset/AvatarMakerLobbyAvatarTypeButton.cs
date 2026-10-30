namespace PWC.WorldReset;

public class AvatarMakerLobbyAvatarTypeButton : ButtonBase
{
	[SerializeField]
	private AvatarType _avatarType; //Field offset: 0x20
	[SerializeField]
	private GameObject _selectedIndicator; //Field offset: 0x28

	public AvatarMakerLobbyAvatarTypeButton() { }

	protected virtual void Awake() { }

	protected virtual void OnClick() { }

}

