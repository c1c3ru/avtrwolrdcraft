namespace PazuCore.PazuCoreAddressables.AFC.RD;

public class AFCRDOpenGameHandler : AFCRDHandlerBase
{
	private int _gameId; //Field offset: 0x40
	private AppContentData _appContentData; //Field offset: 0x48

	public AFCRDOpenGameHandler() { }

	[CompilerGenerated]
	private void <ExecuteImplement>g__OnFinish|3_0(bool success) { }

	protected virtual void ExecuteImplement() { }

	public void SetData(int gameId, AppContentData appContentData = null) { }

}

