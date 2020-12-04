using UnityEngine;

public static class AudioClipExtensions
{
    public static string ToStringEx(this AudioClip clip, float startTime) => $"{clip.name} ({clip.length - (Time.time - startTime):N1})";
}