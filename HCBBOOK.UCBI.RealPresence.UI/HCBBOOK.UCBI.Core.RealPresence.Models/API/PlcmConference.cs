using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCBBOOK.UCBI.Core.RealPresence.Models.API
{
    public class RootPlcmConference
    {
        [JsonProperty("plcm-conference")]
        public List<PlcmConference> PlcmConference { get; set; }
    }
    public class PlcmConference
    {
        [JsonProperty("link")]
        public List<Link> Link { get; set; }
        [JsonProperty("plcm-cascade-link")]
        public object PlcmCascadeLink { get; set; }
        [JsonProperty("conference-identifier")]
        public string ConferenceIdentifier { get; set; }
        [JsonProperty("dial-in-number")]
        public string DialInNumber { get; set; }
        [JsonProperty("conference-room-identifier")]
        public string ConferenceRoomIdentifier { get; set; }
        [JsonProperty("mcu-name")]
        public object McuName { get; set; }
        [JsonProperty("cascade-mcu-name")]
        public object CascadeMcuName { get; set; }
        [JsonProperty("owner-first-name")]
        public string OwnerFirstName { get; set; }
        [JsonProperty("owner-last-name")]
        public string OwnerLastName { get; set; }
        [JsonProperty("host-name")]
        public string HostName { get; set; }
        [JsonProperty("recording-active")]
        public bool RecordingActive { get; set; }
        [JsonProperty("display-text")]
        public string DisplayText { get; set; }
        [JsonProperty("passback")]
        public object Passback { get; set; }
        [JsonProperty("passthru")]
        public object Passthru { get; set; }
        [JsonProperty("entity-tag")]
        public string EntityTag { get; set; }
        [JsonProperty("supported-layout")]
        public object SupportedLayout { get; set; }
        [JsonProperty("current-layout")]
        public object CurrentLayout { get; set; }
        [JsonProperty("conference-locked")]
        public object ConferenceLocked { get; set; }
        [JsonProperty("join-new-calls-muted")]
        public object JoinNewCallsMuted { get; set; }
        [JsonProperty("start-time")]
        public long StartTime { get; set; }
        [JsonProperty("anies")]
        public object Anies { get; set; }
    }
    public class Link
    {
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("rel")]
        public string Rel { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("hreflang")]
        public object Hreflang { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("length")]
        public object Length { get; set; }
        [JsonProperty("base")]
        public object Base { get; set; }
        [JsonProperty("lang")]
        public object Lang { get; set; }
    }

}
