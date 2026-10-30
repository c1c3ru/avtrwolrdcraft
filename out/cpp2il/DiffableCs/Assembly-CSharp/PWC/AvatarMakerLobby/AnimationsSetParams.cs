namespace PWC.AvatarMakerLobby;

public class AnimationsSetParams
{
	public readonly string AnimationName; //Field offset: 0x10
	public readonly Action OnCompleteAction; //Field offset: 0x18
	public readonly ValueTuple<Single, Action>[] ActionsAfterDurations; //Field offset: 0x20
	public readonly int Repetitions; //Field offset: 0x28

	public AnimationsSetParams(string animationName, Action onCompleteAction = null, int repetitions = 1, ValueTuple<Single, Action>[] actionsAfterDurations) { }

}

