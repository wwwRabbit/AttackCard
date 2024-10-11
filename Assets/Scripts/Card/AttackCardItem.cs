using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//攻击卡
public class AttackCardItem : CardItem, IPointerDownHandler
{
    public override void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public override void OnDrag(PointerEventData eventData)
    {
        
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        
    }

    //按下
    public void OnPointerDown(PointerEventData eventData)
    {
        //播放声音
        AudioManager.Instance.PlayEffect("Cards/draw");

        //显示曲线
        UIManager.Instance.ShowUI<LineUI>("LineUI");
        //设置开始的的位置
        UIManager.Instance.GetUI<LineUI>("LineUI").SetStartPos(transform.GetComponent<RectTransform>().anchoredPosition);

        //隐藏鼠标
        Cursor.visible = false;
        //关闭所有协同程序
        StopAllCoroutines();
        //启动鼠标操作协同程序
        StartCoroutine(OnMouseDownRight(eventData));
    }
    IEnumerator OnMouseDownRight(PointerEventData pData)
    {
        while (true)
        {
            //如果接下来按下鼠标 跳出循环
            if (Input.GetMouseButton(1))
            {
                break;
            }

            Vector2 pos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform.parent.GetComponent<RectTransform>(),
                pData.position,
                pData.pressEventCamera,
                out pos
                ))
            {
                //设置箭头位置
                UIManager.Instance.GetUI<LineUI>("LineUI").SetEndPos(pos);

                //进行射线检测是否碰到怪物
                CheckRayToEnemy();
            }


            yield return null;
        }
        //跳出循环后 显示鼠标
        Cursor.visible = true;

        //关闭曲线
        UIManager.Instance.CloseUI("LineUI");
    }

    Enemy hitEnemy;//射线检测敌人
    private void CheckRayToEnemy()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,10000,LayerMask.GetMask("Enemy")))
        {
            hitEnemy = hit.transform.GetComponent<Enemy>();

            hitEnemy.OnSelect();//选中

            //如果按下鼠标左键，使用攻击卡
            if (Input.GetMouseButtonDown(0))
            {
                //关闭所有协同程序
                StopAllCoroutines();

                //鼠标显示
                Cursor.visible = true;

                //关闭曲线界面
                UIManager.Instance.CloseUI("LineUI");

                if (TryUse()==true)
                {
                    //播放特效
                    PlayEffect(hitEnemy.transform.position);

                    //打击音效
                    AudioManager.Instance.PlayEffect("Effect/sword");
                    //敌人受伤
                    int val = int.Parse(data["Arg0"]);
                    hitEnemy.Hit(val);

                }
                //敌人未选中
                hitEnemy.OnUnSelect();
                //设置敌人脚本为null
                hitEnemy = null;
            }           
        }
        else
        {
            //未射到怪物
            if (hitEnemy!=null)
            {
                hitEnemy.OnUnSelect();
                hitEnemy = null;
            }
        }
    }


}
