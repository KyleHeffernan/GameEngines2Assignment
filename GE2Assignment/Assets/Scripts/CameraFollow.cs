using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
      public Transform milano;

      public float dist = 15.0f;
      public float height = 10.0f;

      public float heightDamping = 5.0f;
      public float rotDamping = 5.0f;

      //LateUpdate called after all update functions called, so camera position is calculated after ship position is calculated
      void  LateUpdate ()
      {
            Vector3 followPosition = new Vector3(0.0f, height, -dist);
            Quaternion lookrotation = Quaternion.identity;
            lookrotation.eulerAngles = new Vector3(30.0f, 0.0f, 0.0f);

            Matrix4x4 matrix1  = Matrix4x4.TRS(milano.position, milano.rotation, Vector3.one);
            Matrix4x4 matrix2  = Matrix4x4.TRS(followPosition, lookrotation, Vector3.one);
            Matrix4x4 matrixCombined  = matrix1 * matrix2;

            //Getting rotation and position from matrix
            Vector3 position = matrixCombined.GetColumn(3);
            Quaternion rotation = Quaternion.LookRotation(matrixCombined.GetColumn(2),matrixCombined.GetColumn(1));

            Quaternion newRot = rotation;
            Quaternion currentRot = transform.rotation;
            Vector3 newPos = position;
            Vector3 currentPos = transform.position;

            currentRot = Quaternion.Lerp(currentRot, newRot, rotDamping * Time.deltaTime);
            currentPos = Vector3.Lerp(currentPos, newPos, heightDamping * Time.deltaTime);

            transform.localRotation = currentRot;
            transform.localPosition = currentPos;
      }
}
