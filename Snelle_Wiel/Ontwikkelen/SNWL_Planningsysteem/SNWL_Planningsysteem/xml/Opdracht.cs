/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Opdracht
{
    [XmlRoot(ElementName = "bezorgorder")]
    public class OpdrachtInfo
    {
        [XmlElement(ElementName = "datum")]
        public string datum { get; set; }
        [XmlElement(ElementName = "orderref")]
        public string orderref { get; set; }
        [XmlElement(ElementName = "ophaaltijdvanaf")]
        public string ophaaltijdvanaf { get; set; }
        [XmlElement(ElementName = "aflevertijdtot")]
        public string aflevertijdtot { get; set; }
    }

    [XmlRoot(ElementName = "opdrachtgever")]
    public class Opdrachtgever
    {
        [XmlElement(ElementName = "nr")]
        public string Nr { get; set; }
        [XmlElement(ElementName = "naam")]
        public string Naam { get; set; }
    }

    [XmlRoot(ElementName = "zender")]
    public class Zender
    {
        [XmlElement(ElementName = "nr")]
        public string Nr { get; set; }
        [XmlElement(ElementName = "naam")]
        public string Naam { get; set; }
    }

    [XmlRoot(ElementName = "ophaaladres")]
    public class Ophaaladres
    {
        [XmlElement(ElementName = "nr")]
        public string Nr { get; set; }
        [XmlElement(ElementName = "naam")]
        public string Naam { get; set; }
    }

    [XmlRoot(ElementName = "afleveradres")]
    public class Afleveradres
    {
        [XmlElement(ElementName = "nr")]
        public string Nr { get; set; }
        [XmlElement(ElementName = "naam")]
        public string Naam { get; set; }
        [XmlElement(ElementName = "straat")]
        public string Straat { get; set; }
        [XmlElement(ElementName = "huisnr")]
        public string Huisnr { get; set; }
        [XmlElement(ElementName = "plaats")]
        public string Plaats { get; set; }
        [XmlElement(ElementName = "postcode")]
        public string Postcode { get; set; }
        [XmlElement(ElementName = "telefoonnr")]
        public string Telefoonnr { get; set; }
    }

    [XmlRoot(ElementName = "artikel")]
    public class Artikel
    {
        [XmlElement(ElementName = "nr")]
        public string Nr { get; set; }
        [XmlElement(ElementName = "naam")]
        public string Naam { get; set; }
        [XmlElement(ElementName = "aantal")]
        public string Aantal { get; set; }
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

    [XmlRoot(ElementName = "bezorgorder")]
    public class Bezorgorder
    {
        [XmlElement(ElementName = "datum")]
        public string Datum { get; set; }
        [XmlElement(ElementName = "orderref")]
        public string Orderref { get; set; }
        [XmlElement(ElementName = "ophaaltijdvanaf")]
        public string Ophaaltijdvanaf { get; set; }
        [XmlElement(ElementName = "aflevertijdtot")]
        public string Aflevertijdtot { get; set; }
        [XmlElement(ElementName = "opdrachtgever")]
        public Opdrachtgever Opdrachtgever { get; set; }
        [XmlElement(ElementName = "zender")]
        public Zender Zender { get; set; }
        [XmlElement(ElementName = "ophaaladres")]
        public Ophaaladres Ophaaladres { get; set; }
        [XmlElement(ElementName = "afleveradres")]
        public Afleveradres Afleveradres { get; set; }
        [XmlElement(ElementName = "artikel")]
        public List<Artikel> Artikel { get; set; }
        [XmlElement(ElementName = "laadgegevens")]
        public Laadgegevens Laadgegevens { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string NoNamespaceSchemaLocation { get; set; }
    }

}
