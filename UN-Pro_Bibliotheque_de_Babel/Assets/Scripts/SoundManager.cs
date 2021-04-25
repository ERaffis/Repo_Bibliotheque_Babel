using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        TypeWriter,
        TypeWriterEnd,
        PlayerMove,
        PlayerAttack,
        EnemyHit,
        EnemyDie,
        PlayerDie,
        PlayerHit1,
        PlayerHit2,
        PlayerHit3,
        PlayerHit4,
        PlayerHit5,
        PlayerHit6,
        PlayerHit7,
        PlayerHit8,
        ComboCharge,
        ButtonSelected,
        ButtonPressed,
        ItemPickedUp,
    }

    private static Dictionary<Sound, float> soundTimerDictionnary;
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;

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

            Object.Destroy(soundGameObject, audioSource.clip.length);
        }
    }

    public static void PlaySound(Sound sound)
    {
        if(CanPlaySound(sound))
        {
            if(oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("Sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            }

            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
        }
    }

    public static void PlayHurtSound()
    {
        Sound sound = Sound.PlayerHit1;
        switch (Random.Range(0,7))
        {
            case 1: 
                sound = Sound.PlayerHit1;
                break;

            case 2:
                sound = Sound.PlayerHit2;
                break;

            case 3:
                sound = Sound.PlayerHit3;
                break;

            case 4:
                sound = Sound.PlayerHit4;
                break;

            case 5:
                sound = Sound.PlayerHit5;
                break;

            case 6:
                sound = Sound.PlayerHit6;
                break;

            case 7:
                sound = Sound.PlayerHit7;
                break;

            default:
                break;
        }

        if (CanPlaySound(sound))
        {
            if (oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("Sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            }

            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
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
                    float playerMoveTimerMax = 1f;
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
