using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏打开时
/// </summary>
public class OnGameOpen : MonoBehaviour
{
    bool isLoading = true;
    /// <summary>
    /// 加载信息
    /// </summary>
    void Awake()
    {

        StartCoroutine("LoadConfigs");

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLoading)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single); // 切换场景
        }
    }

    void LoadConfigs()
    {
        isLoading = true;
        //加载enemy configs
        EnemyModel4Json enemies = new EnemyModel4Json();
        enemies.Enemies = new List<EnemyModel>();
        enemies.Enemies.Add(new EnemyModel()
        {
            Destinations = new List<Vector3>() { new Vector3(5, 5, 0), new Vector3(-10, -10, 0) },
            FireModels = new List<EnemyFireModel>() {
                  new EnemyFireModel() {   BulletModel = new BulletModel(){ Angle = 60, Count = 6, Speed = 5 }, DelayTime = 10, FireCD = 0.2f, FireLimit = 100}
              },
            InitPosition = new Vector3(10, 10, 0),
            MoveSpeedCurve = new AnimationCurve(new Keyframe(0.5f, 1), new Keyframe(0, 1), new Keyframe(0.5f, 10)),
            Prefab = "Prefabs/Enemy"
        });
        string jsonString = JsonUtility.ToJson(enemies);
        using (System.IO.FileStream fs = new System.IO.FileStream(@"F:\UnityProjects\STG\Assets\Resources\Configs\Enemies.json", System.IO.FileMode.Truncate))
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fs))
            {
                sw.Write(jsonString);
            }
        }
        //加载level configs
        //加载prefabs，创建对象池

        EnemyLoader.Instance.
        isLoading = false;
    }
}
