using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using OpenTapeDotNet.Business.Domain;

namespace OpenTapeDotNet.Utilities
{
    public class XspfWriter
    {
        public XDocument GetXspf(IEnumerable<Track> tracks)
        {
            var xmlDeclaration = new XDeclaration("1.0", "utf-8", "no");
            XNamespace xspfNamespace = "http://xspf.org/ns/0/";
            var xmlDoc = new XDocument(xmlDeclaration);

            var root = new XElement
                (xspfNamespace + "playlist",
                    new XElement("title", "Opentape"),
                    new XElement("annotation", "Songs, "),
                    new XElement("creator", "Songs, "),
                    new XElement("location", "Songs, "),
                    new XElement("info", "Songs, "),
                    new XElement("tracklist", "Songs, "),
                    GetTracks(tracks)
                );

            return xmlDoc;
        }

        public IEnumerable<XElement> GetTracks(IEnumerable<Track> tracks)
        {
            foreach (Track track in tracks)
            {
                var trackItem = new XElement("track",
                    new XElement("location", track.Location),
                    new XElement("meta", track.Meta),
                    new XElement("creator", track.Artist),
                    new XElement("title", track.Title),
                    new XElement("duration", track.Duration),
                    new XElement("info", track.Info)
                );

                yield return trackItem;
            }
        }
    }
}