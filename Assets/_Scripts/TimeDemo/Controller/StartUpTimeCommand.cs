using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpTimeCommand : PureMVC.Patterns.SimpleCommand
{

    public override void Execute(INotification notification)
    {

        //create ui
        GameObject obj = GameObjectUtility.Instance.CreateGameObject("_Prefabs/TimePanelView");
        //bind mediator
        Facade.RegisterMediator(new TimePanelMediator(obj));

        SendNotification(TimeFacade.REFRESH_BONUS_UI);
    }
}
