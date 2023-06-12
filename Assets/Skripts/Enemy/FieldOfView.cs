using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    [SerializeField] private float distance;
    [SerializeField] private float angle;

    private MeshFilter fOVMeshFilter;




    void Start()
    {
        fOVMeshFilter = GetComponent<MeshFilter>();
        fOVMeshFilter.mesh = CreateMesh();


        //StartCoroutine(SearchForPlayer());
    }

    Mesh CreateMesh()
    {
        Mesh myMesh = new Mesh();
        myMesh.name = "LOSMesh";

        Vector3 shiftLeft = new Vector3(-Mathf.Sin(angle),0, Mathf.Cos(angle));
        Vector3 shiftRight = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));

        myMesh.vertices = new Vector3[] {
            Vector3.zero, distance*shiftLeft, distance*new Vector3(0,0,Mathf.Cos(angle)), distance*shiftRight
        };

        myMesh.triangles = new int[] {
            2,1,0,3,2,0
        };

        return myMesh;
    }



    /*    IEnumerator SearchForPlayer()
        {
            while (true)
            {
                CheckFieldOfView();
                yield return new WaitForSeconds(.2f);

            }
        }

        void CheckFieldOfView()
        {

        }*/

}
