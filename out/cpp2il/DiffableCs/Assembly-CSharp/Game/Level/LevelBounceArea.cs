namespace Game.Level;

public class LevelBounceArea : LevelAllowOverlap1DDropArea
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public LevelBounceArea <>4__this; //Field offset: 0x10
		public GameObject movingObject; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal void <Bounce>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public LevelBounceArea <>4__this; //Field offset: 0x10
		public GameObject movingObject; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <Fall>b__0() { }

	}

	[SerializeField]
	private string _soundName; //Field offset: 0xD8
	private int _currentCharacterAnimationNumber; //Field offset: 0xE0

	public LevelBounceArea() { }

	private void Bounce(GameObject movingObject) { }

	public virtual bool CanConsumeCharacters() { }

	private void Fall(GameObject movingObject) { }

	public virtual void OnItemEndDrop(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

	public virtual bool OverrideAvatarEndDropAnimation(ILevelAvatar _) { }

	public virtual bool OverrideItemFallTween(LevelItem levelItem, out LTDescr tween) { }

	private void SetCharacterJumpAnimationNumber() { }

}

