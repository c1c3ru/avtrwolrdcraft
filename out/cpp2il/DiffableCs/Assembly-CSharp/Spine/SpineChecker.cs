namespace Spine;

public class SpineChecker : MonoBehaviour
{
	[CompilerGenerated]
	private struct <>c__DisplayClass12_0
	{
		public string checkNameTemp; //Field offset: 0x0
		public SpineChecker <>4__this; //Field offset: 0x8
		public int keyIndex; //Field offset: 0x10
		public Animation animationTemp; //Field offset: 0x18
		public string nameParamaterTemp; //Field offset: 0x20
		public string problemType; //Field offset: 0x28
		public Skeleton skeleton; //Field offset: 0x30

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass12_1
	{
		public ScaleTimeline timeline; //Field offset: 0x0
		public float xTemp; //Field offset: 0x8
		public float yTemp; //Field offset: 0xC

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass15_0
	{
		public bool differenceBetweenBones; //Field offset: 0x0
		public SpineChecker <>4__this; //Field offset: 0x8

	}

	private string _fileName; //Field offset: 0x20
	[SerializeField]
	private SkeletonInfo _currentSkeletonData; //Field offset: 0x28
	[SerializeField]
	private SkeletonInfo _newSkeletonData; //Field offset: 0x30
	[Header("Spine Type Check")]
	[SerializeField]
	private bool _isToddlerCheck; //Field offset: 0x38
	[SerializeField]
	private bool _isBabyCheck; //Field offset: 0x39
	[Header("New Spine Animation Info Check")]
	[SerializeField]
	private float _maxScale; //Field offset: 0x3C
	private string _skeletonsToLog; //Field offset: 0x40
	private string _skeletonsToText; //Field offset: 0x48
	private List<String> _newAnimationsList; //Field offset: 0x50

	public SpineChecker() { }

	[CompilerGenerated]
	private string <AnimationKeysInfo>g__GetBoneName|12_1(int index, ref <>c__DisplayClass12_0 unnamed_param_1) { }

	[CompilerGenerated]
	private string <AnimationKeysInfo>g__GetSlotName|12_2(int index, ref <>c__DisplayClass12_0 unnamed_param_1) { }

	[CompilerGenerated]
	private bool <AnimationKeysInfo>g__IsOneOfBones|12_3(ref <>c__DisplayClass12_0 unnamed_param_0, ref <>c__DisplayClass12_1 unnamed_param_1) { }

	[CompilerGenerated]
	private string <AnimationKeysInfo>g__ProblemDescription|12_0(string property, float value, ref <>c__DisplayClass12_0 unnamed_param_2) { }

	[CompilerGenerated]
	private void <CompareBetweenSkeletons>g__CompareBasicInfo|11_1() { }

	[CompilerGenerated]
	private void <CompareBetweenSkeletons>g__CompareListsInfo|11_2() { }

	[CompilerGenerated]
	internal static string <CompareBetweenSkeletons>g__ReturnSkelsInfo|11_3(string valueCheck, int oldindex, int newIndex) { }

	[CompilerGenerated]
	private void <CompareBetweenSkeletons>g__SkeletonsMainInfo|11_0() { }

	[CompilerGenerated]
	private void <CompareBones>g__BonesSetupInfo|15_0(ref <>c__DisplayClass15_0 unnamed_param_0) { }

	[CompilerGenerated]
	private bool <Start>g__IsProblemOnStart|9_0() { }

	private void AddToLists(string info) { }

	private void AnimationKeysInfo() { }

	private void Compare(string valueCheck, T currentSkelData, T newSkelData) { }

	private void CompareBetweenSkeletons() { }

	private void CompareBones(string valueCheck, List<BoneInfo> oldSkelBoneData, List<BoneInfo> newSkelBoneData) { }

	private void EndColor() { }

	private void EndInfoCheck(string valueCheck) { }

	private string HeaderColor(string color, string header) { }

	private void HeaderInfoCheck(string valueCheck, bool isNewInfo) { }

	private void NewSkeletonBonesScaleCheck() { }

	private void SaveFile(string saveInfo) { }

	public void ShowResult(string header) { }

	private void SoundsEventChecker(string soundEventName) { }

	private void Start() { }

	private void StartColor(string color) { }

	private void StringsListsCompare(string valueCheck, List<String> currentSkelData, List<String> newSkelData) { }

}

