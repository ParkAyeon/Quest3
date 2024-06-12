using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARImagePlacer : MonoBehaviour
{
    public Transform arObjectPrefab; // ������ AR ������Ʈ ������
    public Transform hmdTransform; // HMD Ʈ������

    public double currentLat;
    public double currentLon;
    public double photoLat;
    public double photoLon;

    private Transform arObjectInstance;

    void Start()
    {
        // ������ ��ġ�� ���
        Vector3 photoPosition = CaculateLocation.CalculatePositionFromLocation(currentLat, currentLon, photoLat, photoLon);

        // AR ������Ʈ�� �ϳ��� �����ϰ� ��ġ ����
        if (arObjectInstance == null)
        {
            arObjectInstance = Instantiate(arObjectPrefab, photoPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        // ������� �ü� ������ ����
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