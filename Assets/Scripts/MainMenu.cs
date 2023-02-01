using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {
    public TMP_Text title;
    public TMP_Text description;
    public GameObject mainMenuButtons;
    public GameObject gameModeDetails;
    public GameObject startButton;

    private GameModeEnum chosenGameMode;

    public void balanceModeButtonPressed() {
        chosenGameMode = GameModeEnum.BalanceMode;
        openGameDetails(new BalanceMode());
    }

    public void backButtonPressed() {
        gameModeDetails.SetActive(false);
        mainMenuButtons.SetActive(true);
        EventSystem.current.SetSelectedGameObject(startButton);
    }

    public void Start() {
        gameModeDetails.SetActive(false);
        mainMenuButtons.SetActive(true);
        EventSystem.current.SetSelectedGameObject(startButton);
    }

    public void PlayButtonPressed() {
        switch(chosenGameMode) {
            case GameModeEnum.BalanceMode:
                SceneManager.LoadScene (sceneName:"BalanceScene");
                break;
        }
    }

    // ---- Utility functions ----
    
    void openGameDetails(GameMode gameMode) {
        mainMenuButtons.SetActive(false);
        gameModeDetails.SetActive(true);
        title.text = gameMode.getName();
        description.text = gameMode.getDescription();
    }
}
