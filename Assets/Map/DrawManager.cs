using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Line _linePrefab;
    public const float RESOLUTION = 0.1f;
    private Line _currentLine;
    [SerializeField] private LayerMask mapLayerMask;

    void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray,out hit, 5f, mapLayerMask))
            {
                _currentLine = Instantiate(_linePrefab, hit.point, transform.rotation, this.transform);
                _currentLine.transform.localPosition = new Vector3(
                    _currentLine.transform.localPosition.x,
                    _currentLine.transform.localPosition.y + 0.5f,
                    _currentLine.transform.localPosition.z
                );
            }
        }

        if(Input.GetMouseButton(0))
        {
            if(Physics.Raycast(ray,out hit, 5f, mapLayerMask))
            {
                _currentLine.SetPosition(hit.point);
                _currentLine.transform.rotation = hit.transform.rotation;
            }
        }
    }
}
