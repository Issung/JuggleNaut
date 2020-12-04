// Taken from http://redframe-game.com/blog/global-managers-with-generic-singletons/

using UnityEngine;

/* 
 * This class is a Singleton GameObject that will be lazily initialized when it is referenced for the first time.
 * It derives from MonoBehaviour allowing for all of the usual Unity systems to be used.
 * The GameObject is persistent and will not be destroyed when a new scene is loaded.
 * 
 * See the link above for more information and an explanation.
 * 
 * NOTE: A subclasses must pass in its own Type as the T parameter, this is so the singleton
 * can typecast the instance member variable to the corrent class.
 */

public class UnitySingletonPersistent<T> : MonoBehaviour where T : Component
{
    protected static T m_instance;

    public static bool InstanceExists() => m_instance != null;

    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<T>();

                if (m_instance == null)
                {
                    GameObject obj = new GameObject();
                    //obj.hideFlags = HideFlags.HideAndDontSave;
                    m_instance = obj.AddComponent<T>();
                    obj.name = m_instance.GetType().ToString();
                }
            }

            return m_instance;
        }
    }

    public virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (m_instance == null)
            m_instance = this as T;
        else
            Destroy(gameObject);
    }
}