namespace PWC.Level;

public class LevelCharacterInteractionHandler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LevelCAItemHandlerBase> <>9__30_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <TryPutInHand>b__30_0(LevelCAItemHandlerBase x) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass30_0
	{
		public LevelCharacterInteractionHandler <>4__this; //Field offset: 0x0
		public LevelItem levelItem; //Field offset: 0x8

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public LevelItem levelItem; //Field offset: 0x10
		public LevelCharacterInteractionHandler <>4__this; //Field offset: 0x18
		public LevelEatableItemHandler eatableItemHandler; //Field offset: 0x20
		public Action<LevelItem> <>9__2; //Field offset: 0x28

		public <>c__DisplayClass35_0() { }

		internal void <Eat>b__0() { }

		internal void <Eat>b__1() { }

		internal void <Eat>b__2(LevelItem x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public LevelCharacterInteractionHandler <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass37_0() { }

		internal void <Drink>b__0(TrackEntry t, Event e) { }

		internal void <Drink>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass40_0
	{
		public LevelItem levelItem; //Field offset: 0x10

		public <>c__DisplayClass40_0() { }

		internal void <PutInBone>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass49_0
	{
		public LevelSleepArea levelSleepArea; //Field offset: 0x10
		public Transform place; //Field offset: 0x18
		public LevelCharacterInteractionHandler <>4__this; //Field offset: 0x20

		public <>c__DisplayClass49_0() { }

		internal void <SleepOn>b__0(TrackEntry x) { }

	}

	internal class Area
	{
		public readonly Bone bone; //Field offset: 0x10
		public readonly CShapeModel cShapeModel; //Field offset: 0x18
		public readonly GameShapeNoTransform gameShape; //Field offset: 0x20
		private readonly LevelCharacter _character; //Field offset: 0x28
		private readonly Transform _spineRoot; //Field offset: 0x30

		public Area(Bone bone, CShapeModel cShapeModel, LevelCharacter character) { }

		public Vector2 GetWorldPosition() { }

		public bool IsLevelItemTouchingAreaVisibleToUser(LevelItem levelItem, bool includeTouchingShapeTestWhenHasTouchOverride = false) { }

		public bool IsLevelRestAreaTouchingAreaVisibleToUser(LevelAvatarRestAreaBase levelRestArea) { }

		public bool IsPointInsideShape(Vector2 point) { }

		public bool IsTouching(CShapeModel cShapeModel) { }

		public bool IsTouchingAreaVisibleToUser(Transform target, GameShapeBase targetGameShape) { }

		public void UpdateBoneData() { }

	}

	internal enum AreaType
	{
		None = 0,
		LeftHand = 1,
		RightHand = 2,
		Mouth = 3,
		Sit = 4,
		Head = 5,
		Middle = 6,
	}

	internal sealed class TryPutClothingDelegate : MulticastDelegate
	{

		public TryPutClothingDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(int categoryType, string skinName, PWSpriteColorType colorType, Color[] colors, bool throwExistingClothingItem, AsyncCallback callback, object object) { }

		public override bool EndInvoke(IAsyncResult result) { }

		public override bool Invoke(int categoryType, string skinName, PWSpriteColorType colorType, Color[] colors, bool throwExistingClothingItem) { }

	}

	private readonly Area _leftHandArea; //Field offset: 0x10
	private readonly Area _rightHandArea; //Field offset: 0x18
	private readonly Area _mouthArea; //Field offset: 0x20
	private readonly Area _sitArea; //Field offset: 0x28
	private readonly Area _headArea; //Field offset: 0x30
	private readonly Area _behaviorItemInteractionArea; //Field offset: 0x38
	private readonly Dictionary<CharacterClothingType, Area> _clothingAreas; //Field offset: 0x40
	private readonly SkeletonAnimation _skeletonAnimation; //Field offset: 0x48
	private readonly TryPutClothingDelegate _tryPutClothingAction; //Field offset: 0x50
	private readonly LevelCharacter _character; //Field offset: 0x58
	private readonly Dictionary<CharacterClothingType, Area> _clothingPickUpAreas; //Field offset: 0x60
	private BoneFollower _leftHandBoneFollower; //Field offset: 0x68
	private BoneFollower _rightHandBoneFollower; //Field offset: 0x70
	[CompilerGenerated]
	private LevelItemOnCharacterBase <CurrentBehaviorItem>k__BackingField; //Field offset: 0x78
	[CompilerGenerated]
	private Action<LevelItem> OnPutItemInBoneAction; //Field offset: 0x80

	public event Action<LevelItem> OnPutItemInBoneAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public ReadOnlyDictionary<CharacterClothingType, Area> ClothingAreas
	{
		 get { } //Length: 124
	}

	public LevelItemOnCharacterBase CurrentBehaviorItem
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelCharacterInteractionHandler(LevelCharacter character, SkeletonAnimation skeletonAnimation, TryPutClothingDelegate tryPutClothingAction) { }

	[CompilerGenerated]
	private bool <TryPutInHand>g__TryPutInLeftHand|30_1(ref <>c__DisplayClass30_0 unnamed_param_0) { }

	[CompilerGenerated]
	private bool <TryPutInHand>g__TryPutInRightHand|30_2(ref <>c__DisplayClass30_0 unnamed_param_0) { }

	[CompilerGenerated]
	public void add_OnPutItemInBoneAction(Action<LevelItem> value) { }

	public bool CanEatOrDrink() { }

	private Area CreateArea(string boneName, CShapeModel cShapeModel) { }

	private Area CreateArea(string boneName, float radius = 0,1, Vector2 offset = null, float scale = 1) { }

	public void Drink(LevelItem levelItem) { }

	public void Eat(LevelEatableItemHandler eatableItemHandler) { }

	public BoneFollower FollowBone(Transform target, string boneName, bool followRotation = false, bool followScale = false) { }

	private void FreeHand(ref BoneFollower boneFollower) { }

	public void FreeHand(AvatarHandType characterHandType) { }

	public void FreeHands() { }

	public ReadOnlyDictionary<CharacterClothingType, Area> get_ClothingAreas() { }

	[CompilerGenerated]
	public LevelItemOnCharacterBase get_CurrentBehaviorItem() { }

	public Area GetAreaByType(AreaType areaType) { }

	public Area GetBehaviorItemInteractionArea() { }

	public Vector2 GetDefaultPositionInHand(LevelItem levelItem, Transform parent) { }

	public BoneFollower GetHandBoneFollower(ItemOnAvatarType type) { }

	public Area GetHeadArea() { }

	public void PutInArea(LevelItem levelItem, Area area, ItemOnAvatarType itemOnAvatarType, out BoneFollower boneFollower, bool snap = false, bool callEvents = true, Nullable<Vector2> pivot = null) { }

	public void PutInBone(LevelItem levelItem, string boneName, ItemOnAvatarType itemOnAvatarType, out BoneFollower boneFollower, bool snap = false, bool followRotation = true, bool followScale = true, bool callEvents = true, Nullable<Vector2> pivot = null) { }

	public void PutInHand(LevelItem levelItem, AvatarHandType characterHandType, bool snap = false, bool callEvents = true, Nullable<Vector2> pivot = null) { }

	public void ReleaseCurrentBehaviorItemIfExists() { }

	[CompilerGenerated]
	public void remove_OnPutItemInBoneAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void set_CurrentBehaviorItem(LevelItemOnCharacterBase value) { }

	public void SitOn(LevelSitArea levelSitArea, bool snap) { }

	public void SleepOn(LevelSleepArea levelSleepArea, bool snap, string placeGuid = null) { }

	public bool TryDrink(LevelItem levelItem) { }

	public bool TryEat(LevelEatableItemHandler eatableItemHandler) { }

	public BoneFollower TryGetBoneFollower(string boneName) { }

	public bool TryGetClothingArea(CharacterClothingType clothingType, out Area area) { }

	public bool TryGetClothingPickUpArea(CharacterClothingType clothingType, out Area area) { }

	public bool TryGetHandItem(AvatarHandType type, out LevelItem levelItem) { }

	public bool TryPutClothing(ILevelClothingItem clothingItem) { }

	public bool TryPutInHand(LevelItem levelItem) { }

	public bool TrySitOn(LevelSitArea levelSitArea) { }

	public bool TrySleepOn(LevelSleepArea levelSleepArea) { }

}

