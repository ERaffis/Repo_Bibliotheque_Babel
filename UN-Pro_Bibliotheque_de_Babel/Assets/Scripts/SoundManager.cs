using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
   
    public enum Sound
    {
        TypeWriter,
        PlayerMove,
        PlayerAttack,
        EnemyHit,
        EnemyDie,
        PlayerDie,
        PlayerHit,
    }

    private static Dictionary<Sound, float> soundTimerDictionnary;

    public static void Initialize()
    {
        soundTimerDictionnary = new Dictionary<Sound, float>();
        soundTimerDictionnary[Sound.PlayerMove] = 0f;
    }

    public static void PlaySound(Sound sound, Vector3 position)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();
        }
    }

    public static void PlaySound(Sound sound)
    {
        if(CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(GetAudioClip(sound));
        }
    }

    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default:
                return true;

            case Sound.PlayerMove:
                if (soundTimerDictionnary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionnary[sound];
                    float playerMoveTimerMax = 0.05f;
                    if(lastTimePlayed + playerMoveTimerMax < Time.time)
                    {
                        soundTimerDictionnary[sound] = Time.time;
                        return true;
                    } else
                    {
                        return false;
                    }
                } else
                {
                    return false;
                }
            //break;
        }
    }


    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach(GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
}
