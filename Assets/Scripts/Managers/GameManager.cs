using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private BombMovement bomb;
    private bool isDead;
    private int score;

    public bool IsDead { get { return isDead; } set { isDead = value; } }
    private void Awake()
    {
        base.Awake();
        bomb = FindObjectOfType<BombMovement>();
    }
   
    public void DeadBomb()
    {
        EffectController.instance.DeadEffect(bomb.gameObject.transform.position);
        bomb.gameObject.SetActive(false);
        StartCoroutine(WaitRessurectionBombRoutine());
    }

    IEnumerator WaitRessurectionBombRoutine()
    {
        UIController.Instance.IsRessurectionTime();
        UIController.Instance.StartRessurectionTimer();
        yield return new WaitForSeconds(4f);
        bomb.gameObject.SetActive(true);
    }

    public void IncreaseScore()
    {
        score++;
        UIController.Instance.GetScoreText().text = "Score: " + score.ToString();
    }
}
