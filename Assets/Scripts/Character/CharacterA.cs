using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterA : MonoBehaviour
{
    CharacterController CC;
    //Animator animator;
    public float Speed;
    public float jumpSpeed = 4F;
    public float gravity = 20F;
    public float bulletCD = 0.1f;
    Vector3 hitPoint;
    public float fastSpeed = 10;
    public float slowSpeed = 5;
    Vector3 Turn;
    public float TurnSpeed = 3;
    bool isShoot;

    [Header("弹幕配置部分")]

    public float LifeTime = 4f; //子弹生命周期
    public int Count = 1; //一次生成的子弹的数量
    [Range(0, 5)]
    public float CdTime = 0.1f; //子弹间隔时间
    [Range(0, 30)]
    public float BulletSpeed = 10; //子弹移动速度
    [Range(0, 360)]
    public float Angle = 0; //旋转角度
    [Range(0, 10)]
    public float Distance = 0; // 子弹间的间隔
    int LimitI = 0;

    BasePool bulletPool;
    GameObject bulletPrefab;
    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        bulletPool = GameObjectPoolManager.Instance.CreatGameObjectPool<BasePool>("Prefabs/Bullet", bulletPrefab);
        //m_bullet1_pool.prefab = m_BulletPrefab;
        CC = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
        Speed = fastSpeed;
        isShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        hitPoint = transform.position;// + transform.up * 0.43f + transform.forward * 1.2f;
    }

    private void FixedUpdate()
    {
        PlayerMove();
        LimitI++;
    }

    float h = 0;
    float v = 0;
    public void Move(float h, float v)
    {
        this.h = h;
        this.v = v;
        Turn = v * Vector3.up + h * Vector3.right; // x-y 面内
        //当模大于1时，要进行归一化，防止在斜方向移动时，移动速度加快
        if (Turn.magnitude > 1f) Turn.Normalize();

        if (!Input.GetButton("Fire1") && (h != 0 || v != 0))
        {
            isShoot = false;
            SetRotation(Turn);
        }
        //if (h == 0 && v == 0)
        //{
        //    animator.SetFloat("Vertical", 0);
        //    animator.SetFloat("Horizontal", 0);
        //}
        //else
        //{
        //    animator.SetFloat("Vertical", 1);
        //}
    }

    void PlayerMove()
    {
        if (v != 0 || h != 0)
        {
            CC.Move(Turn * Speed * Time.fixedDeltaTime);
        }
    }

    Vector3 realPosition;
    Ray ray;


    public void Shoot(int i)
    {
        // animator.SetInteger("Shoot", i);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机发出一条射线,到点击的坐标
        var point = GetPoint(ray.GetPoint(0), ray.direction, Vector3.up, new Vector3(0, hitPoint.y, 0));
        realPosition = new Vector3(point.x, transform.position.y, point.z);
        isShoot = true;
        //SetRotation(realPosition);
        if (i < 30)
            return;
        BulletModel bulletModel = new BulletModel() { Count = 1,Speed = 5 };
        bulletModel.Set(hitPoint, transform.rotation); // , Count, LifeTime, BulletSpeed, Angle, Distance

        if (LimitI > CdTime * 50)
        {
            BulletManager.Instance.DoShoot(bulletModel, bulletPool);
            LimitI = 0;
        }
    }

    Quaternion faceToQuat;
    /// <summary>
    /// 旋转player
    /// </summary>
    /// <param name="v"></param>
    void SetRotation(Vector3 v)
    {
        if (isShoot)
        {
            faceToQuat = Quaternion.LookRotation(v - transform.position, Vector3.up);
        }
        else
        {
            faceToQuat = Quaternion.LookRotation(v, Vector3.up);
        }
        //faceToQuat.z = 0; // 锁定Z轴，只在 X-Y平面内移动
        transform.rotation = Quaternion.Slerp(transform.rotation, faceToQuat, TurnSpeed * Time.fixedDeltaTime); //slerp
        //transform.rotation = Quaternion.AngleAxis(Quaternion.Angle(transform.rotation, faceToQuat), Vector3.forward);
    }

    /// <summary>
    /// 射线与平面的交点
    /// </summary>
    /// <param name="point">直线上某一点</param>
    /// <param name="direct">直线的方向</param>
    /// <param name="planeNormal">垂直于平面的的向量</param>
    /// <param name="planePoint">平面上的任意一点</param>
    /// <returns></returns>
    private Vector3 GetPoint(Vector3 point, Vector3 direct, Vector3 planeNormal, Vector3 planePoint)
    {
        float d = Vector3.Dot(planePoint - point, planeNormal) / Vector3.Dot(direct.normalized, planeNormal);

        return d * direct.normalized + point;
    }
}
