namespace Game.Level.ContextualAnimation;

public class LevelCASpineAnimationOnDropAreaHandler : LevelCADropAreaHandlerWithData
{
	[SerializeField]
	private SkeletonAnimation _spineAnimation; //Field offset: 0x98
	[SerializeField]
	[SpineAnimation(null, "_spineAnimation", True, False, False)]
	private string _workingAnimationName; //Field offset: 0xA0
	[SerializeField]
	[SpineAnimation(null, "_spineAnimation", True, False, False)]
	private string _idleAnimationName; //Field offset: 0xA8
	[SerializeField]
	private bool _loopWorkingAnimation; //Field offset: 0xB0
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0xB8
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0xC0
	[SerializeField]
	private Transform _parent; //Field offset: 0xC8
	[SerializeField]
	private LevelSpawn[] _itemsToSpawn; //Field offset: 0xD0
	[SerializeField]
	private int _maxInstances; //Field offset: 0xD8
	[SerializeField]
	private bool _spineObjectMirrorAvatarScale; //Field offset: 0xDC
	private Vector3 _originalSpineObjectScale; //Field offset: 0xE0

	public LevelCASpineAnimationOnDropAreaHandler() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationInterrupt(TrackEntry trackEntry) { }

	private void PlayAnimation(string animationName, bool loop) { }

	private void SpawnItem(LevelCharacter character, int index) { }

	private void StopAnimation() { }

}

