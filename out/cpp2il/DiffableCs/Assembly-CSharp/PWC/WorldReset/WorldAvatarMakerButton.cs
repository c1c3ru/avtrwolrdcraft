namespace PWC.WorldReset;

public class WorldAvatarMakerButton : ButtonBase
{
	[SerializeField]
	private AvatarType _avatarType; //Field offset: 0x20

	public WorldAvatarMakerButton() { }

	protected virtual void OnClick() { }

}

