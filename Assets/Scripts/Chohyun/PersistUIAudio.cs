using UnityEngine;

public class PersistUIAudio : MonoBehaviour
{
    private static PersistUIAudio instance;

    private void Awake()
    {
        if (instance != null)
        { 
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
