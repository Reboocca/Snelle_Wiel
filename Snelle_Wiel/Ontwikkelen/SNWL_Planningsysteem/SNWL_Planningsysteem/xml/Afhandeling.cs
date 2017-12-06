/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Afhandeling
{
    [XmlRoot(ElementName = "opdrachtgever")]
    public class Opdrachtgever
    {
        [XmlElement(ElementName = "nr")]
        public string Nr { get; set; }
        [XmlElement(ElementName = "naam")]
        public string Naam { get; set; }
    }

    [XmlRoot(ElementName = "laadgegevens")]
    public class Laadgegevens
    {
        [XmlElement(ElementName = "aantal")]
        public string Aantal { get; set; }
        [XmlElement(ElementName = "kg")]
        public string Kg { get; set; }
        [XmlElement(ElementName = "m3")]
        public string M3 { get; set; }
    }

    [XmlRoot(ElementName = "retourartikel")]
    public class Retourartikel
    {
        [XmlElement(ElementName = "nr")]
        public string Nr { get; set; }
        [XmlElement(ElementName = "naam")]
        public string Naam { get; set; }
        [XmlElement(ElementName = "aantal")]
        public string Aantal { get; set; }
    }

    [XmlRoot(ElementName = "retourlaadgegevens")]
    public class Retourlaadgegevens
    {
        [XmlElement(ElementName = "aantal")]
        public string Aantal { get; set; }
        [XmlElement(ElementName = "kg")]
        public string Kg { get; set; }
        [XmlElement(ElementName = "m3")]
        public string M3 { get; set; }
    }

    [XmlRoot(ElementName = "afhandeling")]
    public class Afhandeling
    {
        [XmlElement(ElementName = "datum")]
        public string Datum { get; set; }
        [XmlElement(ElementName = "orderref")]
        public string Orderref { get; set; }
        [XmlElement(ElementName = "volgnr")]
        public string Volgnr { get; set; }
        [XmlElement(ElementName = "aflevertijd")]
        public string Aflevertijd { get; set; }
        [XmlElement(ElementName = "opdrachtgever")]
        public Opdrachtgever Opdrachtgever { get; set; }
        [XmlElement(ElementName = "laadgegevens")]
        public Laadgegevens Laadgegevens { get; set; }
        [XmlElement(ElementName = "redenretour")]
        public string Redenretour { get; set; }
        [XmlElement(ElementName = "retourartikel")]
        public List<Retourartikel> Retourartikel { get; set; }
        [XmlElement(ElementName = "retourlaadgegevens")]
        public Retourlaadgegevens Retourlaadgegevens { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string NoNamespaceSchemaLocation { get; set; }
    }

}
