using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapePlayer : MonoBehaviour
{
    /// <summary>
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    public Material InactiveMaterial;

    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    public Material GazedAtMaterial;

    // The objects are about 1 meter in radius, so the min/max target distance are
    // set so that the objects are always within the room (which is about 5 meters
    // across).
    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;

    private Renderer _myRenderer;
    [SerializeField] private GameObject TapePlayerButtons;
    [SerializeField] private Transform centrePoint;
    [SerializeField] private CameraPointer cameraPointer;
    public AudioSource tapePlayerAudioSource;
    public AudioClip[] tracks;
    public int playdTrackCode;

    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    public void Update()
    {
        if (centrePoint.gameObject.active)
        {
            centrePoint.position = cameraPointer.raycastHitPosition.position;
        }
    }
    /// <summary>
    /// Teleports this instance randomly when triggered by a pointer click.
    /// </summary>
    public void TeleportRandomly()
    {

    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        centrePoint.gameObject.SetActive(true);
        
       // TapePlayerButtons.SetActive(true);
        // SetMaterial(true);
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        centrePoint.gameObject.SetActive(false);
        //TapePlayerButtons.SetActive(false);
        //SetMaterial(false);
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        TeleportRandomly();
    }

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}
