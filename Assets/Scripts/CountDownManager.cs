using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CountDownManager : MonoBehaviour
{

    [SerializeField] GameObject timeIsUpPanel;
    [SerializeField] TextMeshProUGUI countDownText;
    [SerializeField] int time;

    void Start()
    {
        timeIsUpPanel.SetActive(false);
        StartCoroutine(CountDown());
    }

    void Update()
    {
        IsTimeUp();
    }

    IEnumerator CountDown()
    {
        while (time >= 0)
        {
            countDownText.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time--;
        }
    }

    void IsTimeUp()
    {
        if (time <= 0)
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        timeIsUpPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void ReturnMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
