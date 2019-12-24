using UnityEngine;
using TMPro;

public class ScoresManager : MonoBehaviour {

    private int distanceValue;
    private int tokensValue;
    private int totalScoreValue;
    private int highScoreValue;

    [Header("Lose Panel")]
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI tokensText;
    public TextMeshProUGUI totalScoreText;
    public TextMeshProUGUI highScoreText;
    [Header("SecondChance Panel")]
    public TextMeshProUGUI schDistanceText;
    public TextMeshProUGUI schTokensText;
    public TextMeshProUGUI schTotalScoreText;
    public TextMeshProUGUI schHighScoreText;

    public void ShowScore() {
        distanceValue = ((int)PlayerPrefsManager.GetLastScore());
        distanceText.text = distanceValue.ToString();
        schDistanceText.text = distanceValue.ToString();

        tokensValue = PlayerPrefsManager.GetLastTokensScore();
        tokensText.text = tokensValue.ToString();
        schTokensText.text = tokensValue.ToString();

        totalScoreValue = distanceValue + (tokensValue * 10);
        totalScoreText.text = totalScoreValue.ToString();
        schTotalScoreText.text = totalScoreValue.ToString();

        highScoreValue = ((int)PlayerPrefsManager.GetHighScore());
        highScoreText.text = highScoreValue.ToString();
        schHighScoreText.text = highScoreValue.ToString();
    }

    public void SetScore() {
        PlayerPrefsManager.SetLastScore(GameController.Instance.Score);
        PlayerPrefsManager.SetLastTokensScore(GameController.Instance.Token);
        float highscore = GameController.Instance.Score + (PlayerPrefsManager.GetLastTokensScore() * 10);
        PlayerPrefsManager.SetHighScore(highscore);

        int comulativeTokens = PlayerPrefsManager.GetComulativeTokens() + GameController.Instance.Token;
        PlayerPrefsManager.SetComulativeTokens(comulativeTokens);
    }
}
