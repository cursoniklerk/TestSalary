using Newtonsoft.Json.Linq;
using Persistence.DbContextScope;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using static Common.Enums;

namespace Persistence.Repository
{
    public partial class Employee
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("contractTypeName")]
        public ContractType ContractTypeName { get; set; }

        [JsonProperty("roleId")]
        public long RoleId { get; set; }

        [JsonProperty("roleName")]
        public string RoleName { get; set; }

        [JsonProperty("roleDescription")]
        public object RoleDescription { get; set; }

        [JsonProperty("hourlySalary")]
        public long HourlySalary { get; set; }

        [JsonProperty("monthlySalary")]
        public long MonthlySalary { get; set; }
    }

    public partial class Employee
    {
        public static Employee[] FromJson(string json) => JsonConvert.DeserializeObject<Employee[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Employee[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}