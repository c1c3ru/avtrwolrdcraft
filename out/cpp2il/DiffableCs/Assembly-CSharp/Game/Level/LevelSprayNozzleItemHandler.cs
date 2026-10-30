namespace Game.Level;

public class LevelSprayNozzleItemHandler : MonoBehaviour
{
	[SerializeField]
	private bool _isAShapeNozzle; //Field offset: 0x20
	[SerializeField]
	private Sprite _brushSprite; //Field offset: 0x28

	public Sprite BrushSprite
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool IsAShapeNozzle
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelSprayNozzleItemHandler() { }

	public Sprite get_BrushSprite() { }

	public bool get_IsAShapeNozzle() { }

	public void set_BrushSprite(Sprite value) { }

	public void set_IsAShapeNozzle(bool value) { }

}

