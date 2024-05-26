using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SO/Combat/PortalData")]
public class PortalDataSO : ScriptableObject
{
    public int minCount = 3;
    public int maxCount = 15;

    public PoolItemSO enemySO;
    public float launchForce;
    public float minTime;
    public float maxTime;
    public Color portalColor;
    public int GetRandomCount() => Random.Range(minCount, maxCount + 1);
}
