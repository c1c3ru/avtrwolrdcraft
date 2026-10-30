namespace ExtraAnimations;

public class ExtraAnimationsData
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public string className; //Field offset: 0x10

		public <>c__DisplayClass7_0() { }

		internal bool <IsAnimationUsed>b__0(ClassNamesAndUsedAnimationsNames x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public string className; //Field offset: 0x10

		public <>c__DisplayClass8_0() { }

		internal bool <SetUsedAnimation>b__0(ClassNamesAndUsedAnimationsNames x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public string className; //Field offset: 0x10

		public <>c__DisplayClass9_0() { }

		internal bool <AddAnimationGroup>b__0(ExtraAnimationsClassNameAndLevels x) { }

	}

	internal class ClassNamesAndUsedAnimationsNames
	{
		public string className; //Field offset: 0x10
		public List<String> animationsNames; //Field offset: 0x18

		public ClassNamesAndUsedAnimationsNames() { }

	}

	internal class ExtraAnimationsClassNameAndLevels
	{
		public string className; //Field offset: 0x10
		public List<Int32> levels; //Field offset: 0x18

		public ExtraAnimationsClassNameAndLevels() { }

	}

	public List<ExtraAnimationsClassNameAndLevels> animationsGroups; //Field offset: 0x10
	public List<ClassNamesAndUsedAnimationsNames> animationsUsedAtLeastOnce; //Field offset: 0x18
	public List<String> usedHandlersByClassNames; //Field offset: 0x20

	public ExtraAnimationsData() { }

	public void AddAnimationGroup(string className, int level) { }

	public bool IsAnimationUsed(string className, string animationName) { }

	public bool IsHandlerNew(string className) { }

	public void SetHandlerOld(string className) { }

	public void SetUsedAnimation(string className, string animationsName) { }

}

