using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingBombPosition : MonoBehaviour
{
    private float bombX, bombY, bombZ;
   
    public void Save()
    {
        bombX = transform.position.x;
        bombY = transform.position.y;
        bombZ = transform.position.z;

        PlayerPrefs.SetFloat("x", bombX);
        PlayerPrefs.SetFloat("y", bombY);
        PlayerPrefs.SetFloat("z", bombZ);
    }

    public void Load()
    {
        bombX = PlayerPrefs.GetFloat("x");
        bombY = PlayerPrefs.GetFloat("y");
        bombZ = PlayerPrefs.GetFloat("z");

        Vector3 loadPosition = new Vector3(bombX, bombY, bombZ);
        transform.position = loadPosition;
    }
}
