namespace Unity.Services.Authentication.Internal;

[RequireImplementors]
public interface IPlayerNameComponent : IServiceComponent
{

	public event Action<String> PlayerNameChanged
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public string PlayerName
	{
		 get { } //Length: 0
	}

	[CompilerGenerated]
	public void add_PlayerNameChanged(Action<String> value) { }

	public string get_PlayerName() { }

	[CompilerGenerated]
	public void remove_PlayerNameChanged(Action<String> value) { }

}

