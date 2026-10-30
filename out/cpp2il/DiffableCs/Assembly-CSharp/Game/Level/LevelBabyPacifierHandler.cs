namespace Game.Level;

public class LevelBabyPacifierHandler : LevelItemOnAvatarMouthHandlerBase
{
	[SerializeField]
	private Sprite _onMouthSprite; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onPlacedInMouth; //Field offset: 0x40
	private Sprite _offMouthSprite; //Field offset: 0x48

	public LevelBabyPacifierHandler() { }

	protected virtual void Awake() { }

	protected virtual void OnDestroy() { }

	private void OnEndLand(LevelDropArea area) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual void SetState(bool isOnMouth) { }

}

