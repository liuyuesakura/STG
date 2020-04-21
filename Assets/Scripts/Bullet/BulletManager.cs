using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 发射子弹
/// </summary>
public class BulletManager : SingleClass<BulletManager>
{

    //public static BulletManager Instance;

    //void Awake()
    //{
    //    Instance = this;
    //}

    /// <summary>
    /// 发射子弹
    /// </summary>
    /// <param name="bulletModel"></param>
    /// <param name="pool"></param>
    public void DoShoot(BulletModel bulletModel, BasePool pool)
    {
        int num = bulletModel.Count / 2;
        for (int i = 0; i < bulletModel.Count; i++)
        {
            GameObject go = pool.Get(bulletModel.InitPosition, bulletModel.LifeTime); //从对象池中获取 // 初始位置即enemy当前位置
            BulletMove bulletMove = go.GetComponent<BulletMove>();
            var render = go.GetComponent<MeshRenderer>();
            if (render != null)
            {
                go.GetComponent<MeshRenderer>().material?.SetColor("_EmissionColor", bulletModel.Color);
            }
            bulletMove.BulletSpeed = bulletModel.Speed;
            bulletMove.DelayTime = bulletModel.DelayTime;

            if (bulletModel.Count % 2 == 1)
            {
                go.transform.rotation = bulletModel.Direction * Quaternion.Euler(0, bulletModel.Angle * num, 0);
                go.transform.position = go.transform.position + go.transform.right * num * bulletModel.Distance;
                num--;
            }
            else
            {
                go.transform.rotation = bulletModel.Direction * Quaternion.Euler(0, bulletModel.Angle / 2 + bulletModel.Angle * (num - 1), 0);
                go.transform.position = go.transform.position + go.transform.right * ((num - 1) * bulletModel.Distance + bulletModel.Distance / 2);
                num--;
            }
            go.transform.position = go.transform.position + go.transform.forward * bulletModel.ShiftInitPos;
        }
    }

}
