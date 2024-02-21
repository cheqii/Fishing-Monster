using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealBait : MonoBehaviour
{
    [SerializeField] private BaitData baitData;

    private BaitTypes _baitTypes;
    public Transform buoyancy;
    public bool Cancel= false;
    public bool isEaten = false;

    public SpriteRenderer baitSprite;
    // Start is called before the first frame update
    void Start()
    {
        baitSprite.sprite = baitData.baitSprite;
        
        _baitTypes = baitData.baitType;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cancel == true)
        {

            transform.position = Vector3.Lerp(transform.position, buoyancy.position, Time.deltaTime*10);
        }
    }
    
    public void SetBait(BaitData _data)
    {
        this.baitData = _data;
    }
    
    public BaitTypes GetBait()
    {
        return _baitTypes;

    }
}
