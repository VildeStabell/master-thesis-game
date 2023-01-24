using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text description;
    public GameObject mainMenuButtons;
    public GameObject gameModeDetails;

    private GameModeEnum chosenGameMode;

    public void balanceModeButtonPressed(){
        mainMenuButtons.SetActive(false);
        gameModeDetails.SetActive(true);
        chosenGameMode = GameModeEnum.BalanceMode;
        title.text = "Balance Mode";
        description.text = "Try to keep the board steady for as long as possible.";
    }

    public void backButtonPressed() {
        gameModeDetails.SetActive(false);
        mainMenuButtons.SetActive(true);
    }

    public void Start() {
        gameModeDetails.SetActive(false);
        mainMenuButtons.SetActive(true);
    }

    public void PlayButtonPressed() {
        switch(chosenGameMode) {
            case GameModeEnum.BalanceMode:
                SceneManager.LoadScene (sceneName:"BalanceScene");
                break;
        }
    }
}
