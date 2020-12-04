using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioPlayer))]
public class AudioManager : UnitySingletonPersistent<AudioManager>
{
    [ShowOnly] public AudioPlayer player;

    #region Weather
    [ShowOnly] public AudioClip weather_rain_1;
    [ShowOnly] public AudioClip weather_rain_2;
    [ShowOnly] public AudioClip weather_rain_3;
    [ShowOnly] public AudioClip weather_rain_clearing;
    [ShowOnly] public AudioClip weather_rain_hard_1;
    [ShowOnly] public AudioClip weather_rain_hard_2;
    [ShowOnly] public AudioClip weather_rain_rain_light;

    [ShowOnly] public AudioClip weather_thunder_1;
    [ShowOnly] public AudioClip weather_thunder_2;
    [ShowOnly] public AudioClip weather_thunder_3;
    [ShowOnly] public AudioClip weather_thunder_4;
    [ShowOnly] public AudioClip weather_thunder_5;
    [ShowOnly] public AudioClip weather_thunder_6;
    #endregion

    #region Step
    [ShowOnly] public AudioClip step_grass;
    [ShowOnly] public AudioClip step_stone_1;
    [ShowOnly] public AudioClip step_stone_2;
    [ShowOnly] public AudioClip step_stone_3;
    [ShowOnly] public AudioClip step_stone_4;
    [ShowOnly] public AudioClip step_stone_5;
    [ShowOnly] public AudioClip step_stone_6;
    [ShowOnly] public AudioClip step_wood_1;
    [ShowOnly] public AudioClip step_wood_2;
    [ShowOnly] public AudioClip step_wood_3;
    [ShowOnly] public AudioClip step_wood_4;
    [ShowOnly] public AudioClip step_wood_5;
    [ShowOnly] public AudioClip step_wood_6;
    #endregion

    #region Pickup
    [ShowOnly] public AudioClip pickup_1;
    [ShowOnly] public AudioClip pickup_2;
    [ShowOnly] public AudioClip pickup_3;
    [ShowOnly] public AudioClip pickup_4;
    [ShowOnly] public AudioClip pickup_5;
    [ShowOnly] public AudioClip pickup_6;
    #endregion

    #region SFX
    [ShowOnly] public AudioClip door_open;
    [ShowOnly] public AudioClip door_close;

    [ShowOnly] public AudioClip glass_brake_1;
    [ShowOnly] public AudioClip glass_brake_2;
    [ShowOnly] public AudioClip glass_brake_3;

    #endregion

    #region Weapons
    [ShowOnly] public AudioClip gunshot;
    #endregion

    #region UI
    [ShowOnly] public AudioClip ui_confirm;
    [ShowOnly] public AudioClip ui_cancel;
    #endregion

    [ShowOnly] public Dictionary<string, AudioClip> audioClips;

    private void Start()
    {
        player = gameObject.AddComponent<AudioPlayer>();

        audioClips = new Dictionary<string, AudioClip>();
        var clips = Resources.LoadAll<AudioClip>(@"Audio\");

        for (int i = 0; i < clips.Length; i++)
            audioClips.Add(clips[i].name, clips[i]);

        #region Weather
        weather_rain_1 = audioClips["weather_rain_1"];
        weather_rain_2 = audioClips["weather_rain_2"];
        weather_rain_3 = audioClips["weather_rain_3"];
        weather_rain_clearing = audioClips["weather_rain_clearing"];
        weather_rain_hard_1 = audioClips["weather_rain_hard_1"];
        weather_rain_hard_2 = audioClips["weather_rain_hard_2"];
        weather_rain_rain_light = audioClips["weather_rain_rain_light"];

        weather_thunder_1 = audioClips["weather_thunder_1"];
        weather_thunder_2 = audioClips["weather_thunder_2"];
        weather_thunder_3 = audioClips["weather_thunder_3"];
        weather_thunder_4 = audioClips["weather_thunder_4"];
        weather_thunder_5 = audioClips["weather_thunder_5"];
        weather_thunder_6 = audioClips["weather_thunder_6"];
        #endregion

        #region Step
        step_grass = audioClips["step_grass"];
        step_stone_1 = audioClips["step_stone_1"];
        step_stone_2 = audioClips["step_stone_2"];
        step_stone_3 = audioClips["step_stone_3"];
        step_stone_4 = audioClips["step_stone_4"];
        step_stone_5 = audioClips["step_stone_5"];
        step_stone_6 = audioClips["step_stone_6"];
        step_wood_1 = audioClips["step_wood_1"];
        step_wood_2 = audioClips["step_wood_2"];
        step_wood_3 = audioClips["step_wood_3"];
        step_wood_4 = audioClips["step_wood_4"];
        step_wood_5 = audioClips["step_wood_5"];
        step_wood_6 = audioClips["step_wood_6"];
        #endregion

        #region Pickup
        pickup_1 = audioClips["pickup_1"];
        pickup_2 = audioClips["pickup_2"];
        pickup_3 = audioClips["pickup_3"];
        pickup_4 = audioClips["pickup_4"];
        pickup_5 = audioClips["pickup_5"];
        pickup_6 = audioClips["pickup_6"];
        #endregion

        #region SFX
        door_open = audioClips["door_open"];
        door_close = audioClips["door_close"];

        glass_brake_1 = audioClips["glass_brake_1"];
        glass_brake_2 = audioClips["glass_brake_2"];
        glass_brake_3 = audioClips["glass_brake_3"];
        #endregion

        #region Weapons
        gunshot = audioClips["gunshot"];
        #endregion

        #region UI
        ui_confirm = audioClips["ui_confirm"];
        ui_cancel = audioClips["ui_cancel"];
        #endregion
    }

    /*private IEnumerator PlayAndWait0(AudioClip clip)
    {
        player.audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
    }

    public void PlayAndWait(AudioClip clip) => StartCoroutine(PlayAndWait0(clip));
    public void Play(AudioClip clip) => player.audioSource.PlayOneShot(clip);*/

    // ...
}