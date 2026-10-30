namespace PWC.LevelContextualAnimation;

public class LevelContextualAnimationPanelCircle : MonoBehaviour
{
	[SerializeField]
	private Image _image; //Field offset: 0x20
	[SerializeField]
	private Sprite _unselectedSprite; //Field offset: 0x28
	[SerializeField]
	private Sprite _selectedSprite; //Field offset: 0x30

	public LevelContextualAnimationPanelCircle() { }

	public int GetSpriteWidth() { }

	public void SetSelected(bool value) { }

	public void SetSprites(Sprite selectedSprite, Sprite unselectedSprite) { }

}

