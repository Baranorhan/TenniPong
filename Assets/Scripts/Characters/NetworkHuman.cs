using System;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;

public class NetworkHuman : Character
{

    private NetChecker myNetChecker;
    protected override void Start()
    { 
        myNetChecker = GetComponent<NetChecker>();

        base.Start();

    }

    protected override void FixedUpdate()
    {
        {
            if (myNetChecker.Ismine)
            {
                base.FixedUpdate();
            }
        }
    }
}