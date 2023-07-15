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

    public void IncreaseBlockStack(GameObject _gameObject) // bu k�s�mda �zetle yeni obje eklenince k�p� 2f yukar� ��akrt�yorki yeni k� gelebilsini eklencek k�p�n pozisyonu ayarlan�yor(-2f),k�p�n partenti biz oluyoruz,k�p listesi,ne ekliyoreuz ve lastblock u g�ncelliyoruz
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
