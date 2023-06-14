using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVArea : MonoBehaviour
{
    [SerializeField] private float distance = 30f;
    [SerializeField] private float angleBound = 30f;

    private float radiansAngleBound;

    private MeshFilter meshFilter;

    void Start()
    {
        radiansAngleBound = angleBound * Mathf.Deg2Rad;
        meshFilter = GetComponent<MeshFilter>();
        CreateFOVArea();
    }

    void Update()
    {
        CreateFOVArea();
    }

    void CreateFOVArea()
    {
        meshFilter.mesh = CreateMesh(FindPoints());
    }

    private Vector3[] FindPoints()
    {
        Vector3[] pointsTemp = new Vector3[8];
        for (int i = 0; i < pointsTemp.Length; i++)
        {
            pointsTemp[i] = DoneRayCast(radiansAngleBound * (((float)i/4) - 1));
        }
        return pointsTemp;
    }

    Vector3 DoneRayCast(float angleTemp)
    {
        Vector3 rayDirection = new Vector3(Mathf.Sin(angleTemp), 0, Mathf.Cos(angleTemp));
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(rayDirection), out hit, distance))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(rayDirection)*hit.distance, Color.yellow);
            return rayDirection*hit.distance;
        }
        else
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(rayDirection) * distance, Color.yellow);
            return rayDirection*distance;
        }
    }

    Mesh CreateMesh(Vector3[] pointsTemp)
    {
        Mesh meshTemp = new Mesh
        {
            name = "FOVMesh"
        };


        meshTemp.vertices = new Vector3[pointsTemp.Length + 1];

        meshTemp.vertices[0] = Vector3.zero;
        for (int i = 1; i< meshTemp.vertices.Length; i++)
        {
            meshTemp.vertices[i] = pointsTemp[i - 1];
        }


        return meshTemp;
    }

}
