/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Bevestiging
{
    [XmlRoot(ElementName = "opdrachtgever")]
    public class Opdrachtgever
    {
        [XmlElement(ElementName = "nr")]
        public string Nr { get; set; }
        [XmlElement(ElementName = "naam")]
        public string Naam { get; set; }
    }

    [XmlRoot(ElementName = "bevestiging")]
    public class Bevestiging
    {
        [XmlElement(ElementName = "datum")]
        public string Datum { get; set; }
        [XmlElement(ElementName = "orderref")]
        public string Orderref { get; set; }
        [XmlElement(ElementName = "volgnr")]
        public string Volgnr { get; set; }
        [XmlElement(ElementName = "aflevertijdplan")]
        public string Aflevertijdplan { get; set; }
        [XmlElement(ElementName = "opdrachtgever")]
        public Opdrachtgever Opdrachtgever { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string NoNamespaceSchemaLocation { get; set; }
    }

}
