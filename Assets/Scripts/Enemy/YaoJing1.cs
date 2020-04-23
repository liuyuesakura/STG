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
    /// 小怪如何移动
    /// </summary>
    public Vector3 MoveEndPoint = Vector3.zero;
    /// <summary>
    /// 移动速度
    /// </summary>
    public float MoveSpeed;// = 0.01f; // 优先inspector中的设定，这里的定义是无效的

    /// <summary>
    /// 
    /// </summary>
    public float FireCD;
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

    float _timer;
    void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        if(_timer >= FireCD)
        {
            bulletModel.Set(this.transform.position, this.transform.rotation);
            BulletManager.Instance.DoShoot(bulletModel, bulletPool);
            _timer = 0;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, (transform.rotation * Quaternion.Euler(0 , 0, rotateEulerZ)), 3 * Time.fixedDeltaTime); //slerp
        rotateEulerZ += 5;

        if(MoveEndPoint != Vector3.zero)
        {
            Vector3 vector = -(this.transform.position - this.MoveEndPoint) * MoveSpeed * Time.fixedDeltaTime; // 这种方式移动速度会渐慢
            Debug.Log(vector);
            this.transform.position += vector;
        }
    }
}
