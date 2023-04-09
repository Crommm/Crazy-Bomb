using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public bool finishGame=false;
    public bool FinishGame { get { return finishGame; } set { finishGame = value; } }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            finishGame = true;
            UIFade.Instance.FadeToBlack();
            StartCoroutine(OpenFinishPanelRoutine());
        }
    }
    IEnumerator OpenFinishPanelRoutine()
    {
        yield return new WaitForSeconds(1f);
        UIController.Instance.OpenFinishPanel();
    }
}
