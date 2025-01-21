using UnityEngine;
using TMPro;

public class Main : MonoBehaviour
{
    public TextMeshProUGUI display_player_name;

    public void Awake()
    {
        display_player_name.text = $"Best Score : {Start.start.player_name} : 0";
    }
}
