namespace Game.Level;

public class LevelToiletButtons : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x60
	[SerializeField]
	private string _soundName; //Field offset: 0x68
	private bool _isPressed; //Field offset: 0x70

	public LevelToiletButtons() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__3_0() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

