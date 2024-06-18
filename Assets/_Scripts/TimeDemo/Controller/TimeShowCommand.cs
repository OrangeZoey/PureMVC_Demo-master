using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShowCommand : PureMVC.Patterns.SimpleCommand
{

    public override void Execute(INotification notification)
    {
      
        //获取当前时间
        TimeDataProxy timeData = Facade.RetrieveProxy(TimeDataProxy.NAME) as TimeDataProxy;
        if (timeData != null)
        {
            timeData.GetNowTime();
            Debug.Log("================TimeShowCommand");
        }


    }
}
