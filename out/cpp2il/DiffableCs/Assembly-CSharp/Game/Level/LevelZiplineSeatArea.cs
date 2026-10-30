namespace Game.Level;

public class LevelZiplineSeatArea : LevelSitArea
{
	[SerializeField]
	private LevelZiplineSeat _ziplineSeat; //Field offset: 0x88

	public LevelZiplineSeatArea() { }

	public virtual void OnAvatarEndDrop(ILevelAvatar avatar) { }

}

