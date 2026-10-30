namespace Unity.Collections;

public interface INativeDisposable : IDisposable
{

	public JobHandle Dispose(JobHandle inputDeps) { }

}

