namespace Unity.Services.Lobbies.Http;

internal interface IError
{

	public int Code
	{
		 get { } //Length: 0
	}

	public string Detail
	{
		 get { } //Length: 0
	}

	public Nullable<Int32> Status
	{
		 get { } //Length: 0
	}

	public string Title
	{
		 get { } //Length: 0
	}

	public string Type
	{
		 get { } //Length: 0
	}

	public int get_Code() { }

	public string get_Detail() { }

	public Nullable<Int32> get_Status() { }

	public string get_Title() { }

	public string get_Type() { }

}

