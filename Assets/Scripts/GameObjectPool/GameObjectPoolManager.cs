﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPoolManager : SingleClass<GameObjectPoolManager>
{

    // Start is called before the first frame update
    /// <summary>
    /// 存放所有的对象池
    /// </summary>
    Dictionary<string, BasePool> poolDic = new Dictionary<string, BasePool>();
    /// <summary>
    /// 对象池在场景中的父控件
    /// </summary>
    Transform parentTrans;

    /// <summary>
    /// 创建一个新的对象池
    /// </summary>
    /// <typeparam name="T">对象池类型</typeparam>
    /// <param name="poolName">对象池名称，唯一id</param>
    /// <returns>对象池对象</returns>
    GameObject AllPool;
    public T CreatGameObjectPool<T>(string poolName, GameObject prefab) where T : BasePool, new()
    {
        if (poolDic.ContainsKey(poolName))
        {
            return (T)poolDic[poolName];
        }
        //生成一个新的GameObject存放所有的对象池对象
        if (AllPool == null)
            AllPool = new GameObject("AllPool");
        parentTrans = AllPool.transform;
        GameObject obj = new GameObject(poolName);
        obj.transform.SetParent(parentTrans);
        T pool = new T();
        pool.Init(poolName, obj.transform);
        pool.prefab = prefab;
        poolDic.Add(poolName, pool);
        return pool;
    }

    /// <summary>
    /// 从对象池中取出新的对象
    /// </summary>
    /// <param name="poolName">对象池名称</param>
    /// <param name="position">对象新坐标</param>
    /// <param name="lifeTime">对象显示时间</param>
    /// <returns>新对象</returns>
    public GameObject GetGameObject(string poolName, Vector3 position, float lifeTime)
    {
        if (poolDic.ContainsKey(poolName))
        {
            return poolDic[poolName].Get(position, lifeTime);
        }
        return null;
    }

    /// <summary>
    /// 将对象存入对象池中
    /// </summary>
    /// <param name="poolName">对象池名称</param>
    /// <param name="go">对象</param>
    public void RemoveGameObject(string poolName, GameObject go)
    {
        if (poolDic.ContainsKey(poolName))
        {
            poolDic[poolName].Remove(go);
        }
    }

    public int GetPoolCount()
    {
        return poolDic.Count;
    }

    /// <summary>
    /// 销毁所有对象池操作
    /// </summary>
    public void Destroy()
    {
        poolDic.Clear();
        GameObject.Destroy(parentTrans);
    }
}
