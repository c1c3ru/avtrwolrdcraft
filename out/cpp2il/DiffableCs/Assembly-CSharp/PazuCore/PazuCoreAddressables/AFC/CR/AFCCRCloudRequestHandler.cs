namespace PazuCore.PazuCoreAddressables.AFC.CR;

public class AFCCRCloudRequestHandler : AFCUnityMessageDrivenHandlerBase
{
	[CompilerGenerated]
	private sealed class <GetDataFromServer>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AFCCRCloudRequestHandler <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <GetDataFromServer>d__16(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private static readonly Dictionary<String, Dictionary`2<String, Object>> _allResponsesData; //Field offset: 0x0
	[SerializeField]
	private string _op; //Field offset: 0x28
	[SerializeField]
	private bool _sendScreenDimensions; //Field offset: 0x30
	[SerializeField]
	private bool _sendInstalledGamesList; //Field offset: 0x31
	[SerializeField]
	private bool _waitForUserSpecificData; //Field offset: 0x32
	[SerializeField]
	private UnityEvent _onFinish; //Field offset: 0x38
	[SerializeField]
	private string _group; //Field offset: 0x40
	[SerializeField]
	private string _responseKey; //Field offset: 0x48
	[SerializeField]
	private bool _keepResponseDataPostDestroy; //Field offset: 0x50
	[SerializeField]
	private bool _useExistingResponseDataWhenPossible; //Field offset: 0x51
	[SerializeField]
	private AFCCRTextureComponent[] _textureComponents; //Field offset: 0x58
	private bool _isGettingDataInProgress; //Field offset: 0x60
	private Dictionary<String, Object> _responseData; //Field offset: 0x68

	private static AFCCRCloudRequestHandler() { }

	public AFCCRCloudRequestHandler() { }

	[CompilerGenerated]
	private void <GetDataFromServer>b__16_0(string responseText) { }

	[IteratorStateMachine(typeof(<GetDataFromServer>d__16))]
	private IEnumerator GetDataFromServer() { }

	private string GetFullGroupName() { }

	protected virtual void OnDestroy() { }

	public virtual void PerformAction() { }

	public void SendCloudRequest() { }

	private void SetResponse(Response response) { }

	public static bool TryGetResponseData(string key, out Dictionary<String, Object>& data) { }

	private void UpdateGCTexture(Response response) { }

}

