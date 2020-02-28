using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;

namespace Fungus
{
    /// <summary>
    /// Displays a timer bar and executes a target block if the player fails to select a menu option in time.
    /// </summary>
    [CommandInfo("Audio", 
        "Audio Volume Change Fungus", 
        "音量を変える")]
    [AddComponentMenu("")]
    [ExecuteInEditMode]
    public class AudioVolumeChangeFungus : Command
    {
        [Tooltip("Audio Manager")] [SerializeField]
        protected AudioManager audioManager;

        [Tooltip("Target Volume")] [SerializeField]
        protected float targetVolume;

        [Tooltip("Volume Change Speed")] [SerializeField]
        protected float speed;
        public override void OnEnter()
        {
            StartCoroutine(AudioLerpCoroutine());

            Continue();
        }

        private IEnumerator AudioLerpCoroutine()
        {
            while (true)
            {
                foreach (var audioSource in audioManager.GetAudioSource)
                {
                    if (audioSource.volume > targetVolume)
                    {
                        audioSource.volume -= speed;
                        if (Mathf.Abs(audioSource.volume - targetVolume) <= speed)
                        {
                            audioSource.volume = targetVolume;
                        }
                    }
                    else if(audioSource.volume < targetVolume)
                    {
                        audioSource.volume += speed;
                        if (Mathf.Abs(audioSource.volume - targetVolume) <= speed)
                        {
                            audioSource.volume = targetVolume;
                        }
                    }
                    else
                    {
                        yield break;
                    }
                }

                yield return null;
            }
        }
        
        public override string GetSummary()
        {
            return "音量:" + targetVolume + "スピード:" + speed;
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
    }
}