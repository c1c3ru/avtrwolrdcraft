namespace Game.Level;

public class LevelChangeSpriteDropAreaHandler : MonoBehaviour
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x28
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x38

	public LevelChangeSpriteDropAreaHandler() { }

	private void Awake() { }

	private void ChangeToOffSprite(LevelItem levelItem) { }

	private void ChangeToOnSprite(LevelItem levelItem) { }

	private void OnDestroy() { }

}

