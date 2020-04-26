using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyFireModel
{
    /// <summary>
    /// 子弹基本设置
    /// </summary>
    public BulletModel BulletModel;
    /// <summary>
    /// enemy init 延迟多久后发射子弹
    /// </summary>
    public float DelayTime;
    
    public float FireCD;
    /// <summary>
    /// 子弹发射次数
    /// </summary>
    public int FireLimit;
}
