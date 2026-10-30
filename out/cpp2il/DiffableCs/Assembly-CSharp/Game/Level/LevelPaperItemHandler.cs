namespace Game.Level;

public class LevelPaperItemHandler : LevelSimpleItemHandlerConsumerBase, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private SpriteRenderer _drawingShape; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onPencilEnter; //Field offset: 0x30
	private LitSpriteRenderer _drawingShapelit; //Field offset: 0x38
	private string _spriteName; //Field offset: 0x40
	private string _spriteBasePath; //Field offset: 0x48

	public LevelPaperItemHandler() { }

	protected virtual void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void NotifyPencilEnter() { }

	public override void SetDrawingShapeColor(Color color) { }

	public void SetDrawingShapeSprite(Sprite sprite, string spriteBasePath) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

