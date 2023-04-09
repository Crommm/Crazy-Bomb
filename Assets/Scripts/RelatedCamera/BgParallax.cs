using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgParallax : MonoBehaviour
{
    private Material mat;
    private float offset;
    [SerializeField] float speed;

    [SerializeField] bool isHorizontal;
    private void Awake()
    {
        mat = GetComponent<Renderer>().material;

    }

    void Update()
    {
        offset = Time.time * speed;

        if (isHorizontal)
        {
            MoveOffsetX();
        }
        else
        {
            MoveOffsetY();
        }
      
    }

    void MoveOffsetX()
    {
        mat.mainTextureOffset = new Vector2(offset, 0);
    }
  
    void MoveOffsetY()
    {
        mat.mainTextureOffset = new Vector2(0, offset);
    }

}























//public class BackGroundScroller : MonoBehaviour
//{

//    [SerializeField] float backGroundScrollSpeed = 0.5f;
//    Material myMaterial;

//    Vector2 offset;

//    private void Start()
//    {
//        myMaterial = GetComponent<Renderer>().material;
//        offset = new Vector2(0f, backGroundScrollSpeed);
//    }

//    private void Update()
//    {
//        myMaterial.mainTextureOffset += offset * Time.deltaTime;
//    }


//}