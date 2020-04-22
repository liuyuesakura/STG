using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 小怪 妖精I
/// </summary>
public class YaoJing1 : MonoBehaviour
{
    bool IsAwake = false;

    AnimationCurve Curve;

    //[HideInInspector]
    BasePool bulletPool;
    BulletModel bulletModel;
    /// <summary>
    /// 绕Z轴旋转的欧拉角
    /// </summary>
    int rotateEulerZ = 5;
    /// <summary>
    /// awake位置应当在屏幕外
    /// </summary>
    void Awake()
    {
        Curve = new AnimationCurve();
        bulletModel = new BulletModel() { Count = 6, Speed = 10, Angle = 60 };
        GameObject bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        bulletPool = GameObjectPoolManager.Instance.CreatGameObjectPool<BasePool>("Prefabs/Bullet", bullet);
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
        bulletModel.Set( this.transform.position, this.transform.rotation);
        BulletManager.Instance.DoShoot(bulletModel, bulletPool);

        transform.rotation = Quaternion.Slerp(transform.rotation, (transform.rotation * Quaternion.Euler(0 , 0, rotateEulerZ)), 3 * Time.fixedDeltaTime); //slerp
        rotateEulerZ += 5;
    }
}
