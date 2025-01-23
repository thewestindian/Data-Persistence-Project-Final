using UnityEngine;

public class ErasePlayerPrefs : MonoBehaviour
{
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}
