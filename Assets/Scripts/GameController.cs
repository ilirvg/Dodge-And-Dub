using UnityEngine;

public class GameController : MonoBehaviour {

    private static GameController _instance;
    public static GameController Instance {
        get {
            if (_instance == null) {
                GameObject gameController = new GameObject("GameController");
                gameController.AddComponent<GameController>();
            }
            return _instance;
        }
    }

    public bool AreExtraCoinsSpawned { get; set; }
    public bool IsGameON { get; set; }
    public bool IsGameInLevels { get; set; }
    public bool IsLevelCompleated { get; set; }
    public bool AreLevelGoalsShown { get; set; }
    public bool IsSpaceHoleShowed { get; set; }
    public bool ClearPathEffect { get; set; }
    public bool IsClearPathEffectOn { get; set; }
    public bool IsPlayerInPortal { get; set; }
    public bool InstructionsOn { get; set; }
    public bool ExitStartPath { get; set; }
    public bool IsPlayerMoving { get; set; }
    public int Token { get; set; }
    public int CameraHeightInHill { get; set; }
    public float PlayerMovementSpeed { get; set; }
    public float Score { get; set; }
    public Material ObsMaterial { get; set; }
    public Material ObsHideMaterial { get; set; }
    public Material TileMaterial { get; set; }

    void Awake() {
        _instance = this;
        IsGameON = true;
        ExitStartPath = false;
        IsLevelCompleated = false;
        AreLevelGoalsShown = false;
        IsSpaceHoleShowed = false;
        ClearPathEffect = false;
        IsClearPathEffectOn = false;
        IsPlayerInPortal = false;
        InstructionsOn = false;
        IsPlayerMoving = false;
    }

}
