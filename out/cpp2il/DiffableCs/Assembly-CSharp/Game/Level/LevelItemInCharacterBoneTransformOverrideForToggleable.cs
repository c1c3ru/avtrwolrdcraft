namespace Game.Level;

public class LevelItemInCharacterBoneTransformOverrideForToggleable : LevelItemInCharacterBoneTransformOverride
{
	[SerializeField]
	private LevelToggleableGameObject _toggleable; //Field offset: 0x30
	[SerializeField]
	private int _overrideIndex; //Field offset: 0x38

	private bool IsOverriding
	{
		private get { } //Length: 40
	}

	public LevelItemInCharacterBoneTransformOverrideForToggleable() { }

	protected virtual void Awake() { }

	private bool get_IsOverriding() { }

	public virtual Vector2 GetLocalPositionInCharacterBone() { }

	protected virtual void OnDestroy() { }

	private void OnToggled(int index) { }

	public virtual bool TryGetRotationAngle(out float angle) { }

}

