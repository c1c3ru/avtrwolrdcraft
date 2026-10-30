//Type is in global namespace

internal class MonoBehaviourCallbackHooks : ComponentSingleton<MonoBehaviourCallbackHooks>
{
	internal Action<Single> m_OnUpdateDelegate; //Field offset: 0x20
	internal Action<Single> m_OnLateUpdateDelegate; //Field offset: 0x28

	internal event Action<Single> OnLateUpdateDelegate
	{
		internal add { } //Length: 168
		internal remove { } //Length: 168
	}

	public event Action<Single> OnUpdateDelegate
	{
		 add { } //Length: 168
		 remove { } //Length: 168
	}

	public MonoBehaviourCallbackHooks() { }

	internal void add_OnLateUpdateDelegate(Action<Single> value) { }

	public void add_OnUpdateDelegate(Action<Single> value) { }

	protected virtual string GetGameObjectName() { }

	internal void LateUpdate() { }

	internal void remove_OnLateUpdateDelegate(Action<Single> value) { }

	public void remove_OnUpdateDelegate(Action<Single> value) { }

	internal void Update() { }

}

