namespace PWC.Level.HintBubble;

public static class LevelHintBubbleState
{
	internal class State : ISerializationCallbackReceiver
	{
		internal class StateMatch
		{
			public int matchId; //Field offset: 0x10
			public List<Int32> subMatcheIds; //Field offset: 0x18

			public StateMatch() { }

		}

		public LevelHintBubbleType type; //Field offset: 0x10
		public List<StateMatch> used; //Field offset: 0x18
		[CompilerGenerated]
		private Dictionary<Int32, HashSet`1<Int32>> <HashedUsed>k__BackingField; //Field offset: 0x20
		[CompilerGenerated]
		private bool <IsDirty>k__BackingField; //Field offset: 0x28

		public Dictionary<Int32, HashSet`1<Int32>> HashedUsed
		{
			[CompilerGenerated]
			 get { } //Length: 8
			[CompilerGenerated]
			 set { } //Length: 8
		}

		public bool IsDirty
		{
			[CompilerGenerated]
			 get { } //Length: 8
			[CompilerGenerated]
			 set { } //Length: 12
		}

		public State() { }

		[CompilerGenerated]
		public Dictionary<Int32, HashSet`1<Int32>> get_HashedUsed() { }

		[CompilerGenerated]
		public bool get_IsDirty() { }

		public override void OnAfterDeserialize() { }

		public override void OnBeforeSerialize() { }

		[CompilerGenerated]
		public void set_HashedUsed(Dictionary<Int32, HashSet`1<Int32>> value) { }

		[CompilerGenerated]
		public void set_IsDirty(bool value) { }

	}

	private static bool _didEnsureFolder; //Field offset: 0x0
	private const string FOLDER_NAME = "LevelHintBubble/"; //Field offset: 0x0
	private static readonly Dictionary<LevelHintBubbleType, State> _used; //Field offset: 0x8
	private static readonly HashSet<LevelHintBubbleType> _ensuredTypes; //Field offset: 0x10

	private static LevelHintBubbleState() { }

	public static void DeleteAllData() { }

	private static void EnsureFolder() { }

	private static void EnsureState(LevelHintBubbleType type) { }

	private static string GetFileName(LevelHintBubbleType type) { }

	private static string GetFolderAbsolutePath() { }

	public static bool IsUsed(ILevelHintBubbleTarget target) { }

	public static bool IsUsed(LevelHintBubbleType type, int matchId, int subMatchId) { }

	public static void MarkAsUsed(ILevelHintBubbleTarget target) { }

	public static void MarkAsUsed(LevelHintBubbleType type, int matchId, int subMatchId) { }

	public static void SaveDirtyData() { }

}

