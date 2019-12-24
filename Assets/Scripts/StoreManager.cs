using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Advertisements;
using System;

public class StoreManager : MonoBehaviour {

    public Transform[] storePanelButtons;
    public TextMeshProUGUI[] itemCostText;
    public int[] itemCost;
    public TextMeshProUGUI[] itemsButtonText;

    public Button getMoreTokens;
    public TextMeshProUGUI minutesToText;
    public GameObject minutesTo;

    private bool[] isSkinBought;
    private bool[] resetIsSkinBought;
    public LevelManager levelManager;
    public TextMeshProUGUI tokensCollectedText;
    public TextMeshProUGUI inStockDoubleTapText;

    private int tokensCollected;
    private int inStockDoubleTap;
    private int inStockSecondChance;
    private int selectedSkin;

    DateTime currentDate;
    DateTime oldDate;
    TimeSpan difference;

    private void Start() {
        InitStore();
        //buyTokens.SetActive(false);
        resetIsSkinBought = new bool[] { true, false, false, false}; // this one will be used to reset if items are bought or not

        isSkinBought = new bool[itemsButtonText.Length];

        tokensCollected = ((int)PlayerPrefsManager.GetComulativeTokens());
        tokensCollectedText.text = tokensCollected.ToString();

        inStockDoubleTap = ((int)PlayerPrefsManager.GetDoubleTap());
        inStockDoubleTapText.text = inStockDoubleTap.ToString();

        inStockSecondChance = ((int)PlayerPrefsManager.GetSecondChance());
        //inStockSecondChanceText.text = inStockSecondChance.ToString();

        #region SetUpButtonLabels
        if (!PlayerPrefs.HasKey("items_bought")) {
            PlayerPrefsManager.SetIsItemBought(resetIsSkinBought);
        }
        isSkinBought = PlayerPrefsManager.GetIsItemBought();
        selectedSkin = PlayerPrefsManager.GetSelectedSkin();

        if (isSkinBought[selectedSkin]) {
            itemsButtonText[selectedSkin].text = "Current";
        }
        for (int i = 0; i <= 3; i++) {
            if (i != selectedSkin && isSkinBought[i]) {
                itemsButtonText[i].text = "Use";
            }
            else if (!isSkinBought[i]) {
                itemsButtonText[i].text = "Buy";
            }
        }
        #endregion

        // set the cost value on the editor
        if (itemCostText.Length == itemCost.Length) {
            for (int i = 0; i < itemCostText.Length; i++) {
                itemCostText[i].text = itemCost[i].ToString();
            }
        }
        else 
            Debug.Log("Item Cost Text variables are not same length as the values asigned for them!!");
    }

    private void Update() {
        currentDate = System.DateTime.Now;
        long temp = Convert.ToInt64(PlayerPrefsManager.GetTimeFreeTokensUsed());
        oldDate = DateTime.FromBinary(temp);
        difference = currentDate.Subtract(oldDate);

        int minutes = 10 - (int)difference.TotalMinutes;
        if (minutes < 0) {
            minutes = 0;
        }
        minutesToText.text = minutes.ToString();

        if (difference.TotalMinutes > 10) {
            getMoreTokens.interactable = true;
            minutesTo.SetActive(false);
        }
        else { 
            getMoreTokens.interactable = false;
            minutesTo.SetActive(true);
        }
    }

    private void InitStore() {
        if (storePanelButtons == null)
            Debug.Log("you did not asigne items in panel");

        //foreach button will add onClick
        int i = 0;
        foreach (Transform t in storePanelButtons) {
            int currrentIndex = i;
            Button button = t.GetComponent<Button>();
            button.onClick.AddListener(() => OnItemSelected(currrentIndex));
            i++;
        }
        i = 0;
    }

    private void OnItemSelected(int currrentIndex) {
        //Debug.Log("Selecting item from the store: " + currrentIndex);
        if (currrentIndex >= 0 && currrentIndex <= 3) {
            if (!isSkinBought[currrentIndex] && tokensCollected >= itemCost[currrentIndex]) {
                isSkinBought[currrentIndex] = true;
                BuyItem(currrentIndex);
                SelectSkin(currrentIndex);
            }
            //else if (tokensCollected <= itemCost[currrentIndex])
            //    buyTokens.SetActive(true);
            else if (isSkinBought[currrentIndex]) 
                SelectSkin(currrentIndex);
        }

        else if (currrentIndex == 4 && tokensCollected >= itemCost[currrentIndex]) {
            BuyItem(currrentIndex);
            inStockDoubleTap++;
            inStockDoubleTapText.text = inStockDoubleTap.ToString();
        }
        else if (currrentIndex == 5 && tokensCollected >= itemCost[currrentIndex]) {
            BuyItem(currrentIndex);
            inStockSecondChance++;
            //inStockSecondChanceText.text = inStockSecondChance.ToString();
        }

        //if (tokensCollected < itemCost[currrentIndex]) {
        //    buyTokens.SetActive(true);
        //}
    }

    public void GetMoreTokens() {
        if (difference.TotalMinutes > 10) {
            //ShowOptions so = new ShowOptions();
            //so.resultCallback = RequestMoreTokens;
            //Advertisement.Show("rewardedVideo", so);
            //PlayerPrefsManager.SetTimeFreeTokensUsed(DateTime.Now.ToBinary().ToString());
        }
    }

    // public void RequestMoreTokens(ShowResult showResult) {
    //     if (showResult == ShowResult.Finished) {
    //         PlayerPrefsManager.SetComulativeTokens(PlayerPrefsManager.GetComulativeTokens() + 100);
    //         tokensCollected = PlayerPrefsManager.GetComulativeTokens();
    //         tokensCollectedText.text = PlayerPrefsManager.GetComulativeTokens().ToString();
    //     }
    // }

    private void SelectSkin(int currrentIndex) {
        selectedSkin = currrentIndex;
        if (isSkinBought[selectedSkin]) {
            itemsButtonText[selectedSkin].text = "Current";
        }
        for (int i = 0; i < 4; i++) {
            if (i != selectedSkin) {
                itemsButtonText[i].text = "Use";
            }
            for (int j = 0; j < 4; j++) {
                if (j != selectedSkin && isSkinBought[j]) {
                    itemsButtonText[j].text = "Use";
                }
                else if (!isSkinBought[j]) {
                    itemsButtonText[j].text = "Buy";
                }
            }
        }
    }

    private void BuyItem(int currrentIndex) {
        tokensCollected -= itemCost[currrentIndex];
        tokensCollectedText.text = tokensCollected.ToString();
    }

    public void SaveAndExit() {
        PlayerPrefsManager.SetComulativeTokens(tokensCollected);
        PlayerPrefsManager.SetDoubleTap(inStockDoubleTap);
        PlayerPrefsManager.SetSecondChance(inStockSecondChance);
        PlayerPrefsManager.SetSelectedSkin(selectedSkin);
        PlayerPrefsManager.SetIsItemBought(isSkinBought); // use a as parameter insted of isSkinBought to reset if item is bought
        levelManager.LoadLevel("01a Menu");
    }
}
