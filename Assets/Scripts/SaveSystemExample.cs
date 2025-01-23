using UnityEngine;
using TMPro;

public class SaveSystemExample : MonoBehaviour
{

    public TMP_InputField inputField;

    public void SaveData()
    {
    PlayerPrefs.SetString("Input", inputField.text);
    }

    public void LoadData()
    {
        inputField.text = PlayerPrefs.GetString("Input");
    }

}
