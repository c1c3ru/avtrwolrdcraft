namespace PWC.Multiplayer;

public enum MPDataType
{
	None = 0,
	Input = 1,
	ItemDropArea = 2,
	Transform = 3,
	ItemBeginDrag = 4,
	CA = 5,
	ItemDropCharacterInteraction = 6,
	ItemDropInteraction = 7,
	ConsumerDropInteraction = 8,
	ItemDragInteraction = 9,
	Message = 10,
	SpawnAvatar = 11,
	RemoveAvatar = 12,
	SpawnBulkData = 13,
	StartScene = 10001,
	RandomGeneratorSeed = 10002,
	SceneChange = 10003,
	SceneChangeRequest = 10004,
	StartGame = 10005,
	SetDayNight = 10006,
	PlayerRemoved = 10007,
	PlayerJoined = 10008,
	MoveAvatar = 10009,
	MoveAvatarRequest = 10010,
	GameStarted = 10011,
	WaitForPlayer = 10012,
	SystemPopup = 20001,
	JoinRequest = 20002,
}

