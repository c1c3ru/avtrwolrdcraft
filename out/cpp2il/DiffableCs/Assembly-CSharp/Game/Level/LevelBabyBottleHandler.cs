namespace Game.Level;

public class LevelBabyBottleHandler : LevelItemOnAvatarMouthHandlerBase
{
	[SerializeField]
	private GameObject _offMouth; //Field offset: 0x38
	[SerializeField]
	private GameObject _onMouth; //Field offset: 0x40

	public LevelBabyBottleHandler() { }

	public virtual string GetOnMouthAnimationName(out bool isLoop) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual void SetState(bool isOnMouth) { }

}

