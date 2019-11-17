﻿//// <auto-generated />
////
//// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
////
////    using QuickType;
////
////    var welcome = Welcome.FromJson(jsonString);

//namespace QuickType
//{
//    using System;
//    using System.Collections.Generic;

//    using System.Globalization;
//    using Newtonsoft.Json;
//    using Newtonsoft.Json.Converters;

//    public partial class Welcome
//    {
//        [JsonProperty("meta")]
//        public Meta Meta { get; set; }

//        [JsonProperty("response")]
//        public Response Response { get; set; }
//    }

//    public partial class Meta
//    {
//        [JsonProperty("code")]
//        public long Code { get; set; }
//    }

//    public partial class Response
//    {
//        [JsonProperty("holidays")]
//        public Holiday[] Holidays { get; set; }
//    }

//    public partial class Holiday
//    {
//        [JsonProperty("name")]
//        public string Name { get; set; }

//        [JsonProperty("description")]
//        public string Description { get; set; }

//        [JsonProperty("date")]
//        public Date Date { get; set; }

//        [JsonProperty("type")]
//        public TypeElement[] Type { get; set; }

//        [JsonProperty("locations")]
//        public string Locations { get; set; }

//        [JsonProperty("states")]
//        public StatesUnion States { get; set; }
//    }

//    public partial class Date
//    {
//        [JsonProperty("iso")]
//        public DateTimeOffset Iso { get; set; }

//        [JsonProperty("datetime")]
//        public Datetime Datetime { get; set; }

//        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
//        public Timezone Timezone { get; set; }
//    }

//    public partial class Datetime
//    {
//        [JsonProperty("year")]
//        public long Year { get; set; }

//        [JsonProperty("month")]
//        public long Month { get; set; }

//        [JsonProperty("day")]
//        public long Day { get; set; }

//        [JsonProperty("hour", NullValueHandling = NullValueHandling.Ignore)]
//        public long? Hour { get; set; }

//        [JsonProperty("minute", NullValueHandling = NullValueHandling.Ignore)]
//        public long? Minute { get; set; }

//        [JsonProperty("second", NullValueHandling = NullValueHandling.Ignore)]
//        public long? Second { get; set; }
//    }

//    public partial class Timezone
//    {
//        [JsonProperty("offset")]
//        public string Offset { get; set; }

//        [JsonProperty("zoneabb")]
//        public string Zoneabb { get; set; }

//        [JsonProperty("zoneoffset")]
//        public long Zoneoffset { get; set; }

//        [JsonProperty("zonedst")]
//        public long Zonedst { get; set; }

//        [JsonProperty("zonetotaloffset")]
//        public long Zonetotaloffset { get; set; }
//    }

//    public partial class State
//    {
//        [JsonProperty("id")]
//        public long Id { get; set; }

//        [JsonProperty("abbrev")]
//        public string Abbrev { get; set; }

//        [JsonProperty("name")]
//        public string Name { get; set; }

//        [JsonProperty("exception")]
//        public ExceptionEnum? Exception { get; set; }

//        [JsonProperty("iso")]
//        public string Iso { get; set; }
//    }

//    public enum StatesEnum { All };

//    public enum ExceptionEnum { Community, Optional, Partly };

//    public enum TypeElement { Christian, ClockChangeDaylightSavingTime, Hebrew, Hinduism, LocalHoliday, LocalObservance, Muslim, NationalHoliday, Observance, Orthodox, Season, SportingEvent, UnitedNationsObservance, WorldwideObservance };

//    public partial struct StatesUnion
//    {
//        public StatesEnum? Enum;
//        public State[] StateArray;

//        public static implicit operator StatesUnion(StatesEnum Enum) => new StatesUnion { Enum = Enum };
//        public static implicit operator StatesUnion(State[] StateArray) => new StatesUnion { StateArray = StateArray };
//    }

//    public partial class Welcome
//    {
//        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
//    }

//    public static class Serialize
//    {
//        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
//    }

//    internal static class Converter
//    {
//        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
//        {
//            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
//            DateParseHandling = DateParseHandling.None,
//            Converters =
//            {
//                StatesUnionConverter.Singleton,
//                ExceptionEnumConverter.Singleton,
//                StatesEnumConverter.Singleton,
//                TypeElementConverter.Singleton,
//                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
//            },
//        };
//    }

//    internal class StatesUnionConverter : JsonConverter
//    {
//        public override bool CanConvert(Type t) => t == typeof(StatesUnion) || t == typeof(StatesUnion?);

//        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
//        {
//            switch (reader.TokenType)
//            {
//                case JsonToken.String:
//                case JsonToken.Date:
//                    var stringValue = serializer.Deserialize<string>(reader);
//                    if (stringValue == "All")
//                    {
//                        return new StatesUnion { Enum = StatesEnum.All };
//                    }
//                    break;
//                case JsonToken.StartArray:
//                    var arrayValue = serializer.Deserialize<State[]>(reader);
//                    return new StatesUnion { StateArray = arrayValue };
//            }
//            throw new Exception("Cannot unmarshal type StatesUnion");
//        }

//        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
//        {
//            var value = (StatesUnion)untypedValue;
//            if (value.Enum != null)
//            {
//                if (value.Enum == StatesEnum.All)
//                {
//                    serializer.Serialize(writer, "All");
//                    return;
//                }
//            }
//            if (value.StateArray != null)
//            {
//                serializer.Serialize(writer, value.StateArray);
//                return;
//            }
//            throw new Exception("Cannot marshal type StatesUnion");
//        }

//        public static readonly StatesUnionConverter Singleton = new StatesUnionConverter();
//    }

//    internal class ExceptionEnumConverter : JsonConverter
//    {
//        public override bool CanConvert(Type t) => t == typeof(ExceptionEnum) || t == typeof(ExceptionEnum?);

//        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
//        {
//            if (reader.TokenType == JsonToken.Null) return null;
//            var value = serializer.Deserialize<string>(reader);
//            switch (value)
//            {
//                case "community":
//                    return ExceptionEnum.Community;
//                case "optional":
//                    return ExceptionEnum.Optional;
//                case "partly":
//                    return ExceptionEnum.Partly;
//            }
//            throw new Exception("Cannot unmarshal type ExceptionEnum");
//        }

//        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
//        {
//            if (untypedValue == null)
//            {
//                serializer.Serialize(writer, null);
//                return;
//            }
//            var value = (ExceptionEnum)untypedValue;
//            switch (value)
//            {
//                case ExceptionEnum.Community:
//                    serializer.Serialize(writer, "community");
//                    return;
//                case ExceptionEnum.Optional:
//                    serializer.Serialize(writer, "optional");
//                    return;
//                case ExceptionEnum.Partly:
//                    serializer.Serialize(writer, "partly");
//                    return;
//            }
//            throw new Exception("Cannot marshal type ExceptionEnum");
//        }

//        public static readonly ExceptionEnumConverter Singleton = new ExceptionEnumConverter();
//    }

//    internal class StatesEnumConverter : JsonConverter
//    {
//        public override bool CanConvert(Type t) => t == typeof(StatesEnum) || t == typeof(StatesEnum?);

//        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
//        {
//            if (reader.TokenType == JsonToken.Null) return null;
//            var value = serializer.Deserialize<string>(reader);
//            if (value == "All")
//            {
//                return StatesEnum.All;
//            }
//            throw new Exception("Cannot unmarshal type StatesEnum");
//        }

//        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
//        {
//            if (untypedValue == null)
//            {
//                serializer.Serialize(writer, null);
//                return;
//            }
//            var value = (StatesEnum)untypedValue;
//            if (value == StatesEnum.All)
//            {
//                serializer.Serialize(writer, "All");
//                return;
//            }
//            throw new Exception("Cannot marshal type StatesEnum");
//        }

//        public static readonly StatesEnumConverter Singleton = new StatesEnumConverter();
//    }

//    internal class TypeElementConverter : JsonConverter
//    {
//        public override bool CanConvert(Type t) => t == typeof(TypeElement) || t == typeof(TypeElement?);

//        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
//        {
//            if (reader.TokenType == JsonToken.Null) return null;
//            var value = serializer.Deserialize<string>(reader);
//            switch (value)
//            {
//                case "Christian":
//                    return TypeElement.Christian;
//                case "Clock change/Daylight Saving Time":
//                    return TypeElement.ClockChangeDaylightSavingTime;
//                case "Hebrew":
//                    return TypeElement.Hebrew;
//                case "Hinduism":
//                    return TypeElement.Hinduism;
//                case "Local holiday":
//                    return TypeElement.LocalHoliday;
//                case "Local observance":
//                    return TypeElement.LocalObservance;
//                case "Muslim":
//                    return TypeElement.Muslim;
//                case "National holiday":
//                    return TypeElement.NationalHoliday;
//                case "Observance":
//                    return TypeElement.Observance;
//                case "Orthodox":
//                    return TypeElement.Orthodox;
//                case "Season":
//                    return TypeElement.Season;
//                case "Sporting event":
//                    return TypeElement.SportingEvent;
//                case "United Nations observance":
//                    return TypeElement.UnitedNationsObservance;
//                case "Worldwide observance":
//                    return TypeElement.WorldwideObservance;
//            }
//            throw new Exception("Cannot unmarshal type TypeElement");
//        }

//        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
//        {
//            if (untypedValue == null)
//            {
//                serializer.Serialize(writer, null);
//                return;
//            }
//            var value = (TypeElement)untypedValue;
//            switch (value)
//            {
//                case TypeElement.Christian:
//                    serializer.Serialize(writer, "Christian");
//                    return;
//                case TypeElement.ClockChangeDaylightSavingTime:
//                    serializer.Serialize(writer, "Clock change/Daylight Saving Time");
//                    return;
//                case TypeElement.Hebrew:
//                    serializer.Serialize(writer, "Hebrew");
//                    return;
//                case TypeElement.Hinduism:
//                    serializer.Serialize(writer, "Hinduism");
//                    return;
//                case TypeElement.LocalHoliday:
//                    serializer.Serialize(writer, "Local holiday");
//                    return;
//                case TypeElement.LocalObservance:
//                    serializer.Serialize(writer, "Local observance");
//                    return;
//                case TypeElement.Muslim:
//                    serializer.Serialize(writer, "Muslim");
//                    return;
//                case TypeElement.NationalHoliday:
//                    serializer.Serialize(writer, "National holiday");
//                    return;
//                case TypeElement.Observance:
//                    serializer.Serialize(writer, "Observance");
//                    return;
//                case TypeElement.Orthodox:
//                    serializer.Serialize(writer, "Orthodox");
//                    return;
//                case TypeElement.Season:
//                    serializer.Serialize(writer, "Season");
//                    return;
//                case TypeElement.SportingEvent:
//                    serializer.Serialize(writer, "Sporting event");
//                    return;
//                case TypeElement.UnitedNationsObservance:
//                    serializer.Serialize(writer, "United Nations observance");
//                    return;
//                case TypeElement.WorldwideObservance:
//                    serializer.Serialize(writer, "Worldwide observance");
//                    return;
//            }
//            throw new Exception("Cannot marshal type TypeElement");
//        }

//        public static readonly TypeElementConverter Singleton = new TypeElementConverter();
//    }
//}



// CODE REVIEW - UMESH SINGH
// CHANGING THE HOLIDAY CLASS BASED ON THE REVISED JSON DATA FILE AND C# CODE GENERATED FROM QUICKTYPE
namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Holiday
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date")]
        public Date Date { get; set; }

        [JsonProperty("type")]
        public TypeElement[] Type { get; set; }

        [JsonProperty("locations")]
        public string Locations { get; set; }

        [JsonProperty("states")]
        public StatesUnion States { get; set; }
    }

    public partial class Date
    {
        [JsonProperty("iso")]
        public DateTimeOffset Iso { get; set; }

        [JsonProperty("datetime")]
        public Datetime Datetime { get; set; }

        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public Timezone Timezone { get; set; }
    }

    public partial class Datetime
    {
        [JsonProperty("year")]
        public long Year { get; set; }

        [JsonProperty("month")]
        public long Month { get; set; }

        [JsonProperty("day")]
        public long Day { get; set; }

        [JsonProperty("hour", NullValueHandling = NullValueHandling.Ignore)]
        public long? Hour { get; set; }

        [JsonProperty("minute", NullValueHandling = NullValueHandling.Ignore)]
        public long? Minute { get; set; }

        [JsonProperty("second", NullValueHandling = NullValueHandling.Ignore)]
        public long? Second { get; set; }
    }

    public partial class Timezone
    {
        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("zoneabb")]
        public string Zoneabb { get; set; }

        [JsonProperty("zoneoffset")]
        public long Zoneoffset { get; set; }

        [JsonProperty("zonedst")]
        public long Zonedst { get; set; }

        [JsonProperty("zonetotaloffset")]
        public long Zonetotaloffset { get; set; }
    }

    public partial class State
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("abbrev")]
        public string Abbrev { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("exception")]
        public ExceptionEnum? Exception { get; set; }

        [JsonProperty("iso")]
        public string Iso { get; set; }
    }

    public enum StatesEnum { All };

    public enum ExceptionEnum { Community, Optional, Partly };

    public enum TypeElement { Christian, ClockChangeDaylightSavingTime, Hebrew, Hinduism, LocalHoliday, LocalObservance, Muslim, NationalHoliday, Observance, Orthodox, Season, SportingEvent, UnitedNationsObservance, WorldwideObservance };

    public partial struct StatesUnion
    {
        public StatesEnum? Enum;
        public State[] StateArray;

        public static implicit operator StatesUnion(StatesEnum Enum) => new StatesUnion { Enum = Enum };
        public static implicit operator StatesUnion(State[] StateArray) => new StatesUnion { StateArray = StateArray };
    }

    public partial class Holiday
    {
        public static Holiday[] FromJson(string json) => JsonConvert.DeserializeObject<Holiday[]>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Holiday[] self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                StatesUnionConverter.Singleton,
                ExceptionEnumConverter.Singleton,
                StatesEnumConverter.Singleton,
                TypeElementConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class StatesUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StatesUnion) || t == typeof(StatesUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    if (stringValue == "All")
                    {
                        return new StatesUnion { Enum = StatesEnum.All };
                    }
                    break;
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<State[]>(reader);
                    return new StatesUnion { StateArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type StatesUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (StatesUnion)untypedValue;
            if (value.Enum != null)
            {
                if (value.Enum == StatesEnum.All)
                {
                    serializer.Serialize(writer, "All");
                    return;
                }
            }
            if (value.StateArray != null)
            {
                serializer.Serialize(writer, value.StateArray);
                return;
            }
            throw new Exception("Cannot marshal type StatesUnion");
        }

        public static readonly StatesUnionConverter Singleton = new StatesUnionConverter();
    }

    internal class ExceptionEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ExceptionEnum) || t == typeof(ExceptionEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "community":
                    return ExceptionEnum.Community;
                case "optional":
                    return ExceptionEnum.Optional;
                case "partly":
                    return ExceptionEnum.Partly;
            }
            throw new Exception("Cannot unmarshal type ExceptionEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ExceptionEnum)untypedValue;
            switch (value)
            {
                case ExceptionEnum.Community:
                    serializer.Serialize(writer, "community");
                    return;
                case ExceptionEnum.Optional:
                    serializer.Serialize(writer, "optional");
                    return;
                case ExceptionEnum.Partly:
                    serializer.Serialize(writer, "partly");
                    return;
            }
            throw new Exception("Cannot marshal type ExceptionEnum");
        }

        public static readonly ExceptionEnumConverter Singleton = new ExceptionEnumConverter();
    }

    internal class StatesEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StatesEnum) || t == typeof(StatesEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "All")
            {
                return StatesEnum.All;
            }
            throw new Exception("Cannot unmarshal type StatesEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (StatesEnum)untypedValue;
            if (value == StatesEnum.All)
            {
                serializer.Serialize(writer, "All");
                return;
            }
            throw new Exception("Cannot marshal type StatesEnum");
        }

        public static readonly StatesEnumConverter Singleton = new StatesEnumConverter();
    }

    internal class TypeElementConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeElement) || t == typeof(TypeElement?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Christian":
                    return TypeElement.Christian;
                case "Clock change/Daylight Saving Time":
                    return TypeElement.ClockChangeDaylightSavingTime;
                case "Hebrew":
                    return TypeElement.Hebrew;
                case "Hinduism":
                    return TypeElement.Hinduism;
                case "Local holiday":
                    return TypeElement.LocalHoliday;
                case "Local observance":
                    return TypeElement.LocalObservance;
                case "Muslim":
                    return TypeElement.Muslim;
                case "National holiday":
                    return TypeElement.NationalHoliday;
                case "Observance":
                    return TypeElement.Observance;
                case "Orthodox":
                    return TypeElement.Orthodox;
                case "Season":
                    return TypeElement.Season;
                case "Sporting event":
                    return TypeElement.SportingEvent;
                case "United Nations observance":
                    return TypeElement.UnitedNationsObservance;
                case "Worldwide observance":
                    return TypeElement.WorldwideObservance;
            }
            throw new Exception("Cannot unmarshal type TypeElement");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeElement)untypedValue;
            switch (value)
            {
                case TypeElement.Christian:
                    serializer.Serialize(writer, "Christian");
                    return;
                case TypeElement.ClockChangeDaylightSavingTime:
                    serializer.Serialize(writer, "Clock change/Daylight Saving Time");
                    return;
                case TypeElement.Hebrew:
                    serializer.Serialize(writer, "Hebrew");
                    return;
                case TypeElement.Hinduism:
                    serializer.Serialize(writer, "Hinduism");
                    return;
                case TypeElement.LocalHoliday:
                    serializer.Serialize(writer, "Local holiday");
                    return;
                case TypeElement.LocalObservance:
                    serializer.Serialize(writer, "Local observance");
                    return;
                case TypeElement.Muslim:
                    serializer.Serialize(writer, "Muslim");
                    return;
                case TypeElement.NationalHoliday:
                    serializer.Serialize(writer, "National holiday");
                    return;
                case TypeElement.Observance:
                    serializer.Serialize(writer, "Observance");
                    return;
                case TypeElement.Orthodox:
                    serializer.Serialize(writer, "Orthodox");
                    return;
                case TypeElement.Season:
                    serializer.Serialize(writer, "Season");
                    return;
                case TypeElement.SportingEvent:
                    serializer.Serialize(writer, "Sporting event");
                    return;
                case TypeElement.UnitedNationsObservance:
                    serializer.Serialize(writer, "United Nations observance");
                    return;
                case TypeElement.WorldwideObservance:
                    serializer.Serialize(writer, "Worldwide observance");
                    return;
            }
            throw new Exception("Cannot marshal type TypeElement");
        }

        public static readonly TypeElementConverter Singleton = new TypeElementConverter();
    }
}
