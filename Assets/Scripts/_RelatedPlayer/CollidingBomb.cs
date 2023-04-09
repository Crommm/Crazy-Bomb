using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingBomb : MonoBehaviour
{
    [SerializeField] SpriteRenderer bombspriteRenderer;
    [SerializeField] Sprite burningBombSprite, normalBombSprite;

    private UIController uIController;
    private SavingBombPosition savingBombPosition;

    private void Awake()
    {
        uIController = GameObject.FindObjectOfType<UIController>();
        savingBombPosition = GetComponent<SavingBombPosition>();
    }
    private void Start()
    {
        savingBombPosition.Load();
    }

    private void Update()
    {
        if (GameManager.Instance.IsDead)
        {
            bombspriteRenderer.sprite = normalBombSprite;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            EffectController.instance.CoinEffect(other.gameObject.transform.position);
            Destroy(other.gameObject);
            GameManager.Instance.IncreaseScore();
            SoundManager.Instance.PlayFXSound(0, 0.6f);
        }

        if (other.gameObject.CompareTag("FireObstacle"))
        {
            if (UIController.Instance.IsCountTime)
                return;
           
            bombspriteRenderer.sprite = burningBombSprite;
            uIController.IsCountTime = true;
            uIController.isTouchWater = false;
            uIController.IsRemaningTimer();
            uIController.StartFireTime();

        }

        if (other.gameObject.CompareTag("Water"))
        {
            bombspriteRenderer.sprite = normalBombSprite;
            uIController.isTouchWater = true;
          
        }

        if (other.gameObject.CompareTag("CheckPoint"))
        {
            savingBombPosition.Save();
        }

        if (other.gameObject.CompareTag("Asteroid"))
        {
            GameManager.Instance.IsDead = true;
            GameManager.Instance.DeadBomb();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.IsDead = true;
            GameManager.Instance.DeadBomb();
            Destroy(collision.gameObject);
            SoundManager.Instance.PlayFXSound(1, 0.6f);
            //EffectController.instance.DeadEffect(gameObject.transform.position);
            //gameObject.SetActive(false);
        }
    }

    
}
