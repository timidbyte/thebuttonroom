using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    private GameObject selected;
    private Color colorBeforeSelection;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 3f, layerMask))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (selected == null)
            {
                Select(hitObject);
            }
            else if (selected != hitObject)
            {
                Unselect(selected);
                Select(hitObject);
            }
        }
        else if (selected != null)
        {
            Unselect(selected);
        }
        if (Input.GetKeyDown(KeyCode.E) && selected != null)
        {
            LightButton button = selected.GetComponent<LightButton>();
            if (button != null)
            {
                button.Click();
            }
        }
    }

    private void Select(GameObject obj)
    {
        selected = obj;
        Material material = obj.GetComponent<Renderer>().material;
        colorBeforeSelection = material.color;
        material.color = Color.yellow;
    }

    private void Unselect(GameObject obj)
    {
        selected = null;
        obj.GetComponent<Renderer>().material.color = colorBeforeSelection;
    }
}
