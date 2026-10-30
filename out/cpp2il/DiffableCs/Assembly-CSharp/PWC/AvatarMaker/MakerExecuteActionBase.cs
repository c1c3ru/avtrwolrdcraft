namespace PWC.AvatarMaker;

public abstract class MakerExecuteActionBase
{
	internal class SkinColorData
	{
		public Color DisplayColor; //Field offset: 0x10
		public Color[] Colors; //Field offset: 0x20

		public SkinColorData() { }

	}

	internal class TemplateColorData
	{
		public int CategoryType; //Field offset: 0x10
		public Color[] Colors; //Field offset: 0x18

		public TemplateColorData() { }

	}

	internal class TemplateRestoreData
	{
		public List<Int32> SlotCategoryTypes; //Field offset: 0x10
		public List<Int32> CategoryTypes; //Field offset: 0x18
		public List<String> SkinNames; //Field offset: 0x20
		public List<Color[]> Colors; //Field offset: 0x28

		public TemplateRestoreData() { }

	}


	protected static AvatarSpineSkinsManagerBase SpineSkinManager
	{
		 get { } //Length: 84
	}

	protected MakerExecuteActionBase() { }

	public static MakerExecuteActionBase CreateFromRecoveryData(object recoveryData) { }

	protected abstract void ExecuteActionInternal() { }

	protected static AvatarSpineSkinsManagerBase get_SpineSkinManager() { }

	protected abstract object GetRecoveryData() { }

	public static TemplateRestoreData GetSlotRestoreData(AvatarSpineSkinsManagerBase spineSkinManager, List<Int32> slotCategoryTypes) { }

	public bool TryExecute(out object recoveryData) { }

}

