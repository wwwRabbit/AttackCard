using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//声音管理器
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource bgmSource;//播放bgm的音频

    private void Awake()
    {
        Instance = this;

    }

    //初始化
    public void Init()
    {
       bgmSource= gameObject.AddComponent<AudioSource>();
    }

    //播放BGM
    public void PlayBGM(string name,bool isloop=true)
    {
        //加载BGM的声音
        AudioClip clip= Resources.Load<AudioClip>("Sounds/BGM/" + name);

        //Debug.Log(clip); 
        
        bgmSource.clip = clip;//音频设置

        bgmSource.loop = isloop;

        bgmSource.Play();
       // Debug.Log("1111111111");

    }

    public void PlayEffect(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/" + name);

        AudioSource.PlayClipAtPoint(clip, transform.position);//播放
    }

}
