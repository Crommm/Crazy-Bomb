using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public static EffectController instance;

    [SerializeField] GameObject coinEffect;
    [SerializeField] GameObject deadEffect;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void CoinEffect(Vector3 position)
    {
        Instantiate(coinEffect, position, Quaternion.identity);

    }
    public void DeadEffect(Vector3 position)
    {
        Instantiate(deadEffect, position, Quaternion.identity);

    }
}
