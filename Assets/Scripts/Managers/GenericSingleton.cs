using UnityEngine;

public abstract class GenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;

    [HideInInspector]
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
            }
            if (_instance == null)
            {
                GameObject singleton = new GameObject();
                _instance = singleton.AddComponent<T>();
                singleton.name = "(singleton) " + typeof(T);
                DontDestroyOnLoad(singleton);
                Debug.Log(singleton + "was created with DontDestroyOnLoad.");
            }
            return _instance;
        }
    }
    protected virtual void OnAwake()
    {

    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        OnAwake();
    }
}