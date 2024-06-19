using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int score = 0;
    public Text scoreText;


    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart() {

        SceneManager.LoadScene("Score");
    }

    public void ScoreUp() {
        score++;
        scoreText.text = score.ToString();
    }

    public int getScore() {
        return score;
    }
}
