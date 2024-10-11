using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCardManager 
{
    //战斗卡牌模拟器
    public static FightCardManager Instance = new FightCardManager();

    public List<string> cardList;//卡堆集合

    public List<string> usedCardList;

    //初始化
    public void Init()
    {
        cardList = new List<string>();
        usedCardList = new List<string>();

        //定义临时集合
        List<string> tempList = new List<string>();
        //将玩家卡牌存储到临时集合里
        tempList.AddRange(RoleManager.Instance.cardList);

        while (tempList.Count>0)
        {
            //随机下标
            int tempIndex = Random.Range(0, tempList.Count);

            //添加到卡堆
            cardList.Add(tempList[tempIndex]);

            //临时集合删除
            tempList.RemoveAt(tempIndex);

        }

        Debug.Log(cardList.Count);

    }

    //是否有卡
    public bool HasCard()
    {
        return cardList.Count > 0;
    }

    //抽卡
    public string DrawCard()
    {
        string id= cardList[cardList.Count - 1];
        cardList.RemoveAt(cardList.Count - 1);

        return id;
    }

}
