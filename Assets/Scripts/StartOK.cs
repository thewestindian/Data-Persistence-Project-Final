using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartOK : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
public static StartOK startOK;
public TMP_InputField inputfield;
public string player_name;

private void Awake()
    {
        if (startOK == null)
        {
        startOK = this;
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
