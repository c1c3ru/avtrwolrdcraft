namespace PWC.Level.Water;

public abstract class LevelWaterAreaItemHandlerBase : MonoBehaviour
{
	protected const string IS_IN_WATER = "IS_IN_WATER"; //Field offset: 0x0
	protected List<Material> _materials; //Field offset: 0x20
	protected readonly int _waterYPositionID; //Field offset: 0x28
	protected readonly int _waterCurveMultiplierID; //Field offset: 0x2C
	protected readonly int _waterColorID; //Field offset: 0x30
	protected readonly int _waterXOffsetID; //Field offset: 0x34
	protected LevelWaterArea _waterArea; //Field offset: 0x38
	protected float _deepWaterYPosition; //Field offset: 0x40
	protected float _waterTargetYPosition; //Field offset: 0x44
	protected LevelItemWaterLine _waterLinePrefab; //Field offset: 0x48
	protected LevelItemWaterLine _waterLine; //Field offset: 0x50
	protected float _curveMultiplier; //Field offset: 0x58

	public LevelWaterArea WaterArea
	{
		 get { } //Length: 8
	}

	public Transform WaterLineTransform
	{
		 get { } //Length: 136
	}

	protected LevelWaterAreaItemHandlerBase() { }

	[CompilerGenerated]
	internal static bool <InitRenderer>g__HasNoLevelItem|18_0(Transform trans) { }

	public void ApplyWaterColor() { }

	protected void DisableWaterKeyword() { }

	public void EnableWaterKeyword() { }

	public LevelWaterArea get_WaterArea() { }

	public Transform get_WaterLineTransform() { }

	private float GetCurveMultiplier(float itemWidth) { }

	public float GetWaterTargetYPosition() { }

	protected float GetWaterYPosition() { }

	protected void InitMaterialInWater(Material material, float curveMultiplier) { }

	protected void InitRenderer(Renderer itemRootRenderer) { }

	protected void InitSkeletonAnimation(SkeletonAnimation skeletonAnimation) { }

	protected bool IsInDeepWater() { }

	protected bool IsWaterLineVisible() { }

	public override void PlayFloatingTween(float delay = 0) { }

	public void SetWaterArea(LevelWaterArea waterArea) { }

	public void SetWaterYPosition(float waterYPosition) { }

}

