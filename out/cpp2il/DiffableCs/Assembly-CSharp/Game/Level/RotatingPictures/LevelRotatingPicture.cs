namespace Game.Level.RotatingPictures;

public class LevelRotatingPicture : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private static Action DoneRotating; //Field offset: 0x0
	[SerializeField]
	private float _angle; //Field offset: 0x20
	[SerializeField]
	private CShape _cShape; //Field offset: 0x28
	[SerializeField]
	private string _soundName; //Field offset: 0x30
	private bool _isRotating; //Field offset: 0x38
	private bool _isRotatedOnce; //Field offset: 0x39

	public static event Action DoneRotating
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public LevelRotatingPicture() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__8_0() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__8_1() { }

	[CompilerGenerated]
	public static void add_DoneRotating(Action value) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_DoneRotating(Action value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

