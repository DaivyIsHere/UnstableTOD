using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public void ExitGame() => Application.Quit();

    public void ToMenuScene() => SceneManager.LoadScene(0);

    public void ToPlayScene() => SceneManager.LoadScene(1);
}
