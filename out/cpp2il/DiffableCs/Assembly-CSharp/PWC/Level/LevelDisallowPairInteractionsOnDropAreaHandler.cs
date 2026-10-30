namespace PWC.Level;

public class LevelDisallowPairInteractionsOnDropAreaHandler : MonoBehaviour, ILevelSpawnDuringGameplay
{
	private LevelDropArea _dropArea; //Field offset: 0x20
	private LevelAvatarRestAreaBase _restArea; //Field offset: 0x28

	public LevelDisallowPairInteractionsOnDropAreaHandler() { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	private void OnAvatarEndDrop(LevelAvatarRestAreaBase _, ILevelAvatar avatar) { }

	private void OnAvatarPickUp(LevelAvatarRestAreaBase _, ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem item) { }

	private void OnItemPickUp(LevelItem item) { }

	private void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

}

