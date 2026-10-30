namespace PWC.Game;

public class LevelPinataArea : LevelConsumerAreaBase
{
	[SerializeField]
	private bool _isAreaAroundPiniata; //Field offset: 0x51
	[CompilerGenerated]
	private Action OnHitAction; //Field offset: 0x58

	public event Action OnHitAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public bool IsAreaOfPiniata
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelPinataArea() { }

	[CompilerGenerated]
	public void add_OnHitAction(Action value) { }

	public bool get_IsAreaOfPiniata() { }

	public void OnHit() { }

	[CompilerGenerated]
	public void remove_OnHitAction(Action value) { }

	public void set_IsAreaOfPiniata(bool value) { }

}

