namespace Game.Level;

public static class LevelAvatarRequiredOutfitsData
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public int avatarID; //Field offset: 0x10

		public <>c__DisplayClass7_0() { }

		internal bool <TryResolveForAvatar>b__0(ILevelAvatar x) { }

	}

	private class OutfitSolveRule
	{
		public HashSet<String> requiredSkins; //Field offset: 0x10
		public SecretFullId secretFullId; //Field offset: 0x18
		public List<GenericConditionBase> achievementConditions; //Field offset: 0x20

		public OutfitSolveRule() { }

	}

	private static bool _didInitCollection; //Field offset: 0x0
	private static readonly Dictionary<Int32, List`1<OutfitSolveRule>> _outfits; //Field offset: 0x8
	private static readonly List<OutfitSolveRule> _anyAvatarOutfits; //Field offset: 0x10

	private static LevelAvatarRequiredOutfitsData() { }

	public static void InitCollectionIfNeeded() { }

	public static bool TryGetOutfitOutcome(int avatarID, string skinName, out string outcome) { }

	public static bool TryReevaluateForAvatar(int avatarID, out string outcome) { }

	public static void TryReevaluateForAvatar(int avatarID) { }

	private static bool TryResolveForAvatar(int avatarID, string justWornSkinName, out string outcome) { }

	private static bool TryResolveRules(List<OutfitSolveRule> rules, ILevelAvatar avatar, string justWornSkinName, HashSet<String> currentSkins, out string outcome) { }

}

