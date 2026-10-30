//Type is in global namespace

public class LevelOnActionRotatableObject : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public LevelOnActionRotatableObject <>4__this; //Field offset: 0x10
		public int amountRotated; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <RotateLoop>b__0() { }

	}

	[SerializeField]
	private GameObject _rotatingObject; //Field offset: 0x20
	[SerializeField]
	private Single[] _rotatingDegrees; //Field offset: 0x28
	[SerializeField]
	private float _time; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onRotationEnd; //Field offset: 0x38
	[SerializeField]
	private bool _isWaitingForRotationEnd; //Field offset: 0x40
	private bool _isRotating; //Field offset: 0x41
	private int _currentDegreeIndex; //Field offset: 0x44

	public LevelOnActionRotatableObject() { }

	[CompilerGenerated]
	private void <Rotate>b__7_0() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void Rotate() { }

	public void RotateFromStartUntilFinishedLoop() { }

	private void RotateLoop(int amountRotated) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

