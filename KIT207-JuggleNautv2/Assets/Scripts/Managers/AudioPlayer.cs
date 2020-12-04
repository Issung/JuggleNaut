using System;
using System.Collections;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [ShowOnly]
    public AudioSource audioSource;

    [ShowOnly]
    public AudioClip current;

    public float LastPlay { get; private set; }

    public float TimeLeft => current?.length - (Time.time - LastPlay) ?? -1f;

    private float m_volume;
    private float m_pitch;

    public void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        LastPlay = 0f;
    }

    private IEnumerator PlayAndWait0(AudioClip clip)
    {
        audioSource.PlayOneShot(current = clip);
        yield return new WaitForSecondsRealtime(clip.length);
    }

    private IEnumerator PlayAndWait0(AudioClip clip, Action post)
    {
        audioSource.PlayOneShot(current = clip);
        yield return new WaitForSecondsRealtime(clip.length);
        post?.Invoke();
    }

    public void PlayAndWait(AudioClip clip) => StartCoroutine(PlayAndWait0(clip));

    public void PlayAndWait(AudioClip clip, Action post) => StartCoroutine(PlayAndWait0(clip, post));

    public void Play(AudioClip clip, float volume = 1f, float pitch = 1f)
    {
        LastPlay = Time.time;
        Track(volume, pitch);
        audioSource.PlayOneShot(current = clip);
        //Reset();
    }

    private void TrackVolume(float volume)
    {
        m_volume = audioSource.volume;
        audioSource.volume = volume;
    }

    private void ResetVolume() => audioSource.volume = m_volume;

    private void TrackPicth(float pitch)
    {
        m_pitch = audioSource.pitch;
        audioSource.pitch = pitch;
    }

    private void ResetPicth() => audioSource.pitch = m_pitch;

    private void Track(float volume, float pitch)
    {
        TrackVolume(volume);
        TrackPicth(pitch);
    }

    private void Reset()
    {
        ResetVolume();
        ResetPicth();
    }

    public override string ToString() => $"{audioSource?.name} ({TimeLeft}s left)";
}