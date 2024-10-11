using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家回合
public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        Debug.Log("玩家回合");
        UIManager.Instance.ShowTip("玩家回合", Color.green, delegate ()
          {
              //回复行动力
              FightManager.Instance.CurPowerCount = 3;
              UIManager.Instance.GetUI<FightUI>("FightUI").UpdatePower();


              //卡牌已经没有卡 重新初始化
              if (FightCardManager.Instance.HasCard()==false)
              {
                  FightCardManager.Instance.Init();
                  //更新弃卡堆数量
                  UIManager.Instance.GetUI<FightUI>("FightUI").UpdateUsedCardCount();
              }

              //抽卡
              Debug.Log("chouka1");
              UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(4);//抽四张卡
              UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();

              //更新卡牌数
              UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardCount();
          });
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
