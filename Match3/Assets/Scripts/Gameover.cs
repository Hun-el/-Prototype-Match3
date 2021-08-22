using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public Text scoreText;
    public int scorePoints;
    public float Displayscore;

    private void Start() {
        Board board = FindObjectOfType<Board>();
        board.currentState = Board.boardState.end;
    }

    void Update()
    {
        Displayscore = Mathf.Lerp(Displayscore , scorePoints , 5*Time.deltaTime);
        scoreText.text = "SCORE\n"+Displayscore.ToString("0");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
