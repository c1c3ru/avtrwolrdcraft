namespace UnityEngine.Purchasing.Extension;

public abstract class AbstractPurchasingModule : IPurchasingModule
{
	protected IPurchasingBinder m_Binder; //Field offset: 0x10

	protected AbstractPurchasingModule() { }

	protected void BindConfiguration(T instance) { }

	protected void BindExtension(T instance) { }

	public override void Configure(IPurchasingBinder binder) { }

	public abstract void Configure() { }

	protected void RegisterStore(string name, IStore store) { }

}

