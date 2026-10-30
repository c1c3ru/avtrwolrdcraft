namespace PWC.WorldReset;

public class WorldAvatarMakerButtonsHolder : ButtonBase
{
	[SerializeField]
	private GameObject _content; //Field offset: 0x20
	private int _tweenId; //Field offset: 0x28
	private Vector2 _visiblePosition; //Field offset: 0x2C
	private Vector2 _hiddenPosition; //Field offset: 0x34
	private bool _didInit; //Field offset: 0x3C

	public WorldAvatarMakerButtonsHolder() { }

	[CompilerGenerated]
	private void <OnClick>b__5_0() { }

	protected virtual void OnClick() { }

}

