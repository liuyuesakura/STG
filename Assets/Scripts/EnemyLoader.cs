using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 加载敌方单位
/// </summary>
public class EnemyLoader : SingleClass<EnemyLoader>
{
    BasePool pool;
    /// <summary>
    /// 
    /// </summary>
    public void Init()
    { 
        GameObject enemy = Resources.Load<GameObject>("Prefabs/Enemy");
        pool = GameObjectPoolManager.Instance.CreatGameObjectPool<BasePool>("Prefabs/Enemy", enemy);

        enemy = pool.Get(new Vector3(10, 20, 0), 0); // 
        pool.Remove(enemy);
        //YaoJing1 yaoJing = enemy.GetComponent<YaoJing1>();
        //yaoJing.MoveEndPoint = new Vector3(-10, -10, 0);
        //yaoJing.MoveSpeed = 0.5f;
        //yaoJing.FireCD = 0.5f;
    }
    float _timer = 0;
    int enemyCount = 0;

    void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer >= 0.2 && enemyCount <= 20) 
        {
            GameObject go = pool.Get(new Vector3(10, 20, 0), 0); // 
            YaoJing1 yaoJing = go.GetComponent<YaoJing1>();
            yaoJing.MoveEndPoint = new Vector3(-20, 0, 0);
            yaoJing.MoveSpeed = 0.5f;
            yaoJing.FireCD = 0.1f;

            _timer = 0;
            enemyCount++;
        }
    }
}
