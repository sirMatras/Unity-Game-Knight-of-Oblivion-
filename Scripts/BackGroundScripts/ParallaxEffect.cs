using UnityEngine;

public class ParallexEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    private Vector2 _startingPosition;
    private float _startingZ;

    private Vector2 CamMoveSinceStart => (Vector2)cam.transform.position - _startingPosition;
    private float ParallaxFactor => Mathf.Abs(ZDistanceFromTarget) / ClippingPlane;

    private float ZDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    private float ClippingPlane =>
        (cam.transform.position.z + (ZDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
        _startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = _startingPosition + CamMoveSinceStart * ParallaxFactor;

        transform.position = new Vector3(newPosition.x, newPosition.y, _startingZ);
    }
}