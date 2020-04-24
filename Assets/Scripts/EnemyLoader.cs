using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 加载敌方单位
/// </summary>
public class EnemyLoader : MonoBehaviour
{
    BasePool pool;

    void Awake()
    {
        //加载configs

        GameObject enemy = Resources.Load<GameObject>("Prefabs/Enemy");
        pool = GameObjectPoolManager.Instance.CreatGameObjectPool<BasePool>("Prefabs/Enemy", enemy);

        enemy = pool.Get( new Vector3(10, 20, 0), 0); // 
        pool.Remove(enemy);
        //YaoJing1 yaoJing = enemy.GetComponent<YaoJing1>();
        //yaoJing.MoveEndPoint = new Vector3(-10, -10, 0);
        //yaoJing.MoveSpeed = 0.5f;
        //yaoJing.FireCD = 0.5f;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            yaoJing.FireCD = 0.5f;

            _timer = 0;
            enemyCount++;
        }
    }
}
