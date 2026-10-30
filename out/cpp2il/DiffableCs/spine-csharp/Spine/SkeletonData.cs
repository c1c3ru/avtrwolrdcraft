namespace Spine;

public class SkeletonData
{
	internal string name; //Field offset: 0x10
	internal ExposedList<BoneData> bones; //Field offset: 0x18
	internal ExposedList<SlotData> slots; //Field offset: 0x20
	internal ExposedList<Skin> skins; //Field offset: 0x28
	internal Skin defaultSkin; //Field offset: 0x30
	internal ExposedList<EventData> events; //Field offset: 0x38
	internal ExposedList<Animation> animations; //Field offset: 0x40
	internal ExposedList<IkConstraintData> ikConstraints; //Field offset: 0x48
	internal ExposedList<TransformConstraintData> transformConstraints; //Field offset: 0x50
	internal ExposedList<PathConstraintData> pathConstraints; //Field offset: 0x58
	internal ExposedList<PhysicsConstraintData> physicsConstraints; //Field offset: 0x60
	internal float x; //Field offset: 0x68
	internal float y; //Field offset: 0x6C
	internal float width; //Field offset: 0x70
	internal float height; //Field offset: 0x74
	internal float referenceScale; //Field offset: 0x78
	internal string version; //Field offset: 0x80
	internal string hash; //Field offset: 0x88
	internal float fps; //Field offset: 0x90
	internal string imagesPath; //Field offset: 0x98
	internal string audioPath; //Field offset: 0xA0

	public ExposedList<Animation> Animations
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public string AudioPath
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ExposedList<BoneData> Bones
	{
		 get { } //Length: 8
	}

	public Skin DefaultSkin
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ExposedList<EventData> Events
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Fps
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public string Hash
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Height
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ExposedList<IkConstraintData> IkConstraints
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public string ImagesPath
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public string Name
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ExposedList<PathConstraintData> PathConstraints
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ExposedList<PhysicsConstraintData> PhysicsConstraints
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float ReferenceScale
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ExposedList<Skin> Skins
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ExposedList<SlotData> Slots
	{
		 get { } //Length: 8
	}

	public ExposedList<TransformConstraintData> TransformConstraints
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public string Version
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Width
	{
		 get { } //Length: 8
		 set { } //Length: 8
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

	public SkeletonData() { }

	public Animation FindAnimation(string animationName) { }

	public BoneData FindBone(string boneName) { }

	public EventData FindEvent(string eventDataName) { }

	public IkConstraintData FindIkConstraint(string constraintName) { }

	public PathConstraintData FindPathConstraint(string constraintName) { }

	public PhysicsConstraintData FindPhysicsConstraint(string constraintName) { }

	public Skin FindSkin(string skinName) { }

	public SlotData FindSlot(string slotName) { }

	public TransformConstraintData FindTransformConstraint(string constraintName) { }

	public ExposedList<Animation> get_Animations() { }

	public string get_AudioPath() { }

	public ExposedList<BoneData> get_Bones() { }

	public Skin get_DefaultSkin() { }

	public ExposedList<EventData> get_Events() { }

	public float get_Fps() { }

	public string get_Hash() { }

	public float get_Height() { }

	public ExposedList<IkConstraintData> get_IkConstraints() { }

	public string get_ImagesPath() { }

	public string get_Name() { }

	public ExposedList<PathConstraintData> get_PathConstraints() { }

	public ExposedList<PhysicsConstraintData> get_PhysicsConstraints() { }

	public float get_ReferenceScale() { }

	public ExposedList<Skin> get_Skins() { }

	public ExposedList<SlotData> get_Slots() { }

	public ExposedList<TransformConstraintData> get_TransformConstraints() { }

	public string get_Version() { }

	public float get_Width() { }

	public float get_X() { }

	public float get_Y() { }

	public void set_Animations(ExposedList<Animation> value) { }

	public void set_AudioPath(string value) { }

	public void set_DefaultSkin(Skin value) { }

	public void set_Events(ExposedList<EventData> value) { }

	public void set_Fps(float value) { }

	public void set_Hash(string value) { }

	public void set_Height(float value) { }

	public void set_IkConstraints(ExposedList<IkConstraintData> value) { }

	public void set_ImagesPath(string value) { }

	public void set_Name(string value) { }

	public void set_PathConstraints(ExposedList<PathConstraintData> value) { }

	public void set_PhysicsConstraints(ExposedList<PhysicsConstraintData> value) { }

	public void set_ReferenceScale(float value) { }

	public void set_Skins(ExposedList<Skin> value) { }

	public void set_TransformConstraints(ExposedList<TransformConstraintData> value) { }

	public void set_Version(string value) { }

	public void set_Width(float value) { }

	public void set_X(float value) { }

	public void set_Y(float value) { }

	public virtual string ToString() { }

}

