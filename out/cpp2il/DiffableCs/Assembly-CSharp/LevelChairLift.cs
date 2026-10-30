//Type is in global namespace

public class LevelChairLift : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public ChairState current; //Field offset: 0x10
		public LevelChairLift <>4__this; //Field offset: 0x18

		public <>c__DisplayClass15_0() { }

		internal void <InitChairs>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public LevelChairLift <>4__this; //Field offset: 0x10
		public ChairState state; //Field offset: 0x18

		public <>c__DisplayClass16_0() { }

		internal void <MoveAlongCurrentStep>b__0() { }

	}

	private class ChairState
	{
		public SortingGroup Chair; //Field offset: 0x10
		public int StepIndex; //Field offset: 0x18
		public int Direction; //Field offset: 0x1C

		public ChairState() { }

	}

	internal class EdgeSection
	{
		public EdgeCollider2D Edge; //Field offset: 0x10
		public float TravelTime; //Field offset: 0x18
		public int SortingOrder; //Field offset: 0x1C
		public bool DropOnEnd; //Field offset: 0x20

		public EdgeSection() { }

	}

	private struct Step
	{
		public Vector3 From; //Field offset: 0x0
		public Vector3 To; //Field offset: 0xC
		public float Duration; //Field offset: 0x18
		public int SortingOrder; //Field offset: 0x1C
		public bool DropOnEnd; //Field offset: 0x20

	}

	[SerializeField]
	private EdgeSection[] _sections; //Field offset: 0x20
	[SerializeField]
	private SortingGroup[] _chairs; //Field offset: 0x28
	[SerializeField]
	private bool _faceDirection; //Field offset: 0x30
	[SerializeField]
	private float _chairStartOffset; //Field offset: 0x34
	[SerializeField]
	private bool _loop; //Field offset: 0x38
	private bool _foundSavedData; //Field offset: 0x39
	private readonly List<Step> _steps; //Field offset: 0x40
	private readonly List<ChairState> _chairStates; //Field offset: 0x48

	public LevelChairLift() { }

	private void Awake() { }

	private void BuildStepsFromEdges() { }

	private void DropAvatarsOnReached(GameObject chair) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private Int32[] GetStepIndexArrayFromChairStates() { }

	[ContextMenu("startcharis")]
	private void InitChairs() { }

	private void MoveAlongCurrentStep(ChairState state) { }

	private void OnChairLiftPostInit() { }

	private void OnDestroy() { }

	private void OnStepComplete(ChairState state) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

