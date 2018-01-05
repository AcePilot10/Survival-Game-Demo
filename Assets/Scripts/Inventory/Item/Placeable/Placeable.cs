using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Placeable", fileName = "Placeable")]
public class Placeable : Item {

    #region variables

    public GameObject placeableObject;
    public Vector3 spawnPos;
    public float adjustmentSpeed;
    public LayerMask maskedLayers;

    private bool isPlacing = false;
    private Vector3 offset;
    private GameObject currentObject;

    #endregion

    private void OnEnable()
    {
        PlayerInput.OnPlaceAttempt += Place;
    }

    private void OnDisable()
    {
        PlayerInput.OnPlaceAttempt -= Place;
        PlayerManager.OnPlayerUpdate -= Update;
    }

    public override void Drop()
    {
        //Do nothing
    }

    public override void Use()
    {
        InitPlace();
    }

    public virtual void InitPlace()
    {
        if (currentObject != null) Destroy(currentObject);
        currentObject = Instantiate(placeableObject) as GameObject;
        currentObject.transform.parent = Camera.main.transform;
        currentObject.transform.position = Camera.main.transform.TransformPoint(spawnPos);
        Inventory.instance.ToggleInventory();
        Debug.Log("Instantiated: " + currentObject.name);
        isPlacing = true;
        PlayerManager.OnPlayerUpdate += Update;
    }

    public virtual void Place()
    {
        if (isPlacing)
        {
            currentObject.transform.parent = null;
            currentObject = null;
            isPlacing = false;
            Inventory.instance.RemoveItem(this);
            Debug.Log("Placed item!");
        }
    }

    void Update()
    {
        if (isPlacing == true)
        {
            HandleAdjustment();
            RaycastHit hit;
            Vector3 camPos = Camera.main.transform.position;
            Ray ray = new Ray(camPos, Camera.main.transform.TransformDirection(Vector3.forward));
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, maskedLayers))
            {
                if (hit.collider != null)
                {
                    Debug.Log("Collided with: " + hit.collider.name);
                    Bounds bounds = currentObject.GetComponent<MeshRenderer>().bounds;
                    float yOffset = currentObject.transform.position.y - bounds.min.y;
                    currentObject.transform.transform.position = hit.point;
                    Vector3 currentPos = hit.point;
                    currentPos.y += yOffset;
                    currentObject.transform.position = currentPos;
                }
            }
        }
    }

    void HandleAdjustment()
    {
        float verticalDir = 0f;
        float horizontalDir = 0f;
        if (Input.GetKey(KeyCode.Keypad8))
        {
            //Up
            verticalDir = 1;
        }

        if (Input.GetKey(KeyCode.Keypad2))
        {
            //Down
            verticalDir = -1;
        }

        if (Input.GetKey(KeyCode.Keypad4))
        {
            //Left
            horizontalDir = -1;
        }

        if (Input.GetKey(KeyCode.Keypad6))
        {
            //Right
            horizontalDir = 1;
        }

        Vector3 movement = new Vector3(horizontalDir, 0, verticalDir);
        currentObject.transform.Translate(movement * adjustmentSpeed);
        offset = currentObject.transform.position;
    }
}