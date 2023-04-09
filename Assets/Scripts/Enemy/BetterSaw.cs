using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class BetterSaw : MonoBehaviour
{
    GameObject[] follewedPoints;

    bool getDistanceOnce = true;

    Vector3 directionPointAndSaw;

    int distanceIndex;

    bool isMoveForward = true;

    public float speed=4f;

    public GameObject pointsCollector;
    

    void Start()
    {
        follewedPoints = new GameObject[transform.childCount];

        for (int i = 0; i < follewedPoints.Length; i++)
        {
            follewedPoints[i] = transform.GetChild(0).gameObject;

            follewedPoints[i].transform.SetParent(pointsCollector.transform);
        }
    }


    void Update()
    {
        transform.Rotate(0, 0, 4);


    }
    private void FixedUpdate()
    {
        MovePoints();
    }
    void MovePoints()
    {
        if (getDistanceOnce)
        {
            directionPointAndSaw = (follewedPoints[distanceIndex].transform.position - transform.position).normalized;
            getDistanceOnce = false;
        }
        float distance = Vector3.Distance(transform.position, follewedPoints[distanceIndex].transform.position);

        transform.position += directionPointAndSaw * Time.deltaTime * speed;

        if (distance < 0.5f)
        {
            getDistanceOnce = true;

            if (distanceIndex == follewedPoints.Length - 1)
            {
                isMoveForward = false;
            }
            else if (distanceIndex == 0)
            {
                isMoveForward = true;
            }

            if (isMoveForward)
            {
                distanceIndex++;
            }
            else
            {
                distanceIndex--;
            }
        }

    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 0.7f);
        }
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);
        }
    }

}
#if UNITY_EDITOR
[CustomEditor(typeof(BetterSaw))]
[System.Serializable]
class BetterSawEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BetterSaw betterSaw = (BetterSaw)target;
        if (GUILayout.Button("CreatePoint", GUILayout.MinWidth(150), GUILayout.Width(150)))
        {
            GameObject point = new GameObject();
            point.transform.parent = betterSaw.transform;
            point.transform.position = betterSaw.transform.position;
            point.name = betterSaw.transform.childCount.ToString();
        }
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("pointsCollector"));

        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("speed"));

        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
      
    }
    

}
#endif