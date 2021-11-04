using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObserver : Observer
{
    playerMovement pm;

    public PlayerObserver(playerMovement pm)
    {
        this.pm = pm;
    }

    public void Notify(string Message)
    {
        Debug.Log(Message);
    }



}
