using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private float _fadeSpeed = 3f;
    [SerializeField] private Image _panel;

    [SerializeField] private Color32 _black;
    [SerializeField] private Color32 _clear;

    private void Awake() => StartCoroutine(FadeIn());

    public void LoadScene(int index) => StartCoroutine(FadeOut(index));

    public void ExitGame() => Application.Quit();

    private IEnumerator FadeIn()
    {
        float time = 0f;
        while (time < 1)
        {
            time += Time.deltaTime * _fadeSpeed;
            _panel.color = Color32.Lerp(_black, _clear, time);
            yield return null;
        }
    }

    private IEnumerator FadeOut(int index)
    {
        float time = 0f;
        while (time < 1)
        {
            time += Time.deltaTime * _fadeSpeed;
            _panel.color = Color32.Lerp(_clear, _black, time);
            yield return null;
        }
        SceneManager.LoadScene(index);
    }
}
