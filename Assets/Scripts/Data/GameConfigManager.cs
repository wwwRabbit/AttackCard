using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//整个游戏配置表的管理
public class GameConfigManager
{
    public static GameConfigManager Instance = new GameConfigManager();

    private GameComfigData cardData;//卡牌表

    private GameComfigData enemyData;//敌人表

    private GameComfigData levelData;//关卡表

    private GameComfigData cardTypeData;//卡牌類型表

    private TextAsset textAsset;

    //初始化配置文件 txt文件存储到内存中
    public void Init()
    {
        textAsset = Resources.Load<TextAsset>("Data/card");
        cardData = new GameComfigData(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Data/enemy");
        enemyData = new GameComfigData(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Data/level");
        levelData = new GameComfigData(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Data/cardType");
        cardTypeData = new GameComfigData(textAsset.text);
    }

    public List<Dictionary<string,string>> GetCardLines()
    {
        return cardData.Getlines();
    }

    public List<Dictionary<string, string>> GetEnemyLines()
    {
        return enemyData.Getlines();
    }
    public List<Dictionary<string, string>> GetLevelLines()
    {
        return levelData.Getlines();
    }
    public Dictionary<string,string> GetCardById(string id)
    {
        return cardData.GetOneById(id);
    }
    public Dictionary<string, string> GetEnemyById(string id)
    {
        return enemyData.GetOneById(id);
    }
    public Dictionary<string, string> GetLevelById(string id)
    {
        return levelData.GetOneById(id);
    }

    public Dictionary<string,string> GetCardTypeById(string id)
    {
        return cardTypeData.GetOneById(id);
    }

}
