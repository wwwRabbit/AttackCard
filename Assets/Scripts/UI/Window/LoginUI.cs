using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//开始界面 （继承UIBase）

public class LoginUI : UIBase
{
    private void Awake()
    {
        Register("bg/startBtn").onClick = onStartGameBtn;
    }

    public void onStartGameBtn(GameObject obj,PointerEventData pData)
    {
        //关闭login界面
        Close();

        //战斗初始化
        FightManager.Instance.ChangeType(FightType.Init);

    }

}
