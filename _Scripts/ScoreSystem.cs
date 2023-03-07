using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreSystem : MonoBehaviour
{
    public int score;
    public GameEvent scored;

    public string preText; 
    public TextMeshProUGUI scoreText;

    private bool FreezeScore;

    private void Start()
    {
        ResetScore();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (FreezeScore)
            return;
        score++;
        scoreText.text = preText + score; 
        scored.Raise();
    }

    public void ResetScore()
    {
        FreezeScore = false;
        score = 0;
        scoreText.text = preText + score;
    }

    public void Freeze()
    {
        FreezeScore = true;
    }
}
