using UnityEngine;
public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _towerCylinder;
    [SerializeField] private float _additionalScale;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private TowerPlatform _platform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private float _startAndFinishAddishionalScale = 0.5f;
    public int levels;
    public float TowerScaleY => levels  + _startAndFinishAddishionalScale + _additionalScale /2f;
    private void Awake()
    {
        Build(_towerCylinder);
    }
    private void Build(GameObject towerCylinder)
    {
        GameObject _mainTower = Instantiate(towerCylinder, transform);
        _mainTower.transform.localScale = new Vector3(1, TowerScaleY, 1);

        Vector3 spawnPosition = _mainTower.transform.position;
        spawnPosition.y += _mainTower.transform.localScale.y - _additionalScale;
        SpawnPlatforms(_startPlatform, ref spawnPosition, Quaternion.identity, transform);

        for (int i = 0; i < levels; i++)
        {
            SpawnPlatforms(_platform, ref spawnPosition, Quaternion.identity, transform);
        }
        SpawnPlatforms(_finishPlatform, ref spawnPosition, Quaternion.identity, transform);
    }
    private void SpawnPlatforms(TowerPlatform platform, ref Vector3 platformPosition,Quaternion rotation, Transform parent)
    {
        Instantiate(platform, platformPosition, rotation, parent);
        platformPosition.y -= 1.5f;
    }
    private void SpawnPlatforms(FinishPlatform platform, ref Vector3 platformPosition, Quaternion rotation, Transform parent)
    {
        Instantiate(platform, platformPosition, rotation, parent);
        platformPosition.y -= 1.5f;
    }
    private void SpawnPlatforms(StartPlatform platform, ref Vector3 platformPosition, Quaternion rotation, Transform parent)
    {
        Instantiate(platform, platformPosition, rotation, parent);
        platformPosition.y -= 1.5f;
    }
}
