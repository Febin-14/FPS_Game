using UnityEngine;

public class InspectClose : MonoBehaviour
{
   public void OnClick()
    {
              InspectManager.Instance.StopInspect();
    }
}
