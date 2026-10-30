namespace Game.Level;

public class CurrentAvatarGroupIDsCondition : GenericConditionBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public GenericConditionData genericConditionData; //Field offset: 0x10

		public <>c__DisplayClass1_0() { }

		internal bool <IsMet>b__0(int id) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_1
	{
		public int id; //Field offset: 0x10

		public <>c__DisplayClass1_1() { }

		internal bool <IsMet>b__1(ILevelAvatar a) { }

	}

	public List<Int32> avatarIDs; //Field offset: 0x10

	public CurrentAvatarGroupIDsCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

