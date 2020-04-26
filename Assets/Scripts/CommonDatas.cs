using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonDatas : SingleClass<CommonDatas>
{

    public Dictionary<string, GameObject> _gameObjectDic = new Dictionary<string, GameObject>();

    public bool TryGetGameObject(string prefabString, out GameObject inDic)
    {
        inDic = null;
        if (!_gameObjectDic.ContainsKey(prefabString))
            return false;

        inDic = _gameObjectDic[prefabString];
        return true;
    }

    public bool TrySetGameObject(string prefabString, GameObject inDic)
    {
        if (inDic == null)
            return false;
        if (!_gameObjectDic.ContainsKey(prefabString))
            _gameObjectDic.Add(prefabString, inDic);
        else
            _gameObjectDic[prefabString] = inDic;
        return true;
    }
}
