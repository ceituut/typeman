using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Definition;

public class Finger : MonoBehaviour
{
    private Vector3 initialLPosition;
    [SerializeField] private Vector3 transformVector;
    [SerializeField] private FingerTypes fingerType;
    [SerializeField] private Color fingerIdleColor;
    [SerializeField] private Color fingerActiveColor;

    public Vector3 TransformVector { get => transformVector; set => transformVector = value; }
    public FingerTypes GetFingerType { get => fingerType;}
    public Vector3 GetInitialLPosition { get => initialLPosition;}
    public Color FingerIdleColor { get => fingerIdleColor; set => fingerIdleColor = value; }
    public Color FingerActiveColor { get => fingerActiveColor; set => fingerActiveColor = value; }

    private void Awake() 
    {
        initialLPosition = gameObject.transform.position;
    }

    public void ResetColor()
    {
        this.gameObject.GetComponent<Image>().color = FingerIdleColor;
    }
    public void ActivateColor()
    {
        this.gameObject.GetComponent<Image>().color = FingerActiveColor;
    }
    public Vector3 GetActualPosition()
    {
        Transform parent = gameObject.GetComponent<RectTransform>().parent;
        Vector3 actualPos = new Vector3();
        actualPos = gameObject.GetComponent<RectTransform>().localPosition;
        while(parent != null)
        {
            actualPos += parent.localPosition;
        }
        return actualPos;
    }
    public void SetActualPosition(Vector3 targetPos)
    {
        Transform parent = gameObject.GetComponent<RectTransform>().parent;
        while(parent != null)
        {
            this.GetComponent<RectTransform>().position += parent.localPosition;
        }
        this.GetComponent<RectTransform>().position+= targetPos;
    }
}