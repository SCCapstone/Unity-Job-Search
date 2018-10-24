using UnityEngine;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class TeleportNode : MonoBehaviour
    {
        [SerializeField] private Material m_NormalMaterial;
        [SerializeField] private Material m_OverMaterial;
        [SerializeField] private Material m_ClickedMaterial;
        [SerializeField] private Material m_DoubleClickedMaterial;
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer;
        public GameObject VRCamera;
        public bool locationSelected;
        public Vector3 currentCameraPosition;

        private void Awake()
        {
            m_Renderer.material = m_NormalMaterial;
        }


        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        }


        //Handle the Over event
        private void HandleOver()
        {
            Debug.Log("Show over state");
            m_Renderer.material = m_OverMaterial;
        }


        //Handle the Out event
        private void HandleOut()
        {
            Debug.Log("Show out state");
            m_Renderer.material = m_NormalMaterial;
        }


        //Handle the Click event
        private void HandleClick()
        {
            Debug.Log("Show click state");
            VRCamera.transform.position = new Vector3(transform.position.x, VRCamera.transform.position.y, transform.position.z);
            VRCamera.transform.rotation = Quaternion.Euler(0, 180, 0);

        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
            m_Renderer.material = m_DoubleClickedMaterial;
        }
    }

}