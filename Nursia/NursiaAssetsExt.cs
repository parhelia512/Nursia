using AssetManagementBase;
using Nursia.Rendering;

namespace Nursia
{
	public static class NursiaAssetsExt
	{
		private readonly static AssetLoader<Scene> _sceneLoader = (manager, assetName, settings, tag) =>
		{
			var data = manager.ReadAsString(assetName);
			return Scene.ReadFromString(data, manager);
		};

		public static Scene LoadScene(this AssetManager assetManager,
			string path) => assetManager.UseLoader(_sceneLoader, path);
	}
}
