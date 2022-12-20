using UnityEngine;
using UnityEngine.Serialization;

namespace GiftOrCoal.LoadSystem
{
    public sealed class SceneLoader : MonoBehaviour, ISceneLoader
    {
        [SerializeField] private SceneLoadMode _mode;
        [FormerlySerializedAs("_loadingScreen")] [SerializeField] private SceneData _loadingScene;
        private IFactory<ISceneLoader> _sceneLoaderFactory;

        private void Awake()
        {
            _sceneLoaderFactory = new SceneLoaderFactory(_mode, _loadingScene);
        }

        public void Load(SceneData sceneData)
        {
            var sceneLoader = _sceneLoaderFactory.Create();
            sceneLoader.Load(sceneData);
        }
    }
}