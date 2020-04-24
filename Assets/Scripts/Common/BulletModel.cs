using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子弹详细信息
/// </summary>
public class BulletModel
{
    /// <summary>
    /// 一次生成的子弹数量
    /// </summary>
    public int Count;
    /// <summary>
    /// 生存时间
    /// </summary>
    public int LifeTime => 3;
    /// <summary>
    /// 颜色
    /// </summary>
    public Color Color;
    /// <summary>
    /// 子弹速度
    /// </summary>
    public float Speed;
    /// <summary>
    /// 子弹生成到开始移动的延时
    /// </summary>
    public int DelayTime;
    /// <summary>
    /// 子弹移动方向
    /// </summary>
    public Quaternion Direction;
    /// <summary>
    /// 多发子弹之间的夹角（用于init
    /// </summary>
    public float Angle;
    /// <summary>
    /// 多发子弹之间的距离（用于init
    /// </summary>
    public float Distance;

    /// <summary>
    /// 初始位置(发射子弹的enemy的位置)
    /// </summary>
    public Vector3 InitPosition;
    /// <summary>
    /// 子弹生成时，相对InitPosition的偏移量
    /// </summary>
    public float ShiftInitPos;

    public void Set(Vector3 initPostion, Quaternion direction)
    {
        this.InitPosition = initPostion;

        //Vector3 eulerAngles = direction.eulerAngles;
        //eulerAngles.x = 0;
        //eulerAngles.y = 0;

        //eulerAngles = Vector3.zero; // (0,0,0)不旋转

        this.Direction = direction;//Quaternion.Euler(eulerAngles);
    }
}
