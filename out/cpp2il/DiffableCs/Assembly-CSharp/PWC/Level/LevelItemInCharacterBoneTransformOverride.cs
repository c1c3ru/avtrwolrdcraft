namespace PWC.Level;

public class LevelItemInCharacterBoneTransformOverride : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[SerializeField]
	protected Transform _point; //Field offset: 0x20
	[SerializeField]
	protected bool _overrideRotation; //Field offset: 0x28
	[ConditionalField("_overrideRotation", True, True, (array) null)]
	[SerializeField]
	protected float _angle; //Field offset: 0x2C

	public Transform Point
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelItemInCharacterBoneTransformOverride() { }

	protected override void Awake() { }

	public Transform get_Point() { }

	public override Vector2 GetLocalPositionInCharacterBone() { }

	public void Init() { }

	protected override void OnDestroy() { }

	private void OnLevelPostInit() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	public void set_Point(Transform value) { }

	public void SetOverrideAngle(float angle) { }

	public void SetPoint(Transform point) { }

	public override bool TryGetRotationAngle(out float angle) { }

}

