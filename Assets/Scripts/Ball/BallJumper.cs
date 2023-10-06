using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForse;
    [SerializeField] private float _rayDisctace;
    [SerializeField] private LayerMask _platform;
    [SerializeField] private Material _currentMaterial;
    [SerializeField] private string _currentCollor;
    [SerializeField] private Material startMaterial;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        EventManager.Colored += ChangeCurrentColor;
        
    }
    private void Start()
    {
        Initialized();
    }
    private void Initialized()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()  
    {
        DoJump();
    }
    private void DoJump()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * _rayDisctace, Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, _rayDisctace))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.gameObject.TryGetComponent(out PlatformSegment platformSegment))
            {
                string _materialName = platformSegment.GetComponent<MeshRenderer>().material.name;
                Debug.Log(_materialName);
                if ( _currentCollor + " (Instance)" ==_materialName  || startMaterial.name + " (Instance)" == _materialName)
                {
                    Debug.Log("slomalsya1");
                    DestroyPlatform(hit.transform.gameObject);
                }
            }
            if (hit.transform.tag == "Platform")
            {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.AddForce(Vector3.up * _jumpForse, ForceMode.Impulse);
            }
        }
    }
    private void DestroyPlatform(GameObject babyPlatform)
    {
        Debug.Log("slomalsya2");
        Transform platform = babyPlatform.transform.parent;
        Destroy(platform.gameObject);
    }
    private void ChangeCurrentColor(Material currentMaterial)
    {
        _currentMaterial = currentMaterial;
        _currentCollor = currentMaterial.name;
    } 
    private void OnDestroy()
    {
        EventManager.Colored -= ChangeCurrentColor;
    }
}
