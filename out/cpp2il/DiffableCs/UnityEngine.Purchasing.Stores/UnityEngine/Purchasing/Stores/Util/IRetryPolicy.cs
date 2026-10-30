namespace UnityEngine.Purchasing.Stores.Util;

[NullableContext(1)]
internal interface IRetryPolicy
{

	public void Invoke(Action<Action> actionToTry, Action onRetryAction = null) { }

}

