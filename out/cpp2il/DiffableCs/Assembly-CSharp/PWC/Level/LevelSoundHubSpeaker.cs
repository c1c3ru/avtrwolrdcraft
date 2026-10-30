namespace PWC.Level;

public class LevelSoundHubSpeaker : GameSoundHubSpeakerBase, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x38
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x40
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x48
	[SerializeField]
	private GameObject[] _onGameObjects; //Field offset: 0x50
	[SerializeField]
	private GameObject[] _offGameObjects; //Field offset: 0x58
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x60

	public LevelSoundHubSpeaker() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected virtual void PerformLinkAction(GameSoundHub soundHub, ParameterType paremterType) { }

	private void SetEmitParticleSystem(bool emit) { }

}

