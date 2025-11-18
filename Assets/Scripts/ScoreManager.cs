using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public  int Score { get; private set; }
    public void Increase()
    {
        Score++;
    }
}
