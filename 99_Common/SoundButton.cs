using UnityEngine;
using UnityEngine.UI;

namespace SuperVeigar
{
    public class SoundButton : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(()=>
            {
                SoundButtonService.Instance.Play();
            });
        }
    }
}
