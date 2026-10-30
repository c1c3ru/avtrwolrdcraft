namespace Game.Level;

public class LevelItemInCharacterBoneTransformOverrideForContainers : LevelItemInCharacterBoneTransformOverride
{
	[SerializeField]
	private Transform _closedStatePosition; //Field offset: 0x30
	[SerializeField]
	private Transform _openStatePosition; //Field offset: 0x38
	[SerializeField]
	private LevelDoor _levelDoor; //Field offset: 0x40

	public LevelItemInCharacterBoneTransformOverrideForContainers() { }

	public virtual Vector2 GetLocalPositionInCharacterBone() { }

	public virtual bool TryGetRotationAngle(out float angle) { }

}

