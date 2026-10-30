namespace PWC.Level.HintBubble;

[CreateAssetMenu(fileName = "LevelHintBubbleData", menuName = "PazuWorld/Level/HintBubbleData")]
public class LevelHintBubbleData : ScriptableObject
{
	internal class TypeData
	{
		internal class Match
		{
			internal class SubMatch
			{
				public int subMatchId; //Field offset: 0x10
				public List<PDPrefabReference> prefabs; //Field offset: 0x18

				public SubMatch() { }

			}

			public int matchId; //Field offset: 0x10
			public PDPrefabReference prefab; //Field offset: 0x18
			public List<SubMatch> subMatches; //Field offset: 0x20

			public Match() { }

		}

		public LevelHintBubbleType type; //Field offset: 0x10
		public List<Match> matches; //Field offset: 0x18

		public TypeData() { }

	}

	private static Dictionary<LevelHintBubbleType, Dictionary`2<Int32, Match>> _hashedData; //Field offset: 0x0
	public List<TypeData> dataList; //Field offset: 0x18

	public LevelHintBubbleData() { }

	public static LevelHintBubbleData GetHintBubbleData() { }

	public static bool TryGetValue(ILevelHintBubbleTarget target, out Match match) { }

	public static bool TryGetValue(LevelHintBubbleType type, int matchId, out Match match) { }

}

