using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARImagePlacer : MonoBehaviour
{
    public Transform arObjectPrefab; // 증강할 AR 오브젝트 프리팹
    public Transform hmdTransform; // HMD 트랜스폼

    public double currentLat;
    public double currentLon;
    public double photoLat;
    public double photoLon;

    private Transform arObjectInstance;

    void Start()
    {
        // 사진의 위치를 계산
        Vector3 photoPosition = CaculateLocation.CalculatePositionFromLocation(currentLat, currentLon, photoLat, photoLon);

        // AR 오브젝트를 하나만 생성하고 위치 설정
        if (arObjectInstance == null)
        {
            arObjectInstance = Instantiate(arObjectPrefab, photoPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        // 사용자의 시선 방향을 설정
        Vector3 forwardDirection = GetHMDForwardDirection(hmdTransform);
        if (arObjectInstance != null)
        {
            arObjectInstance.rotation = Quaternion.LookRotation(forwardDirection);
        }
    }

    Vector3 GetHMDForwardDirection(Transform hmdTransform)
    {
        return hmdTransform.forward;
    }
}