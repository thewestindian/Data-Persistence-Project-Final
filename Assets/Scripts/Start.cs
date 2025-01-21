using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
public static Start start;
public TMP_InputField inputfield;
public string player_name;

private void Awake()
    {
        if (start == null)
        {
        start = this;
        DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);   
        }

    }

public void SetPlayerName()
    {
        player_name = inputfield.text;

        SceneManager.LoadSceneAsync("main");
    }
}
