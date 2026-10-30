namespace PWC.Level;

public class LevelPouringItemHandler : MonoBehaviour, IMultiplayer_PrepareForDrag, IMultiplayer_PrepareForDrop
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public bool value; //Field offset: 0x10
		public LevelPouringItemHandler <>4__this; //Field offset: 0x18

		public <>c__DisplayClass22_0() { }

		internal void <TryAnimate>b__0() { }

	}

	[SerializeField]
	private GameObject _orientedGameObject; //Field offset: 0x20
	[SerializeField]
	protected ParticleSystem _particleSystem; //Field offset: 0x28
	[Range(0, 360)]
	[SerializeField]
	private float _angle; //Field offset: 0x30
	[SerializeField]
	private string _onPourSoundName; //Field offset: 0x38
	[SerializeField]
	private bool _isPourSoundLoop; //Field offset: 0x40
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x48
	[SerializeField]
	private GameObject _liquid; //Field offset: 0x50
	private int _gameObjectTweenID; //Field offset: 0x58
	private int _orientedGameObjectTweenID; //Field offset: 0x5C
	private int _filledTargets; //Field offset: 0x60
	private int _maxFillings; //Field offset: 0x64
	private LevelItem _levelItem; //Field offset: 0x68
	protected ILevelFillable _fillable; //Field offset: 0x70
	private LevelDrinkFillerOnDragItemHandler _drinkFillerHandler; //Field offset: 0x78

	public LevelPouringItemHandler() { }

	private void Awake() { }

	private bool CanPour() { }

	protected override void OnBeginDrag(DragDropItemBase _, PointerEventData __) { }

	private void OnColorLiquid(Color color) { }

	private void OnDestroy() { }

	protected override void OnEndDrag(DragDropItemBase _, PointerEventData __) { }

	private void OnLevelPostInit() { }

	private void OnTargetFill() { }

	public void ParticleSystemSetActive(bool value) { }

	private override void PWC.Multiplayer.IMultiplayer_PrepareForDrag.Multiplayer_PrepareForDrag() { }

	private override void PWC.Multiplayer.IMultiplayer_PrepareForDrop.Multiplayer_PrepareForDrop(MPDataType _) { }

	private void SetLiquidActiveIfNeeded(bool value) { }

	private void SetParticleSystemColor(Color color) { }

	private void SetSoundActiveIfNeeded(bool value) { }

	protected override bool TryAnimate(bool value) { }

}

