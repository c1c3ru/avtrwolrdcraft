namespace Game.Level;

public class LevelRotateInteractable : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private static Action OnRotationEnd; //Field offset: 0x0
	[SerializeField]
	private CShape _cShape; //Field offset: 0x20
	[SerializeField]
	private GameObject _rotatingObject; //Field offset: 0x28
	[SerializeField]
	private float _rotatingDegree; //Field offset: 0x30
	[SerializeField]
	private float _finalDegree; //Field offset: 0x34
	private bool _isRotating; //Field offset: 0x38
	private bool _isFinalDegree; //Field offset: 0x39

	public static event Action OnRotationEnd
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public private bool IsFinalDegree
	{
		 get { } //Length: 8
		private set { } //Length: 12
	}

	public LevelRotateInteractable() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__12_0() { }

	[CompilerGenerated]
	public static void add_OnRotationEnd(Action value) { }

	public void DisableRotation() { }

	public bool get_IsFinalDegree() { }

	public Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnRotationEnd(Action value) { }

	private void set_IsFinalDegree(bool value) { }

	public void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

