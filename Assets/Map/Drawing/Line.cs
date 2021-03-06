using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer;
    public bool blockLine = false;

    public void SetPosition(Vector3 pos)
    {
        if(!CanAppend(pos)) return;

        _renderer.positionCount++;

        _renderer.SetPosition(_renderer.positionCount-1,pos);
    }

    private bool CanAppend(Vector3 pos)
    {
        if(_renderer.positionCount == 0) {return true;}
        
        return Vector3.Distance(_renderer.GetPosition(_renderer.positionCount-1),pos) > DrawManager.RESOLUTION && blockLine == false;
    }
}
