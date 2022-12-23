using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GiftOrCoal.Tools
{
    public static class AudioSourceUtils
    {
        public static async UniTaskVoid DestroyOnPlayed(this AudioSource audioSource)
        {
            while (audioSource.isPlaying)
            {
                await UniTask.Yield();
            }
            
            Object.Destroy(audioSource.gameObject);
        }
    }
}