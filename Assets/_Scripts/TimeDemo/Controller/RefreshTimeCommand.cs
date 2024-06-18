using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshTimeCommand : PureMVC.Patterns.SimpleCommand
{
    public override void Execute(INotification notification)
    {


        Debug.Log("start REFRESH_BONUS_UI");
        SendNotification(TimeFacade.REFRESH_BONUS_UI);
    }
}
