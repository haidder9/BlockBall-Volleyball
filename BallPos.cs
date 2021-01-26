using System.Collections;
using UnityEngine;

namespace Scenes.GamePlay
{
    public class BallPos : MonoBehaviour
    {
        Vector2 _originalPos;
        Quaternion _originalRotation;


        void Start()
        {
            var transform1 = transform;
            _originalPos = transform1.position;
            _originalRotation = transform1.rotation;
        }
        IEnumerator StartDelay()
        {

            yield return new WaitForSeconds(1.5f);
            var o = gameObject;
            o.transform.position = new Vector2(6, 3);
            o.transform.rotation = _originalRotation;


        }
        IEnumerator StartDelay1()
        {

            yield return new WaitForSeconds(1.5f);
            var o = gameObject;
            o.transform.position = _originalPos;
            o.transform.rotation = _originalRotation;

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("goal"))
            {
                gameObject.transform.position = new Vector2(6, 6);
                StartCoroutine(StartDelay());
            

            }
            if (collision.gameObject.CompareTag("goal2"))
            {
                gameObject.transform.position = new Vector2(-6, 6);
                StartCoroutine(StartDelay1());
            

            }

        }
   
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
