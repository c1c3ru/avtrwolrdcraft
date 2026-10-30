namespace Game.Level;

public class LevelItemInCharacterBoneTransformOverrideForCA : LevelItemInCharacterBoneTransformOverride
{
	[SerializeField]
	private LevelCAHandlerBase _caHandler; //Field offset: 0x30
	[SerializeField]
	[Tooltip("Local Z angle of the item in the hand while one of the CA handler's animations plays")]
	private float _caAngle; //Field offset: 0x38
	private bool _isPlayingCA; //Field offset: 0x3C

	public LevelItemInCharacterBoneTransformOverrideForCA() { }

	protected virtual void Awake() { }

	private void OnAnimationBegin(LevelCAHandlerBase _, ICATarget __, LevelCAConfig ___) { }

	private void OnAnimationEnd(LevelCAHandlerBase _, ICATarget __, LevelCAConfig ___) { }

	protected virtual void OnDestroy() { }

	private void OnRemovedFromTarget(LevelCAHandlerBase _, ICATarget __) { }

	private void SetIsPlayingCA(bool isPlayingCA) { }

	public virtual bool TryGetRotationAngle(out float angle) { }

}

