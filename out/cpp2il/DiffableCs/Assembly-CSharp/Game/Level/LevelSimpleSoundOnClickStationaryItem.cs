namespace Game.Level;

[AddComponentMenu(null)]
public class LevelSimpleSoundOnClickStationaryItem : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	protected bool _isLoop; //Field offset: 0x60
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x68
	[SerializeField]
	protected string _soundName; //Field offset: 0x70
	[SerializeField]
	protected float _volume; //Field offset: 0x78

	public LevelSimpleSoundOnClickStationaryItem() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

