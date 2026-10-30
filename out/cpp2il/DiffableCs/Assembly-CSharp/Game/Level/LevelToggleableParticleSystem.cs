namespace Game.Level;

public class LevelToggleableParticleSystem : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public LevelToggleableParticleSystem <>4__this; //Field offset: 0x10
		public Action onCompleteAction; //Field offset: 0x18

		public <>c__DisplayClass12_0() { }

		internal void <PlayParticleEffectForDuration>b__0() { }

	}

	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x20
	[SerializeField]
	private float _duration; //Field offset: 0x28
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x30
	[SerializeField]
	private string _soundName; //Field offset: 0x38
	private bool _isOn; //Field offset: 0x40
	private int _tweenID; //Field offset: 0x44
	private LevelItem _levelItem; //Field offset: 0x48

	public LevelToggleableParticleSystem() { }

	private void Awake() { }

	public void ForceClick() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnBeginDragAction(DragDropItemBase itemBase, PointerEventData eventData) { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void PlayParticleEffectForDuration(Action onCompleteAction = null) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void StopParticles(Action onCompleteAction = null) { }

	private void SyncSound() { }

	private void ToggleParticleSystem(bool value) { }

}

