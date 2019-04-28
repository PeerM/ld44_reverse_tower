using System;
using UnityEngine;
using UnityEngine.UI;

namespace behavior.Player
{
    [RequireComponent(typeof(Damagable))]
    public class IntegrityDisplay : MonoBehaviour
    {
        public PlayerBaseComponent tower;
        public GameObject healthPanel;
        public GameObject healthPrefab;
        public Vector3 healthPanelOffset;
        public Canvas canvas;
        private Text healthText;

        // Start is called before the first frame update
        void Start()
        {
            //TODO this will explode with more than one canvas
            canvas = FindObjectOfType<Canvas>();
            
            tower = GetComponent<PlayerBaseComponent>();
            healthPanel = Instantiate(healthPrefab) as GameObject;
            healthPanel.transform.SetParent(canvas.transform, false);

            var uiHandle = healthPanel.GetComponent<TowerUI>();
            uiHandle.subject = tower;
            healthText = uiHandle.healtText;
            healthText.text = "00";
            
        }

        // Update is called once per frame
        void Update()
        {
            healthText.text = $"{tower.damagable.hp}";

            Vector3 worldPos = transform.position + healthPanelOffset;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
            healthPanel.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);
        }

        private void OnDestroy()
        {
            //TODO remove gui
            Destroy(healthPanel);
        }
    }
}
