using UnityEngine;

public class ScenePersistence : MonoBehaviour
{
    public static ScenePersistence Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
