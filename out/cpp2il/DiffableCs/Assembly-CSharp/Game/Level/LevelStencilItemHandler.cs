namespace Game.Level;

public class LevelStencilItemHandler : LevelConsumerAreaBase
{
	[SerializeField]
	private LevelGraffitiPaintableItemHandler _levelGraffitiPaintableItemHandler; //Field offset: 0x58
	[SerializeField]
	private bool _isPlacedOnTheWall; //Field offset: 0x60

	public bool IsPlacedOnTheWall
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelStencilItemHandler() { }

	protected virtual void Awake() { }

	public bool get_IsPlacedOnTheWall() { }

	public LMask GetMask() { }

	public Vector3 GetMaskOffset() { }

	public LMask GetNegativeMask() { }

	protected virtual void OnDestroy() { }

	private void OnLevelPostInit() { }

	public void set_IsPlacedOnTheWall(bool value) { }

	public void SetIsPaintable(bool isOn) { }

}

