using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelGameObject1, levelGameObject2;
    [SerializeField] GameObject bomb;
    int level=1;

    FinishLine finishLine;
    private void Awake()
    {
        finishLine = FindObjectOfType<FinishLine>();
    }
    void Start()
    {
        level = PlayerPrefs.GetInt("Level");
        if (level==1)
        {
            PlayerPrefs.SetInt("Level,",1);
            levelGameObject1.SetActive(true);
            levelGameObject2.SetActive(false);
        }
        if (level==2)
        {
            levelGameObject1.SetActive(false);
            levelGameObject2.SetActive(true);
            UIController.Instance.CloseFinishPanel();
        }
    }

    public void OpenLevel2()
    {
        finishLine.FinishGame = false;
        UIFade.Instance.FadeToClear();
        UIController.Instance.CloseFinishPanel();
       
        levelGameObject1.SetActive(false);
        levelGameObject2.SetActive(true);
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        PlayerPrefs.DeleteKey("z");
        bomb.transform.position = new Vector3(0, 0, 0);
        PlayerPrefs.SetInt("Level", 2);


    }


}
