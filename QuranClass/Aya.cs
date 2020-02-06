//Copyright Sameer Alibhai, VerseByVerseQuran Project

using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuranLibrary
{
    [XmlType("aya")]
    public class Aya
    {
        [XmlAttribute]
        public int index;

        [XmlAttribute]
        public string text;

        [XmlAttribute]
        public string X;

        [XmlAttribute]
        public string Y;


        [XmlAttribute]
        public string width;


        [XmlAttribute]
        public string height;

        [XmlAttribute]
        public string Page;


    }
}
