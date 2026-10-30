namespace PWC;

public static class PWCConstants
{
	internal class CA
	{
		public const string LEVEL_CLOTHING_CA_DATAS_PREFIX = "Level/ClothingCAData"; //Field offset: 0x0
		public const string LEVEL_REACTIONS_DATAS_PREFIX = "Level/AnimationsReactions"; //Field offset: 0x0

		public CA() { }

	}

	internal class Layers
	{
		public static readonly int Default; //Field offset: 0x0
		public static readonly int UI; //Field offset: 0x4
		public static readonly int AboveSplitLevel; //Field offset: 0x8
		public static readonly int LevelMirror; //Field offset: 0xC
		public static readonly int BadPositionIndicator; //Field offset: 0x10

		private static Layers() { }

		public Layers() { }

	}

	internal class Masks
	{
		public static readonly int MirrorMask; //Field offset: 0x0

		private static Masks() { }

		public Masks() { }

	}

	internal class ResourcesPathRoots
	{
		public const string LEVEL_CLOTHES_PREFABS = "Level/ClothesPrefabs/"; //Field offset: 0x0
		public const string LEVEL_CLOTHING_MAP_DATA = "Level/LevelClothingMap/"; //Field offset: 0x0
		public const string LEVEL_SPECIAL_CLOTHING_MAP_DATA = "Level/LevelClothingMap/SpecialClothing/"; //Field offset: 0x0

		public ResourcesPathRoots() { }

	}

	internal class ShaderIDs
	{
		public static readonly int SINGLE_COLOR; //Field offset: 0x0
		public static readonly int TOP_COLOR; //Field offset: 0x4
		public static readonly int BOTTOM_COLOR; //Field offset: 0x8
		public static readonly int COLOR_1; //Field offset: 0xC
		public static readonly int COLOR_2; //Field offset: 0x10
		public static readonly int COLOR_3; //Field offset: 0x14
		public static readonly int SECOND_TEXTURE; //Field offset: 0x18

		private static ShaderIDs() { }

		public ShaderIDs() { }

	}

	internal class SoundChannels
	{
		public const int BACKGROUND_MUSIC = 1001; //Field offset: 0x0
		public const int TRAIN_STATION_TRAIN = 1002; //Field offset: 0x0
		public const int DELIVERY_APP_LOADING = 1003; //Field offset: 0x0

		public SoundChannels() { }

	}

	internal class Tags
	{
		public const string DESTROYED = "Destroyed"; //Field offset: 0x0
		public const string IGNORE_PERSISTENT_DATA = "IgnorePersistentData"; //Field offset: 0x0

		public Tags() { }

	}

	public static readonly bool IsAllWorldFree; //Field offset: 0x0

	private static PWCConstants() { }

}

