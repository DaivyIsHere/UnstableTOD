using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    [SerializeField] private float _displaySpeed = 1f;
    [SerializeField] private Text _bestDraw;
    [SerializeField] private Text _bestTime;
    [SerializeField] private Text _yourDraw;
    [SerializeField] private Text _yourTime;

    private void Awake()
    {
        StartCoroutine(DisplayScore());
        UpdateBest();
    }

    private void UpdateBest()
    {
        if (GameRecord.Draw > PlayerPrefs.GetInt("BestDraw"))
        {
            PlayerPrefs.SetInt("BestDraw", GameRecord.Draw);
            PlayerPrefs.SetFloat("BestTime", GameRecord.Time);
        }
        if (GameRecord.Draw == PlayerPrefs.GetInt("BestDraw"))
        {
            if (GameRecord.Time < PlayerPrefs.GetFloat("BestTime"))
            {
                PlayerPrefs.SetInt("BestDraw", GameRecord.Draw);
                PlayerPrefs.SetFloat("BestTime", GameRecord.Time);
            }
        }
    }

    private IEnumerator DisplayScore()
    {
        _bestDraw.text = PlayerPrefs.GetInt("BestDraw").ToString();
        _bestTime.text = ConvertTime(PlayerPrefs.GetFloat("BestTime"));

        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime * _displaySpeed;
            int draw = Mathf.RoundToInt(Mathf.Lerp(0, GameRecord.Draw, t));
            float time = Mathf.Lerp(0, GameRecord.Time, t);

            _yourDraw.text = draw.ToString();
            _yourTime.text = ConvertTime(time);

            yield return null;
        }
    }

    private string ConvertTime(float time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60);

        string stringM = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
        string stringS = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();

        return stringM + ":" + stringS;
    }
}
