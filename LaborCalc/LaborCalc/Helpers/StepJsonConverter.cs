using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace LaborCalc.Helpers;

public class MethodicJsonConverter : JsonConverter
{
    static readonly JsonSerializerSettings SpecifiedSubclassConversion = new () 
    { 
        ContractResolver = new BaseSpecifiedConcreteClassConverter() 
    };

    public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(Methodic));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JObject jo = JObject.Load(reader);

        return jo["MethodicId"].Value<double>() switch
        {
            1 => JsonConvert.DeserializeObject<Methodic01>(jo.ToString(), SpecifiedSubclassConversion),
            2 => JsonConvert.DeserializeObject<Methodic02>(jo.ToString(), SpecifiedSubclassConversion),
            3.2 => JsonConvert.DeserializeObject<Methodic03_2>(jo.ToString(), SpecifiedSubclassConversion),
            3.6 => JsonConvert.DeserializeObject<Methodic03_6>(jo.ToString(), SpecifiedSubclassConversion),
            3.7 => JsonConvert.DeserializeObject<Methodic03_7>(jo.ToString(), SpecifiedSubclassConversion),
            3.8 => JsonConvert.DeserializeObject<Methodic03_8>(jo.ToString(), SpecifiedSubclassConversion),
            3.9 => JsonConvert.DeserializeObject<Methodic03_9>(jo.ToString(), SpecifiedSubclassConversion),
            4.6 => JsonConvert.DeserializeObject<Methodic04_6>(jo.ToString(), SpecifiedSubclassConversion),
            5 => JsonConvert.DeserializeObject<Methodic05>(jo.ToString(), SpecifiedSubclassConversion),
            6 => JsonConvert.DeserializeObject<Methodic06>(jo.ToString(), SpecifiedSubclassConversion),
            7 => JsonConvert.DeserializeObject<Methodic07>(jo.ToString(), SpecifiedSubclassConversion),
            8 => JsonConvert.DeserializeObject<Methodic08>(jo.ToString(), SpecifiedSubclassConversion),
            9 => JsonConvert.DeserializeObject<Methodic09>(jo.ToString(), SpecifiedSubclassConversion),
            10 => JsonConvert.DeserializeObject<Methodic10>(jo.ToString(), SpecifiedSubclassConversion),
            11 => JsonConvert.DeserializeObject<Methodic11>(jo.ToString(), SpecifiedSubclassConversion),
            12 => JsonConvert.DeserializeObject<Methodic12>(jo.ToString(), SpecifiedSubclassConversion),
            13 => JsonConvert.DeserializeObject<Methodic13>(jo.ToString(), SpecifiedSubclassConversion),
            14 => JsonConvert.DeserializeObject<Methodic14>(jo.ToString(), SpecifiedSubclassConversion),
            15 => JsonConvert.DeserializeObject<Methodic15>(jo.ToString(), SpecifiedSubclassConversion),
            16 => JsonConvert.DeserializeObject<Methodic16>(jo.ToString(), SpecifiedSubclassConversion),
            17 => JsonConvert.DeserializeObject<Methodic17>(jo.ToString(), SpecifiedSubclassConversion),
            18 => JsonConvert.DeserializeObject<Methodic18>(jo.ToString(), SpecifiedSubclassConversion),
            _ => throw new Exception("No such ID"),
        };
    }

    public override bool CanWrite
    {
        get { return false; }
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException(); // won't be called because CanWrite returns false
    }
}

public class BaseSpecifiedConcreteClassConverter : DefaultContractResolver
{
    protected override JsonConverter ResolveContractConverter(Type objectType)
    {
        if (typeof(Methodic).IsAssignableFrom(objectType) && !objectType.IsAbstract)
            return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
        return base.ResolveContractConverter(objectType);
    }
}
