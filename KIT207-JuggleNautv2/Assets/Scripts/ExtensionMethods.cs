using System;
using UnityEngine;
using System.Collections;

public static class ExtensionMethods
{

    public static Coroutine DelayedInvoke(this MonoBehaviour mb, float delay, Action action)
    {
        return mb.InvokeDelay(delay, action);
    }

    public static Coroutine InvokeDelay(this MonoBehaviour mb, float delay, Action action)
    {
        return mb.StartCoroutine(ExecuteAfterTime(delay, action));
    }

    public static void Aids(this MonoBehaviour mb)
    {
        
    }

    private static IEnumerator ExecuteAfterTime(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
}

