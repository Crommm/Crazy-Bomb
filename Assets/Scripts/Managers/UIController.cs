using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoSingleton<UIController>
{

    [SerializeField] TextMeshProUGUI fireTimerText;
    private int isRemainingTime = 10;
    private bool isCountTime;
    public bool IsCountTime { get { return isCountTime; } set { isCountTime = value; } }

    public bool isTouchWater;
   
    private int resurrectionTimer = 3;

    [SerializeField] TextMeshProUGUI resurrectionText;

    [SerializeField] GameObject finishPanel;
    [SerializeField] GameObject pausePanel;

    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        scoreText.text = "Score: ";
    }

    public void StartFireTime()//Call CoolidingBomb
    {
        StartCoroutine(CountfireTimerRoutine());

    }

    IEnumerator CountfireTimerRoutine()
    {

        while (isCountTime)
        {
            if (isTouchWater)
            {
                fireTimerText.text = "";
                break;
            }
            yield return new WaitForSeconds(1f);
            if (isRemainingTime < 10)
            {
                fireTimerText.text = "0" + isRemainingTime.ToString();
            }
            else
            {
                fireTimerText.text = isRemainingTime.ToString();
            }

            if (isRemainingTime <= 0)
            {
                isCountTime = false;
                fireTimerText.text = "";
                GameManager.Instance.IsDead = true;
                resurrectionTimer = 3;
                GameManager.Instance.DeadBomb();
            }

            isRemainingTime--;

        }
        isCountTime = false;
    }

    public int IsRemaningTimer()
    {
        return isRemainingTime = 10;
    }

    IEnumerator CountRessurectionTimer()
    {
        while (GameManager.Instance.IsDead)
        {
            yield return new WaitForSeconds(1f);

            if (resurrectionTimer <= 3)
            {
                resurrectionText.text = resurrectionTimer.ToString();
            }
            else
            {
                resurrectionText.text = resurrectionTimer.ToString();
            }

            if (resurrectionTimer<=0)
            {
                GameManager.Instance.IsDead = false;
                resurrectionText.text = "";
            }
            resurrectionTimer--;
        }
        GameManager.Instance.IsDead = false;
    }
    public int IsRessurectionTime()
    {
        return resurrectionTimer = 3;
    }
    public void StartRessurectionTimer()
    {
        StartCoroutine(CountRessurectionTimer());
    }
    public void OpenFinishPanel()
    {
       
        finishPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseFinishPanel()
    {
        finishPanel.SetActive(false);
      
    }

    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
    }

    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
    }

   public TextMeshProUGUI GetScoreText()
    {
        return scoreText;
    }

}
