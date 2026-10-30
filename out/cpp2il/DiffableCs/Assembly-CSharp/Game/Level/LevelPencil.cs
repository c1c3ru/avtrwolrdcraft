namespace Game.Level;

public class LevelPencil : LevelSimpleDragActionPointItemBase<LevelPaperItemHandler>
{
	[SerializeField]
	private Color _color; //Field offset: 0x354

	public LevelPencil() { }

	protected virtual void OnTargetEnter(LevelPaperItemHandler paper) { }

	protected virtual void OnTargetExit(LevelPaperItemHandler paper) { }

	public void SetColor(Color color) { }

	private void Start() { }

}

