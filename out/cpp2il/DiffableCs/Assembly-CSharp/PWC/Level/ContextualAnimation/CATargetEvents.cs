namespace PWC.Level.ContextualAnimation;

public static class CATargetEvents
{
	public static Action<ICATarget, Boolean> OnSelectedAction; //Field offset: 0x0
	public static Action<ICATarget, Boolean, Boolean> OnUpdateCAListAction; //Field offset: 0x8
	public static Action<ICATarget> OnCAAnimationInterruptAction; //Field offset: 0x10

}

