namespace Spine.Unity;

public static class SkeletonDataCompatibility
{
	internal class CompatibilityProblemInfo
	{
		public VersionInfo actualVersion; //Field offset: 0x10
		public Int32[][] compatibleVersions; //Field offset: 0x18
		public string explicitProblemDescription; //Field offset: 0x20

		public CompatibilityProblemInfo() { }

		public string DescriptionString() { }

	}

	internal enum SourceType
	{
		Json = 0,
		Binary = 1,
	}

	internal class VersionInfo
	{
		public string rawVersion; //Field offset: 0x10
		public Int32[] version; //Field offset: 0x18
		public SourceType sourceType; //Field offset: 0x20

		public VersionInfo() { }

	}


}

