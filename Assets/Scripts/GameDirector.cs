using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance => m_instance;
    private static GameDirector m_instance;

    [SerializeField] PlayerController m_player;

    [Space(10.0f)]
    public const string HIGH_SCORE = "HIGH SCORE";
    public const string SCORE = "SCORE";
    [SerializeField] int m_highScore = 0;
    [SerializeField] int m_score = 0;

    [Space(10.0f)]
    [SerializeField] Text m_highScoreText;
    [SerializeField] Text m_scoreText;

    void Start()
    {
        if (m_instance == null) { m_instance = this; }

        m_highScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);

        if (m_player == null) { m_player = PlayerController.Instance; }
    }

    void Update()
    {
        if (m_player.NowStat.HP <= 0) { GameEnd(); }

        if (m_score >= m_highScore) { m_highScore = m_score; }

        m_highScoreText.text = $"HIGH SCORE {m_highScore:D10}";
        m_scoreText.text = $"SCORE {m_score:D10}";
    }

    private void FixedUpdate()
    {
        m_score++;
    }

    public void AddScore(int score) { this.m_score += score; }

    void GameEnd()
    {
        PlayerPrefs.SetInt(HIGH_SCORE, m_highScore);
        PlayerPrefs.SetInt(SCORE, m_score);

        SceneManager.LoadScene("EndScene");
    }
}
