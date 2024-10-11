using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//防御卡（加盾）
public class DefendCard : CardItem
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (TryUse()==true)
        {
            //使用效果
            int val = int.Parse(data["Arg0"]);

            //播放使用后的声音
            AudioManager.Instance.PlayEffect("Effect/healspell");//字段可以配置表中，忘了

            //增加防御力
            FightManager.Instance.DefenseCount += val;
            //刷新防御文本
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateDefense();

            Vector3 pos = Camera.main.transform.position;
            pos.y = 0;
            PlayEffect(pos);

        }
        else
        {
            base.OnEndDrag(eventData);
        }
    }
}
