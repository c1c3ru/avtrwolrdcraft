namespace PWC.AvatarMakerLobby;

public class AvatarMakerLobbyFilledCarSlot : AvatarMakerLobbyFilledSlot
{
	public const float BIG_VEHICLE_SCALE = 1,5; //Field offset: 0x0
	public const float BIG_VEHICLE_EXTRA_SLOT_WIDTH = 400; //Field offset: 0x0
	public const float BIG_VEHICLE_SHADOW_SCALE = 2; //Field offset: 0x0
	[SerializeField]
	private RectTransform _shadowRect; //Field offset: 0x70
	[CompilerGenerated]
	private bool <IsBigVehicle>k__BackingField; //Field offset: 0x78

	public private bool IsBigVehicle
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public AvatarMakerLobbyFilledCarSlot() { }

	private void ApplyLobbySize(CarSkinsManager carSkinsManager, CarView carView) { }

	[CompilerGenerated]
	public bool get_IsBigVehicle() { }

	public virtual void Init(int characterID) { }

	[CompilerGenerated]
	private void set_IsBigVehicle(bool value) { }

}

