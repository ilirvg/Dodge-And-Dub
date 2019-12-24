using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Advertisements;

public class SecondChanceMenu : MonoBehaviour {

    [Header("Score")]
    public TextMeshProUGUI scoreText;
    [Header("Items Panel")]
    public Text tokenText;
    public Text tokenNeededText;
    public Text doubleTapText;
    [Header("Second Chance Panel")]
    public GameObject secondChanceMenuUI;
    [Header("Lose Panel")]
    public GameObject losePanel;
    [Header("Connections")]
    public ScoresManager scoreManager;
    public TouchManager touchManager;
    public LevelManager levelManager;
    public Player player;
    public LevelFinishRing levelFinishRing;
    public LevelGoals levelGoals;



    private int comulativeTokens;
    private bool isSecondChanceUsed = false;
    private int secondChanceCost;
    private bool inLose = false;
    private int tokenNeeded;
    private string sceneName;
    private int doubleTap;
    private int i;

    void Start() {
        
        i = 0;
        secondChanceCost = 10;
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName != "02 Endles Game") {
            tokenNeeded = levelGoals.TokensToCompleatLevel;
            tokenNeededText.text = tokenNeeded.ToString();
        }
        comulativeTokens = PlayerPrefsManager.GetComulativeTokens();
        doubleTap = PlayerPrefsManager.GetDoubleTap();
        doubleTapText.text = ((int)doubleTap).ToString();

        //AdManager.Instance.rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
    }

    void Update () {
        tokenText.text = ((int)GameController.Instance.Token).ToString();
        if (sceneName != "02 Endles Game") {
            if (GameController.Instance.Token == tokenNeeded) {
                tokenNeededText.color = new Color32(214, 107, 20, 255);
            }
        }
        else if (sceneName == "02 Endles Game") {
            scoreText.text = ((int)GameController.Instance.Score).ToString();
            //scoreText.text = ((int)1.0f / Time.smoothDeltaTime).ToString();
        }

        if (!GameController.Instance.IsGameON && !isSecondChanceUsed && !GameController.Instance.IsLevelCompleated && !GameController.Instance.AreLevelGoalsShown && !GameController.Instance.InstructionsOn && i==0) {
            PrefabsAndScore();
            i = 1;
            secondChanceMenuUI.SetActive(true);
        }
        else if (!GameController.Instance.IsGameON && isSecondChanceUsed && !inLose && !GameController.Instance.IsGameInLevels && !GameController.Instance.InstructionsOn) {
            inLose = true;
            Destroy(player.gameObject);
            StartCoroutine(LoseWithDelay());
        }
        else if (!GameController.Instance.IsGameON && isSecondChanceUsed && GameController.Instance.IsGameInLevels && !GameController.Instance.IsLevelCompleated ) {
            levelFinishRing.unCompleateLevelUI.SetActive(true);
        }
	}

    //public void SecondChance() {
    //    ShowAd();
    //}

    //public void ShowAd() {
    //    if (AdManager.Instance.rewardBasedVideo.IsLoaded()) {
    //        AdManager.Instance.rewardBasedVideo.Show();
    //        AdManager.Instance.rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
    //    }
    //}

    //public void HandleRewardBasedVideoRewarded(object sender, Reward args) {
    //    string type = args.Type;
    //    double amount = args.Amount;

    //    isSecondChanceUsed = true;
    //    secondChanceMenuUI.SetActive(false);
    //    GameController.Instance.IsGameON = true;
    //    StartCoroutine(touchManager.SecondChance());
    //    OnDestroy();
    //}

    //public void OnDestroy() {
    //    //Un-Subscribe to Ad event once
    //    AdManager.Instance.rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
    //}

    //public void HandleRewardBasedVideoClosed(object sender, System.EventArgs args) {
    //    AdManager.Instance.RequestRewardBasedVideo();
    //}

    //commented New
    // public void RequestSecondChance(ShowResult showResult) {
    //     if (showResult == ShowResult.Finished) {
    //         isSecondChanceUsed = true;
    //         secondChanceMenuUI.SetActive(false);
    //         GameController.Instance.IsGameON = true;
    //         StartCoroutine(touchManager.SecondChance());
    //     }
    // }

    public void RequestSecondChance() {
            isSecondChanceUsed = true;
            secondChanceMenuUI.SetActive(false);
            GameController.Instance.IsGameON = true;
            StartCoroutine(touchManager.SecondChance());
    }

    public void SecondChance() {
        //ShowOptions so = new ShowOptions();
        //so.resultCallback = RequestSecondChance;
        //Advertisement.Show("rewardedVideo", so); //Comented New
        RequestSecondChance();
    }

    //UnityAds
    public void Lose(string levelToLoad) {
        //Comented New
        // AdManager.Instance.IsTimeToShowInterstitial++;
        // if (AdManager.Instance.IsTimeToShowInterstitial >= 3) {
        //     if (Advertisement.IsReady("video")) {
        //         Advertisement.Show("video");
        //         AdManager.Instance.IsTimeToShowInterstitial = 1;
        //     }
        // }
        levelManager.LoadLevel(levelToLoad);
    }

    //UnityAds
    public void LoseWithoutScore(string levelToLoad) {
        //Comented New
        // AdManager.Instance.IsTimeToShowInterstitial++;
        // if (AdManager.Instance.IsTimeToShowInterstitial >= 3) {
        //     if (Advertisement.IsReady("video")) {
        //         Advertisement.Show("video");
        //         AdManager.Instance.IsTimeToShowInterstitial = 1;
        //     }
        // }
        levelManager.LoadLevel(levelToLoad);
    }

    //UnityAds
    private IEnumerator LoseWithDelay() {
        //Comented New
        // AdManager.Instance.IsTimeToShowInterstitial++;
        // if (AdManager.Instance.IsTimeToShowInterstitial >= 3) {
        //     if (Advertisement.IsReady("video")) {
        //         Advertisement.Show("video");
        //         AdManager.Instance.IsTimeToShowInterstitial = 1;
        //     }
        // }
        PrefabsAndScore();
        yield return new WaitForSeconds(0.5f);
        losePanel.SetActive(true);
    }

    //Admob
    //public void Lose(string levelToLoad) {
    //    AdManager.Instance.IsTimeToShowInterstitial++;
    //    if (AdManager.Instance.IsTimeToShowInterstitial >= 5) {
    //        AdManager.Instance.ShowInterstitial();
    //        AdManager.Instance.RequestInterstitial();
    //        AdManager.Instance.IsTimeToShowInterstitial = 1;
    //    }
    //    levelManager.LoadLevel(levelToLoad);
    //}

    //Admob
    //public void LoseWithoutScore(string levelToLoad) {
    //    AdManager.Instance.IsTimeToShowInterstitial++;
    //    if (AdManager.Instance.IsTimeToShowInterstitial >= 5) {
    //        AdManager.Instance.ShowInterstitial();
    //        AdManager.Instance.RequestInterstitial();
    //        AdManager.Instance.IsTimeToShowInterstitial = 1;
    //    }
    //    levelManager.LoadLevel(levelToLoad);
    //}

    //Admob
    //private IEnumerator LoseWithDelay() {
    //    AdManager.Instance.IsTimeToShowInterstitial++;
    //    if (AdManager.Instance.IsTimeToShowInterstitial >= 5) { 
    //        AdManager.Instance.ShowInterstitial();
    //        AdManager.Instance.RequestInterstitial();
    //        AdManager.Instance.IsTimeToShowInterstitial = 1;
    //    }
    //    PrefabsAndScore();
    //    yield return new WaitForSeconds(0.5f);
    //    losePanel.SetActive(true);
    //}

    private void PrefabsAndScore() {
        if (sceneName == "02 Endles Game") {
            scoreManager.SetScore();
            scoreManager.ShowScore();
        }
        else {
            PlayerPrefsManager.SetLastTokensScore(GameController.Instance.Token);
            int comulativeTokens = PlayerPrefsManager.GetComulativeTokens() + GameController.Instance.Token;
            PlayerPrefsManager.SetComulativeTokens(comulativeTokens);
        }
    }

    public bool IsSecondChanceUsed {
        get { return isSecondChanceUsed; }
        set { isSecondChanceUsed = value; }
    }
}
