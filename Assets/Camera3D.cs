using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3D : MonoBehaviour
{
    public float speed_rotate = 1.0f;
    public float speed_scroll = 200.0f;

    public Transform pivoit;

    // 좌표 변환 클래스
    [System.Serializable]
    public class PosCordinates
    {
        public float _radius, _azimuth, _elevation;
        // azimuth(구면 좌표계(3D)에서 잰 각도) : 방위각
        // elevation : 앙각

        float _minrad, _maxrad, _minazi, _maxazi, _minelev, _maxelev;

        public PosCordinates(Vector3 cartesian)
        {
            _minrad = Mathf.Deg2Rad * _minazi;
            _maxrad = Mathf.Deg2Rad * _maxazi;
            _minelev = Mathf.Deg2Rad * _minelev;
            _maxelev = Mathf.Deg2Rad * _maxelev;

            radius = cartesian.magnitude; // 원점과의 거리 계산
            azimuth = Mathf.Atan2(cartesian.z, cartesian.x);
            elevation = Mathf.Asin(cartesian.y / radius);
        }

        public float radius
        {
            get { return _radius; }
            private set { _radius = Mathf.Clamp(value, _minrad, _maxrad); } // Clamp는 Lerp랑 같은 개념
        }

        public float azimuth
        {
            get { return _azimuth; }
            //private set { Mathf.Repeat(value, _maxazi, _minazi)}
        }

        public float elevation
        {
            get { return _elevation; }
        }
    }
}
