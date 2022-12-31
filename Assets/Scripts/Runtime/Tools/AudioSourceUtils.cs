using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GiftOrCoal.Tools
{
    public static class AudioSourceUtils
    {
        public static async UniTaskVoid DestroyOnPlayed(this AudioSource audioSource)
        {
            while (audioSource != null && audioSource.isPlaying)
            {
                await UniTask.Yield();
            }
            
            if(audioSource == null)
                return;
            
            Object.Destroy(audioSource.gameObject);
        }
    }
}