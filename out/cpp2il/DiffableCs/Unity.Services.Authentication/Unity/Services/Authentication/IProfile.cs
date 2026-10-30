namespace Unity.Services.Authentication;

internal interface IProfile
{

	public event Action<ProfileEventArgs> ProfileChange
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public string Current
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	[CompilerGenerated]
	public void add_ProfileChange(Action<ProfileEventArgs> value) { }

	public string get_Current() { }

	[CompilerGenerated]
	public void remove_ProfileChange(Action<ProfileEventArgs> value) { }

	public void set_Current(string value) { }

}

