namespace Game.Level;

public class LevelStickLightHidden : LevelConsumerAreaBase
{
	[SerializeField]
	private List<SpriteRenderer> _spriteRenderers; //Field offset: 0x58

	public LevelStickLightHidden() { }

	protected virtual void Awake() { }

	public void OnActivate() { }

	public void OnDeactivate() { }

}

