using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private FloatVeriable enemyHp;
        [SerializeField] private FloatVeriable playerSpeed;
        [SerializeField] private Transform enemyTransform;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Camera mainCamera;

        private void Update()
        {
            playerSpeed.Value = Input.GetAxis("Horizontal");
            
            if (Input.GetMouseButton(0))
            {
                var dist = Mathf.Abs(playerTransform.position.x - enemyTransform.position.x);
                if (dist < 1.5f)
                {
                    var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                    {
                        if (Physics.Raycast(ray, out var hit))
                        {
                            var hitTransform = hit.transform;
                            if (hitTransform == enemyTransform)
                            {
                                enemyHp.Value -= 0.25f;
                            }
                        }
                    }
                }

                
            }
        }
    }
}