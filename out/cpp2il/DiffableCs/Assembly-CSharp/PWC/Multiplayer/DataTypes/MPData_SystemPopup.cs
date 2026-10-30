namespace PWC.Multiplayer.DataTypes;

public class MPData_SystemPopup : MPDataBase
{
	internal enum PopupType
	{
		None = 0,
		ReachedMaxPlayers = 1,
		BuildNumberMismatch = 2,
	}

	public PopupType popupType; //Field offset: 0x28

	public MPData_SystemPopup() { }

	public virtual void HandleReceviedData() { }

}

