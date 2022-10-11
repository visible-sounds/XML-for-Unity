using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

namespace XMLSystem
{
    /// <summary>
    /// Serializable transform handling.
    /// </summary>
    public class XMLTransform 
    {
        [XmlElement("Position")] public Vector3 position;
        [XmlElement("Rotation")] public Vector3 rotation;
        [XmlElement("Scale")] public Vector3 scale;

        // Constructor for XML Object.
        public XMLTransform()
        {
            
        }

        public XMLTransform Set(Transform t)
        {
            this.position = t.position;
            this.rotation = t.eulerAngles;
            this.scale = t.localScale;
            return this;
        }

        // Transfering parameters from the XMLTransform object.
        public Transform LoadTransform(Transform t)
        {
            t.localPosition = this.position;
            t.rotation = Quaternion.Euler(this.rotation);
            t.localScale = this.scale;
            return t;
        }
    }
}
