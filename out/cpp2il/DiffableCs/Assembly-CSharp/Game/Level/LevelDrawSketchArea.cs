namespace Game.Level;

public class LevelDrawSketchArea : LevelConsumerAreaBase, ILevelPaintableTarget, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected Sprite _spriteToDraw; //Field offset: 0x58
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x60
	private bool _isDrawn; //Field offset: 0x68

	public bool IsDrawn
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelDrawSketchArea() { }

	public override void DisablePainting() { }

	public void DrawSprite() { }

	public override void EnablePainting(Color color, LTexture brush) { }

	public bool get_IsDrawn() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void Paint(Vector2 position) { }

	public void set_IsDrawn(bool value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

