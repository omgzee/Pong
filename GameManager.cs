using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int scorePlayer1,scorePlayer2;
    public ScoreText scoreTextleft, scoreTextright;
    public System.Action onReset;

    public void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void OnScoreZoneReached(int id)
    {
        onReset?.Invoke();
        if (id == 1)
        {
            scorePlayer1++;
        }
        if (id == 2)
        {
            scorePlayer2++;
            
        }
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreTextleft.SetScore(scorePlayer1);
        scoreTextright.SetScore(scorePlayer2);
    }
}
