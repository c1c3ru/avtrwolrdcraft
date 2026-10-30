namespace Game.Level;

public class LevelBalloonPopHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x28
	[SerializeField]
	private CShape _CShape; //Field offset: 0x30
	[SerializeField]
	private SpriteRenderer _renderer; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onBalloonPopAction; //Field offset: 0x40
	private Color32[] _particleColors; //Field offset: 0x48
	protected int _particlesColorIndex; //Field offset: 0x50

	public LevelBalloonPopHandler() { }

	[CompilerGenerated]
	private void <PopBalloon>b__9_0() { }

	protected override void DestroyBalloon() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected void PopBalloon() { }

	public void SetParticleColorIndex(int index) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

