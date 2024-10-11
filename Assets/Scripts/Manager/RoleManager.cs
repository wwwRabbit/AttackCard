using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用户信息管理器，管理拥有的卡牌金币等信息
public class RoleManager
{
    public static RoleManager Instance = new RoleManager();

    public List<string> cardList;//存储拥有的卡牌id

    public void Init()
    {
        cardList = new List<string>();
        //四张攻击卡 四张防御 四张效果
        cardList.Add("1000"); cardList.Add("1000"); cardList.Add("1000"); cardList.Add("1000");

        cardList.Add("1001"); cardList.Add("1001"); cardList.Add("1001"); cardList.Add("1001");

        cardList.Add("1002"); cardList.Add("1002");
    }
}
