namespace PWC.Level.ContextualAnimation;

public class LevelCADropAreaWithSpineObjectHandlerWithData : LevelCADropActionAreaHandlerWithData
{
	private class AnimationWithSpineObjectRecation
	{
		internal enum AnimationTiming
		{
			Begining = 0,
			Event = 1,
			End = 2,
		}

		public string AvatarAnimationName; //Field offset: 0x10
		public string SpineAnimationName; //Field offset: 0x18
		public AnimationTiming Timing; //Field offset: 0x20
		public bool IsLoop; //Field offset: 0x24
		public bool HavePreAnimation; //Field offset: 0x25
		[ConditionalField("HavePreAnimation", True, True, (array) null)]
		public string PreAnimationName; //Field offset: 0x28

		public AnimationWithSpineObjectRecation() { }

	}

	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x90
	[SerializeField]
	private AnimationWithSpineObjectRecation[] _spineReactions; //Field offset: 0x98

	public LevelCADropAreaWithSpineObjectHandlerWithData() { }

	private AnimationWithSpineObjectRecation FindReaction(string avatarAnimationName, AnimationTiming animationTiming) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual void OnAnimationPostBegin(ICATarget target, LevelCAConfig config, TrackEntry trackEntry) { }

}

