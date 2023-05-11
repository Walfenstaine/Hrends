using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPK : MonoBehaviour
{
    public Muwer muwer;

    private void Start()
    {
        muwer = Muwer.regit;
    }
    void Update()
    {
        if (muwer != null)
        {
            muwer.muve = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }
}
