using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public static FinalScore Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI finalScoreText;

    public int finalScore = 0;
    void Awake()
    {
        finalScore = Score.Instance.CurrentScore;   
        //Score.Instance.ResetScore();

        if (finalScoreText != null)
        {
            finalScoreText.text = $"Final Score: {finalScore}";
        }
        
    }
}

