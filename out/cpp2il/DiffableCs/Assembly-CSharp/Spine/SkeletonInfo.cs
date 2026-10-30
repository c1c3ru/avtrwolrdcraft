namespace Spine;

public class SkeletonInfo
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<BoneInfo, String> <>9__23_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <SortLists>b__23_0(BoneInfo x) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass22_0
	{
		public SkeletonInfo <>4__this; //Field offset: 0x0
		public string _bonesProblemResults; //Field offset: 0x8

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass22_1
	{
		public int i; //Field offset: 0x0

	}

	public SkeletonAnimation skeletonData; //Field offset: 0x10
	public string currentSkeletonType; //Field offset: 0x18
	public float rootScale; //Field offset: 0x20
	public List<BoneInfo> boneInfo; //Field offset: 0x28
	public List<String> slot; //Field offset: 0x30
	public List<String> skin; //Field offset: 0x38
	public List<String> events; //Field offset: 0x40
	public List<String> animations; //Field offset: 0x48
	public List<String> ikConstraints; //Field offset: 0x50
	public List<String> transformConstraints; //Field offset: 0x58
	public List<String> pathConstraints; //Field offset: 0x60
	public float x; //Field offset: 0x68
	public float y; //Field offset: 0x6C
	public float width; //Field offset: 0x70
	public float height; //Field offset: 0x74
	public string version; //Field offset: 0x78
	public string hash; //Field offset: 0x80
	public string imagesPath; //Field offset: 0x88
	public string audioPath; //Field offset: 0x90
	public float fps; //Field offset: 0x98
	public ExposedList<Animation> animaionsList; //Field offset: 0xA0

	public SkeletonInfo() { }

	[CompilerGenerated]
	private bool <CheckBonesScale>g__IsBoneScaleProblem|22_0(string boneName, float scaleX, float scaleY, ref <>c__DisplayClass22_0 unnamed_param_3, ref <>c__DisplayClass22_1 unnamed_param_4) { }

	public string CheckBonesScale() { }

	public void GetSkeletonStartInfo(string type) { }

	public void PrintInfo() { }

	public void SetSkeltonInfo() { }

	public void SortLists() { }

}

