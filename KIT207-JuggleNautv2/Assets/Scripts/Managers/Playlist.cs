using System.Collections.Generic;
using UnityEngine;

public class Playlist
{
    private List<AudioClip> m_clips;
    public IReadOnlyList<AudioClip> Clips => m_clips;

    public AudioClip RandomClip => m_clips[Random.Range(0, m_clips.Count)];

    public Playlist(params AudioClip[] clips) => m_clips = new List<AudioClip>(clips) ?? throw new System.ArgumentNullException(nameof(clips));
}