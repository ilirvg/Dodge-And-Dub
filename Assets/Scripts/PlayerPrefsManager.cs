using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_SOUND_KEY = "master_sound";
    const string LAST_SCORE_KEY = "last_score";
    const string HIGH_SCORE_KEY = "high_score";
    const string LAST_TOKENS_SCORE_KEY = "last_tokens_score";
    const string COMULATIVE_TOKENS_KEY = "comulative_tokens";
    const string DIFFICULTY_KEY = "difficulty";
    const string DOUBLE_TAP_KEY = "double_tap";
    const string SECOND_CHANCE_KEY = "second_chance";
    const string SKIN_SELECTED_KEY = "skin_selected";
    const string ITEMS_BOUGHT_KEY = "items_bought";
    const string LEVEL_UNLOCKED_KEY = "level_unlocked";
    const string INSTRUCTIONS_KEY = "instructions";
    const string FREE_TOKENS_TIME_KEY = "freeTokensTime";

    #region MasterSoundPrefs
    public static void SetMasterSound(int mute) {
        if (mute == 0 || mute == 1) { 
            PlayerPrefs.SetInt(MASTER_SOUND_KEY, mute);
        }
    }

    public static int GetMasterSound() {
        return PlayerPrefs.GetInt(MASTER_SOUND_KEY);
    }
    #endregion

    #region LastScorePrefs
    public static void SetLastScore(float score) {
        PlayerPrefs.SetFloat(LAST_SCORE_KEY, score);
    }
    public static float GetLastScore() {
        return PlayerPrefs.GetFloat(LAST_SCORE_KEY);
    }
    #endregion 

    #region HighScorePrefs
    public static void SetHighScore(float score) {
        if (score > GetHighScore()) {
            PlayerPrefs.SetFloat(HIGH_SCORE_KEY, score);
        }
    }
    public static float GetHighScore() {
        return PlayerPrefs.GetFloat(HIGH_SCORE_KEY);
    }
    #endregion

    #region TokensPrefs
    public static void SetLastTokensScore(int score) {
        PlayerPrefs.SetInt(LAST_TOKENS_SCORE_KEY, score);
    }
    public static int GetLastTokensScore() {
        return PlayerPrefs.GetInt(LAST_TOKENS_SCORE_KEY);
    }
    #endregion 

    #region ComulativeTokensPrefs
    public static void SetComulativeTokens(int score) {
        PlayerPrefs.SetInt(COMULATIVE_TOKENS_KEY, score);
    }
    public static int GetComulativeTokens() {
        return PlayerPrefs.GetInt(COMULATIVE_TOKENS_KEY);
    }
    #endregion

    #region DifficultyPrefs
    public static void SetDifficulty(string difficulty) {
        PlayerPrefs.SetString(DIFFICULTY_KEY, difficulty);
    }

    public static string GetDifficulty() {
        return PlayerPrefs.GetString(DIFFICULTY_KEY, "Easy");
    }
    #endregion

    #region DoubleTapPrefs
    public static void SetDoubleTap(int value) {
        PlayerPrefs.SetInt(DOUBLE_TAP_KEY, value);
    }

    public static int GetDoubleTap() {
        return PlayerPrefs.GetInt(DOUBLE_TAP_KEY, 1);
    }
    #endregion

    #region SecondChancePrefs
    public static void SetSecondChance(int value) {
        PlayerPrefs.SetInt(SECOND_CHANCE_KEY, value);
    }

    public static int GetSecondChance() {
        return PlayerPrefs.GetInt(SECOND_CHANCE_KEY);
    }
    #endregion

    #region SkinSelectedPrefs
    public static void SetSelectedSkin(int value) {
        PlayerPrefs.SetInt(SKIN_SELECTED_KEY, value);
    }

    public static int GetSelectedSkin() {
        return PlayerPrefs.GetInt(SKIN_SELECTED_KEY);
    }
    #endregion

    #region IsItemsBoughtPrefs
    public static void SetIsItemBought(bool[] isBought) {
        PlayerPrefsX.SetBoolArray(ITEMS_BOUGHT_KEY, isBought);
    }

    public static bool[] GetIsItemBought() {
        
        return PlayerPrefsX.GetBoolArray(ITEMS_BOUGHT_KEY); 
    }
    #endregion

    #region SkinSelectedPrefs
    public static void SetUnlockedLevel(int value) {
        PlayerPrefs.SetInt(LEVEL_UNLOCKED_KEY, value);
    }

    public static int GetUnlockedLevel() {
        return PlayerPrefs.GetInt(LEVEL_UNLOCKED_KEY, 1);
    }
    #endregion

    #region InstructionsPrefs
    public static void SetIfInstructionsAreShown(int value) {
        PlayerPrefs.SetInt(INSTRUCTIONS_KEY, value);
    }

    public static int GetIfInstructionsAreShown() {
        return PlayerPrefs.GetInt(INSTRUCTIONS_KEY, 0);
    }
    #endregion

    #region FreeTokensTimePrefs
    public static void SetTimeFreeTokensUsed(string time) {
        PlayerPrefs.SetString(FREE_TOKENS_TIME_KEY, time);
    }
    public static string GetTimeFreeTokensUsed() {
        return PlayerPrefs.GetString(FREE_TOKENS_TIME_KEY, 0.ToString());
    }
    #endregion
}
