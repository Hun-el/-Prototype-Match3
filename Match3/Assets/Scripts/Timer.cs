using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public GameObject gameoverPrefab;
    public float time;
    bool timeisOver = false;
    Board board;

    private void Awake() {
        board = FindObjectOfType<Board>();
    }

    private void Update() {
        if(!timeisOver)
        {
            if(time > 0)
            {
                time -= Time.deltaTime;
                timeText.text = time.ToString("0");
            }
            else if(time <= 0)
            {
                if(board.currentState == Board.boardState.waiting)
                {
                    time = 0;
                    timeisOver = true;
                    GameObject g = Instantiate(gameoverPrefab);
                    Score score = FindObjectOfType<Score>();
                    g.GetComponent<Gameover>().scorePoints = score.scorePoints;
                }
            }
        }
    }
}
