namespace Game.Level;

public class LevelAxe : LevelSimpleDragActionItemBase
{
	[SerializeField]
	private GameObject _sprite; //Field offset: 0x358
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x360
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x368
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x370
	[SerializeField]
	private List<LevelSpawn> _prefabs; //Field offset: 0x378
	private int _tweenId; //Field offset: 0x380
	private int _loopCounter; //Field offset: 0x384
	private bool _isEndDrag; //Field offset: 0x388
	private bool _isAnimating; //Field offset: 0x389

	public LevelAxe() { }

	[CompilerGenerated]
	private void <Animate>b__13_0() { }

	[CompilerGenerated]
	private void <Animate>b__13_1() { }

	private void Animate(bool value) { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer) { }

	private void PerformCutAction() { }

	private void Spawn() { }

}

