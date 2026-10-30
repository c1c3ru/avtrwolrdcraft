namespace Unity.Services.Authentication;

internal class ProfileComponent : IProfile
{
	[CompilerGenerated]
	private Action<ProfileEventArgs> ProfileChange; //Field offset: 0x10
	private string _current; //Field offset: 0x18

	public override event Action<ProfileEventArgs> ProfileChange
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public override string Current
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	internal ProfileComponent(string profile) { }

	[CompilerGenerated]
	public override void add_ProfileChange(Action<ProfileEventArgs> value) { }

	public override string get_Current() { }

	[CompilerGenerated]
	public override void remove_ProfileChange(Action<ProfileEventArgs> value) { }

	public override void set_Current(string value) { }

	public void SetProfile(string profile) { }

}

