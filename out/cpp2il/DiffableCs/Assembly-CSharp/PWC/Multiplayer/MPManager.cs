namespace PWC.Multiplayer;

public class MPManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<KeyValuePair`2<Int32, String>, Int32> <>9__71_1; //Field offset: 0x8
		public static Func<Int32, Int32> <>9__109_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal int <GetAllPlayersInScene>b__71_1(KeyValuePair<Int32, String> x) { }

		internal int <GetAvatarIdsToShowDisplayInPhone>b__109_0(int x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass103_0
	{
		public MPDataBase data; //Field offset: 0x10
		public int hostPlayerUID; //Field offset: 0x18

		public <>c__DisplayClass103_0() { }

		internal bool <TryBroadcastMessage>b__0(int x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass110_0
	{
		public MPManager <>4__this; //Field offset: 0x10
		public string waitForPlayerRequestGuid; //Field offset: 0x18

		public <>c__DisplayClass110_0() { }

		internal void <SendWaitForPlayerForSceneChangeRequest>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass71_0
	{
		public string sceneId; //Field offset: 0x10

		public <>c__DisplayClass71_0() { }

		internal bool <GetAllPlayersInScene>b__0(KeyValuePair<Int32, String> x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass75_0
	{
		public MPHost mpHost; //Field offset: 0x10
		public MPManager <>4__this; //Field offset: 0x18
		public Action<Boolean> onFinish; //Field offset: 0x20

		public <>c__DisplayClass75_0() { }

		internal void <ConnectAsHost>b__0(bool isSuccess) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass80_0
	{
		public MPManager <>4__this; //Field offset: 0x10
		public Action<Boolean> onFinish; //Field offset: 0x18

		public <>c__DisplayClass80_0() { }

		internal void <ConnectAsClient>b__0(bool isSuccess) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass81_0
	{
		public bool asHost; //Field offset: 0x10
		public MPManager <>4__this; //Field offset: 0x18
		public Action<Boolean> onFinish; //Field offset: 0x20

		public <>c__DisplayClass81_0() { }

		internal void <OnConnectCall>b__0(bool isSuccess) { }

	}

	[CompilerGenerated]
	private sealed class <WaitingForPlayers>d__89 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MPManager <>4__this; //Field offset: 0x20

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
		public <WaitingForPlayers>d__89(int <>1__state) { }

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

	[CompilerGenerated]
	private static bool <IsMultiplayerGame>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnPreSaveCurrentSceneAndSendStartSceneEventAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<Int32> OnPlayerJoinedAction; //Field offset: 0x10
	[CompilerGenerated]
	private static Action<Int32> OnPlayerRemovedAction; //Field offset: 0x18
	[CompilerGenerated]
	private static Action<Int32, String> OnPlayerChangedSceneAction; //Field offset: 0x20
	[CompilerGenerated]
	private static Action OnEnterMultiplayerAction; //Field offset: 0x28
	[CompilerGenerated]
	private static Action OnExitMultiplayerAction; //Field offset: 0x30
	[CompilerGenerated]
	private static MPManager <Instance>k__BackingField; //Field offset: 0x38
	private MPRelayConnectionBase _relayConnection; //Field offset: 0x20
	private Dictionary<Int32, String> _playersScenes; //Field offset: 0x28
	private readonly Dictionary<Int32, AvatarSpineData> _playersAvatarSpineDataForPictures; //Field offset: 0x30
	private readonly HashSet<Int32> _waitingForPlayers; //Field offset: 0x38
	private bool _isSharingSceneWithOtherPlayers; //Field offset: 0x40
	private readonly HashSet<Int32> _playerAvatarOriginalIds; //Field offset: 0x48
	private List<Int32> _avatarIdsToShowInPhone; //Field offset: 0x50
	private HashSet<Int32> _hostAvatarIds; //Field offset: 0x58
	private bool _isWaitingForPlayersRunning; //Field offset: 0x60
	private MPDataType _waitingForDataType; //Field offset: 0x64
	private HashSet<Int32> _players; //Field offset: 0x68
	private readonly Dictionary<String, MPData_SceneChangeRequest> _changeSceneDataRequests; //Field offset: 0x70
	private MPMoveAvatarRequestsHandler _moveAvatarRequestsHandler; //Field offset: 0x78
	private MPChangeSceneRequestsHandler _changeSceneRequestsHandler; //Field offset: 0x80
	[CompilerGenerated]
	private string <CurrentSessionGUID>k__BackingField; //Field offset: 0x88
	[CompilerGenerated]
	private bool <IsSavingSceneForEventData>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private int <HostChangesCounter>k__BackingField; //Field offset: 0x94

	public static event Action OnEnterMultiplayerAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event Action OnExitMultiplayerAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event Action<Int32, String> OnPlayerChangedSceneAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<Int32> OnPlayerJoinedAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<Int32> OnPlayerRemovedAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action OnPreSaveCurrentSceneAndSendStartSceneEventAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public string CurrentSessionGUID
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public private int HostChangesCounter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private static MPManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public static bool IsMultiplayerGame
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		 set { } //Length: 80
	}

	public private bool IsSavingSceneForEventData
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public HashSet<Int32> Players
	{
		 get { } //Length: 8
	}

	public MPRelayConnectionBase RelayConnection
	{
		 get { } //Length: 8
	}

	public MPManager() { }

	[CompilerGenerated]
	public static void add_OnEnterMultiplayerAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnExitMultiplayerAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnPlayerChangedSceneAction(Action<Int32, String> value) { }

	[CompilerGenerated]
	public static void add_OnPlayerJoinedAction(Action<Int32> value) { }

	[CompilerGenerated]
	public static void add_OnPlayerRemovedAction(Action<Int32> value) { }

	[CompilerGenerated]
	public static void add_OnPreSaveCurrentSceneAndSendStartSceneEventAction(Action value) { }

	public void AddWaitToChangeScene(MPData_SceneChangeRequest sceneChangeRequestData) { }

	public void AddWaitToMoveAvatar(int playerUID, int avatarId, string moveAvatarGuid) { }

	public static bool AreaThereOtherPlayersInTheSameSceneAsMe() { }

	private void Awake() { }

	public void ClearPlayerFromScenes(int uid) { }

	private void ClearWorldData() { }

	public void ConnectAsClient(Action<Boolean> onFinish) { }

	public void ConnectAsHost(Action<Boolean> onFinish) { }

	private void ContinueGame() { }

	private static void CopyPersistentDataToMultiplayerFolder() { }

	private static void DeleteMultiplayerPersistentData() { }

	public void Disconnect() { }

	private void FillCacheDataForMultiplayerGame(bool isHost) { }

	public void FixAvatarIds() { }

	[CompilerGenerated]
	public string get_CurrentSessionGUID() { }

	[CompilerGenerated]
	public int get_HostChangesCounter() { }

	[CompilerGenerated]
	public static MPManager get_Instance() { }

	[CompilerGenerated]
	public static bool get_IsMultiplayerGame() { }

	[CompilerGenerated]
	public bool get_IsSavingSceneForEventData() { }

	public HashSet<Int32> get_Players() { }

	public MPRelayConnectionBase get_RelayConnection() { }

	public HashSet<Int32> GetAllPlayersInScene(string sceneId) { }

	public Dictionary<Int32, String> GetAllPlayersInScenes() { }

	public List<Int32> GetAvatarIdsToShowDisplayInPhone() { }

	public int GetNumberOfAllPlayersInScene(string sceneName) { }

	public int GetPlayerUID() { }

	private Int32[] GetWeatherDataPerWorld() { }

	public bool IsHost() { }

	public bool IsHostAndOnlyPlayer() { }

	public bool IsPlayerInScene(int playerUID, string sceneName) { }

	private void LateUpdate() { }

	private void OnActiveSceneChanged(Scene fromScene, Scene toScene) { }

	public void OnClientHasOtherClientRemoved(int playerUID) { }

	private void OnConnectCall(bool asHost, Action<Boolean> onFinish) { }

	private void OnConnectedToHost() { }

	private void OnConnectionAdded(int playerUID, int hostChangesCounter) { }

	private void OnConnectionRemoved(int playerUID) { }

	private void OnDestroy() { }

	private void OnDisconnectedFromHost() { }

	public void OnJoinRequestFromClient(MPData_JoinRequest joinRequestData) { }

	public void OnPlayerJoinedAndStartedGame(int playerUID) { }

	private void OnReceivedData(MPDataBase data) { }

	private void OnRelayConnectionStatusGoneBad() { }

	[CompilerGenerated]
	public static void remove_OnEnterMultiplayerAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnExitMultiplayerAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnPlayerChangedSceneAction(Action<Int32, String> value) { }

	[CompilerGenerated]
	public static void remove_OnPlayerJoinedAction(Action<Int32> value) { }

	[CompilerGenerated]
	public static void remove_OnPlayerRemovedAction(Action<Int32> value) { }

	[CompilerGenerated]
	public static void remove_OnPreSaveCurrentSceneAndSendStartSceneEventAction(Action value) { }

	private void ReplaceCurrentInputModuleWithMPInputModule() { }

	public void SaveCurrentSceneAndSendStartGameEvent(int uid) { }

	public void SaveCurrentSceneAndSendStartSceneEvent(string changeSceneRequestGuid, int uid) { }

	public void SendMessageToNetwork(T data, ICollection<Int32> uids = null) { }

	public void SendWaitForPlayerForSceneChangeRequest(MPData_SceneChangeRequest sceneChangeRequestData) { }

	[CompilerGenerated]
	public void set_CurrentSessionGUID(string value) { }

	[CompilerGenerated]
	private void set_HostChangesCounter(int value) { }

	[CompilerGenerated]
	private static void set_Instance(MPManager value) { }

	[CompilerGenerated]
	public static void set_IsMultiplayerGame(bool value) { }

	[CompilerGenerated]
	private void set_IsSavingSceneForEventData(bool value) { }

	public void SetChangeSceneData(string requestGuid, MPSceneData sceneData, bool shouldSendNowEvenIfHasNoData = false) { }

	public void SetHostAvatarIds(HashSet<Int32> hostAvatarIds) { }

	public void SetHostChangesCounter(int counter) { }

	public void SetMoveAvatarData(string moveAvatarGuid, MPAvatarData avatarData) { }

	public void SetPlayers(HashSet<Int32> players) { }

	public void SetPlayerScene(int uid, string sceneId) { }

	public void SetPlayerSpineDataForPicture(int playerUID, AvatarSpineData avatarSpineData) { }

	public void SetPlayersSceneInScenes(Dictionary<Int32, String> playersInScenes) { }

	public bool ShouldFixAvatarIdForHostData(int id) { }

	public static bool ShouldSendGameplayEvents() { }

	private void SyncIsSharingSceneWithOtherPlayers() { }

	private void TryBroadcastMessage(MPDataBase data) { }

	public bool TrySaveCurrentSceneAndGetSceneData(out MPSceneData sceneData) { }

	public void WaitForNetworkEvent(MPDataType dataType) { }

	public void WaitForPlayer(int playerUID) { }

	[IteratorStateMachine(typeof(<WaitingForPlayers>d__89))]
	private IEnumerator WaitingForPlayers() { }

}

