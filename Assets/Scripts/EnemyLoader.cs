using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 加载敌方单位
/// </summary>
public class EnemyLoader : MonoBehaviour
{
    void Awake()
    {
        GameObject enemy = Resources.Load<GameObject>("Prefabs/Enemy");
        BasePool pool = GameObjectPoolManager.Instance.CreatGameObjectPool<BasePool>("Prefabs/Enemy", enemy);

        enemy = pool.Get( new Vector3(0, 10, 0), 0); // 
        //pool.Remove(enemy);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
