using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子弹移动
/// </summary>
public class BulletMove : MonoBehaviour
{
    /// <summary>
    /// 子弹速度
    /// </summary>
    public float BulletSpeed;
    /// <summary>
    /// 移动延时
    /// </summary>
    public float DelayTime;
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
        Vector3 p = transform.position;
        transform.position = transform.position + transform.forward * BulletSpeed * Time.fixedDeltaTime;
    }
}
