
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text HighScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    public int m_Points;
    public int highscore;
    
    private bool m_GameOver = false;

    public static MainManager Instance;

    public Text UserNameText;

    public TextMeshProUGUI display_player_name;

    
    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
        LoadData();
        
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        HighScoreText.text = $"{highscore}";
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Current Score : {m_Points}";
        
            if (m_Points > highscore)
            {
                highscore = m_Points;
                //public void Awake()
                    {
                        display_player_name.text = $"{StartOK.startOK.player_name}";
                    }
            }

            
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        SaveData();
    }


    public void SaveData()
        {
        PlayerPrefs.SetInt("Score", highscore);
        PlayerPrefs.SetString("Name", display_player_name.text);
        }

        public void LoadData()
        {
            highscore = PlayerPrefs.GetInt("Score");
            display_player_name.text = PlayerPrefs.GetString("Name");
        }
}