namespace Spine;

public class Skeleton
{
	internal enum Physics
	{
		None = 0,
		Reset = 1,
		Update = 2,
		Pose = 3,
	}

	private static readonly Int32[] quadTriangles; //Field offset: 0x0
	internal SkeletonData data; //Field offset: 0x10
	internal ExposedList<Bone> bones; //Field offset: 0x18
	internal ExposedList<Slot> slots; //Field offset: 0x20
	internal ExposedList<Slot> drawOrder; //Field offset: 0x28
	internal ExposedList<IkConstraint> ikConstraints; //Field offset: 0x30
	internal ExposedList<TransformConstraint> transformConstraints; //Field offset: 0x38
	internal ExposedList<PathConstraint> pathConstraints; //Field offset: 0x40
	internal ExposedList<PhysicsConstraint> physicsConstraints; //Field offset: 0x48
	internal ExposedList<IUpdatable> updateCache; //Field offset: 0x50
	internal Skin skin; //Field offset: 0x58
	internal float r; //Field offset: 0x60
	internal float g; //Field offset: 0x64
	internal float b; //Field offset: 0x68
	internal float a; //Field offset: 0x6C
	internal float x; //Field offset: 0x70
	internal float y; //Field offset: 0x74
	internal float scaleX; //Field offset: 0x78
	internal float time; //Field offset: 0x7C
	private float scaleY; //Field offset: 0x80

	public float A
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float B
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ExposedList<Bone> Bones
	{
		 get { } //Length: 8
	}

	public SkeletonData Data
	{
		 get { } //Length: 8
	}

	public ExposedList<Slot> DrawOrder
	{
		 get { } //Length: 8
	}

	[Obsolete("Use ScaleX instead. FlipX is when ScaleX is negative.")]
	public bool FlipX
	{
		 get { } //Length: 16
		 set { } //Length: 40
	}

	[Obsolete("Use ScaleY instead. FlipY is when ScaleY is negative.")]
	public bool FlipY
	{
		 get { } //Length: 16
		 set { } //Length: 40
	}

	public float G
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ExposedList<IkConstraint> IkConstraints
	{
		 get { } //Length: 8
	}

	public ExposedList<PathConstraint> PathConstraints
	{
		 get { } //Length: 8
	}

	public ExposedList<PhysicsConstraint> PhysicsConstraints
	{
		 get { } //Length: 8
	}

	public float R
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Bone RootBone
	{
		 get { } //Length: 64
	}

	public float ScaleX
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float ScaleY
	{
		 get { } //Length: 92
		 set { } //Length: 8
	}

	public Skin Skin
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	public ExposedList<Slot> Slots
	{
		 get { } //Length: 8
	}

	public float Time
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ExposedList<TransformConstraint> TransformConstraints
	{
		 get { } //Length: 8
	}

	public ExposedList<IUpdatable> UpdateCacheList
	{
		 get { } //Length: 8
	}

	public float X
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Y
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private static Skeleton() { }

	public Skeleton(Skeleton skeleton) { }

	public Skeleton(SkeletonData data) { }

	public Bone FindBone(string boneName) { }

	public IkConstraint FindIkConstraint(string constraintName) { }

	public PathConstraint FindPathConstraint(string constraintName) { }

	public PhysicsConstraint FindPhysicsConstraint(string constraintName) { }

	public Slot FindSlot(string slotName) { }

	public TransformConstraint FindTransformConstraint(string constraintName) { }

	public float get_A() { }

	public float get_B() { }

	public ExposedList<Bone> get_Bones() { }

	public SkeletonData get_Data() { }

	public ExposedList<Slot> get_DrawOrder() { }

	public bool get_FlipX() { }

	public bool get_FlipY() { }

	public float get_G() { }

	public ExposedList<IkConstraint> get_IkConstraints() { }

	public ExposedList<PathConstraint> get_PathConstraints() { }

	public ExposedList<PhysicsConstraint> get_PhysicsConstraints() { }

	public float get_R() { }

	public Bone get_RootBone() { }

	public float get_ScaleX() { }

	public float get_ScaleY() { }

	public Skin get_Skin() { }

	public ExposedList<Slot> get_Slots() { }

	public float get_Time() { }

	public ExposedList<TransformConstraint> get_TransformConstraints() { }

	public ExposedList<IUpdatable> get_UpdateCacheList() { }

	public float get_X() { }

	public float get_Y() { }

	public Attachment GetAttachment(int slotIndex, string attachmentName) { }

	public Attachment GetAttachment(string slotName, string attachmentName) { }

	public void GetBounds(out float x, out float y, out float width, out float height, ref Single[] vertexBuffer, SkeletonClipping clipper = null) { }

	public void PhysicsRotate(float x, float y, float degrees) { }

	public void PhysicsTranslate(float x, float y) { }

	public void set_A(float value) { }

	public void set_B(float value) { }

	public void set_FlipX(bool value) { }

	public void set_FlipY(bool value) { }

	public void set_G(float value) { }

	public void set_R(float value) { }

	public void set_ScaleX(float value) { }

	public void set_ScaleY(float value) { }

	public void set_Skin(Skin value) { }

	public void set_Time(float value) { }

	public void set_X(float value) { }

	public void set_Y(float value) { }

	public void SetAttachment(string slotName, string attachmentName) { }

	public void SetBonesToSetupPose() { }

	public void SetSkin(Skin newSkin) { }

	public void SetSkin(string skinName) { }

	public void SetSlotsToSetupPose() { }

	public void SetToSetupPose() { }

	private void SortBone(Bone bone) { }

	private void SortIkConstraint(IkConstraint constraint) { }

	private void SortPathConstraint(PathConstraint constraint) { }

	private void SortPathConstraintAttachment(Attachment attachment, Bone slotBone) { }

	private void SortPathConstraintAttachment(Skin skin, int slotIndex, Bone slotBone) { }

	private void SortPhysicsConstraint(PhysicsConstraint constraint) { }

	private static void SortReset(ExposedList<Bone> bones) { }

	private void SortTransformConstraint(TransformConstraint constraint) { }

	public virtual string ToString() { }

	public void Update(float delta) { }

	public void UpdateCache() { }

	public void UpdateWorldTransform(Physics physics, Bone parent) { }

	public void UpdateWorldTransform(Physics physics) { }

}

