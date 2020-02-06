//Copyright Sameer Alibhai, VerseByVerseQuran Project

using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuranLibrary
{
    [XmlType("sura")]
    public class Sura
    {
        [XmlAttribute("index")]
        public int index;

        [XmlAttribute("name")]
        public string name;

        [XmlElement("aya")]
        public Aya[] ayat;
    }
}
