//Type is in global namespace

public class LevelCAToggleSpriteInHandItemHandlerWithData : LevelCAItemHandlerWithData
{
	[SerializeField]
	private Sprite _phoneBackSprite; //Field offset: 0x90
	private Sprite _currentSprite; //Field offset: 0x98

	public LevelCAToggleSpriteInHandItemHandlerWithData() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	public void SetSpriteToBack() { }

	public void SetSpriteToFront() { }

}

