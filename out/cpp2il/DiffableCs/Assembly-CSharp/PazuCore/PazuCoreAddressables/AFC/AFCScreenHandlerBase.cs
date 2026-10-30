namespace PazuCore.PazuCoreAddressables.AFC;

public abstract class AFCScreenHandlerBase : AFCUnityMessageDrivenHandlerBase
{

	protected AFCScreenHandlerBase() { }

	public override void Apply() { }

	protected void ApplyImplement() { }

	protected override void HandleLong() { }

	protected override void HandleTablet() { }

	protected override void HandleVeryLong() { }

	public virtual void PerformAction() { }

}

