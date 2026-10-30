namespace Game.Level;

public class LevelReleaseItemsOnClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private LevelDropArea[] _dropArea; //Field offset: 0x20
	[SerializeField]
	private LevelAvatarRestAreaBase[] _characterDropArea; //Field offset: 0x28

	public LevelReleaseItemsOnClick() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

