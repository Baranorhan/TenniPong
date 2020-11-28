using System;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;

public class NetworkHuman : Character
{

    private NetChecker myNetChecker;
    private void Start()
    {
        myNetChecker = this.GetComponent<NetChecker>();

        base.Start();
        Debug.Log("sub class "+ CharRigid);

    }

    protected override void Update()
    {
        {
            if (myNetChecker.Ismine)
            {
                base.Update();
            }
        }
    }
}