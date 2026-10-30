namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCAReactionsData : ScriptableObject
{
	internal enum ActionType
	{
		None = 0,
		ClosestAvatar = 1,
		RandomAvatarInRadius = 2,
		AvatarsInRadius = 3,
		AllAvatars = 4,
		OnThisDropArea = 5,
		OnAnotherDropArea = 6,
		ClosestAvatarInRadius = 7,
		SpecificReactionAvatarInRadius = 8,
	}

	internal class ReactionAnimationData
	{
		public string animationName; //Field offset: 0x10
		public string reactionAnimationName; //Field offset: 0x18
		public List<String> reactionAnimationNames; //Field offset: 0x20
		public ReactionTimingType reactionTimingType; //Field offset: 0x28
		[SerializeField]
		public bool isMoveToPosition; //Field offset: 0x2C
		[ConditionalField("isMoveToPosition", True, True, (array) null)]
		public Vector2 reactedAvatarLocalPosition; //Field offset: 0x30
		public bool isLoop; //Field offset: 0x38
		public bool faceToFaceAvatar; //Field offset: 0x39
		public SpineType spineType; //Field offset: 0x3C
		public ActionType actionType; //Field offset: 0x40
		public bool shouldStayOnParent; //Field offset: 0x44
		public int specificReactionAvatarID; //Field offset: 0x48

		public ReactionAnimationData() { }

		public string GetResolvedReactionAnimationName() { }

	}

	internal enum ReactionTimingType
	{
		None = 0,
		Begin = 1,
		End = 2,
		Event = 3,
	}

	[SerializeField]
	private List<ReactionAnimationData> _reactions; //Field offset: 0x18

	public List<ReactionAnimationData> reactions
	{
		 get { } //Length: 8
	}

	public LevelCAReactionsData() { }

	public List<ReactionAnimationData> get_reactions() { }

}

