namespace PWC;

public abstract class GameMuteButtonBase : ButtonBase
{
	[SerializeField]
	private GameObject _muteState; //Field offset: 0x20
	[SerializeField]
	private GameObject _unmuteState; //Field offset: 0x28

	protected GameMuteButtonBase() { }

	protected virtual void Awake() { }

	protected abstract bool IsMute() { }

	protected virtual void OnClick() { }

	private void SetMute(bool isMute) { }

	protected abstract void SetMuteInternal(bool isMute) { }

	private void SyncState() { }

	private void ToggleMute() { }

}

