using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    void Start()
    {
        CreateMesh();
        StartCoroutine(SearchForPlayer());
    }

    IEnumerator SearchForPlayer()
    {
        while (true)
        {
            CheckFieldOfView();
            ReCreateMesh();
            yield return new WaitForSeconds(.2f);

        }
    }

    void CreateMesh()
    {

    }

    void CheckFieldOfView()
    {

    }

    void ReCreateMesh()
    {

    }
}
