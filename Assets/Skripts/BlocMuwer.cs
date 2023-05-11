using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BlocMuwer : MonoBehaviour
{
    public UnityEvent activate;
    public MeshRenderer mr;
    public bool greedAktive = true;
    public Interface iF;
    public Data data;
    public GameObject cube;
    public LayerMask mask;
    private void Start()
    {
        data.num = 0;
    }
    public void Bilding ()
    {
        
    }

    void Update()
    {
        mr.enabled = greedAktive;
        if (greedAktive)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.collider.gameObject.layer == 3)
                    {
                        if (data.coins >= data.cena)
                        {
                            activate.Invoke();
                            data.coins -= data.cena;
                            Vector3 cell = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z));
                            Instantiate(cube, cell, Quaternion.identity);
                        }
                        else
                        {
                            iF.AndCoins();
                        }
                    }
                }
            }
        }
    }
}
