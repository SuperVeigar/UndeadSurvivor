using UnityEngine;
using UnityEngine.UI;

namespace SuperVeigar
{
    public class ButtonLevelUp : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => UIService.Instance.SetActivePopupBack(PopupType.PopupLevelUp, false));
        }
    }
}

