using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStackController : MonoBehaviour
{

    public List<GameObject> blockList= new List<GameObject>();
    private GameObject lastBlockObject;

    void Start()
    {
        UpdateLastBlockObject();
    }

    public void IncreaseBlockStack(GameObject _gameObject) // bu kýsýmda özetle yeni obje eklenince küpü 2f yukarý çýakrtýyorki yeni kü gelebilsini eklencek küpün pozisyonu ayarlanýyor(-2f),küpün partenti biz oluyoruz,küp listesi,ne ekliyoreuz ve lastblock u güncelliyoruz
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        _gameObject.transform.position = new Vector3(lastBlockObject.transform.position.x, lastBlockObject.transform.position.y - 2f, lastBlockObject.transform.position.z);
        _gameObject.transform.SetParent(transform);
        blockList.Add( _gameObject );
        UpdateLastBlockObject();
    }

    public void DecreaseBlock(GameObject _gameobject)
    {
        _gameobject.transform.parent = null;
        blockList.Remove(_gameobject);
        UpdateLastBlockObject();
    }


    private void UpdateLastBlockObject()
    {
        lastBlockObject = blockList[blockList.Count - 1];
    }
}
