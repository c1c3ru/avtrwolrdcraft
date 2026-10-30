namespace Spine.Unity;

public class NoOpTextureLoader : TextureLoader
{

	public NoOpTextureLoader() { }

	public override void Load(AtlasPage page, string path) { }

	public override void Unload(object texture) { }

}

