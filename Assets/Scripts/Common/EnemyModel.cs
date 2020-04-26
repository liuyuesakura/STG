using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 小怪类型
/// </summary>
[System.Serializable]
public class EnemyModel
{
    /// <summary>
    /// prefab
    /// </summary>
    public string Prefab;
    /// <summary>
    /// 
    /// </summary>
    public List<EnemyFireModel> FireModels;
    /// <summary>
    /// 初始化位置（屏幕外
    /// </summary>
    public Vector3 InitPosition;
    /// <summary>
    /// 路径
    /// </summary>
    public List<Vector3> Destinations;
    /// <summary>
    /// 移动速度变化
    /// </summary>
    public AnimationCurve MoveSpeedCurve;
}

[System.Serializable]
public class  EnemyModel4Json
{
    public string Name => "SB_UNITY";
    public List<EnemyModel> Enemies;
}