using UnityEngine.SceneManagement;

namespace GiftOrCoal.LoadSystem
{
    public sealed class StandardSceneLoader : ISceneLoader
    {
        public void Load(SceneData sceneData) => SceneManager.LoadSceneAsync(sceneData.Name);
    }
}