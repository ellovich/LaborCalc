using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace LaborCalc.Helpers;

public class StepJsonConverter : JsonConverter
{
    static JsonSerializerSettings SpecifiedSubclassConversion = new () 
    { 
        ContractResolver = new BaseSpecifiedConcreteClassConverter() 
    };

    public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(Step));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JObject jo = JObject.Load(reader);


        return jo["MethodicId"].Value<double>() switch
        {
            1 => JsonConvert.DeserializeObject<Step01>(jo.ToString(), SpecifiedSubclassConversion),
            2 => JsonConvert.DeserializeObject<Step02>(jo.ToString(), SpecifiedSubclassConversion),
            3.2 => JsonConvert.DeserializeObject<Step03_2>(jo.ToString(), SpecifiedSubclassConversion),
            3.6 => JsonConvert.DeserializeObject<Step03_6>(jo.ToString(), SpecifiedSubclassConversion),
            3.7 => JsonConvert.DeserializeObject<Step03_7>(jo.ToString(), SpecifiedSubclassConversion),
            3.8 => JsonConvert.DeserializeObject<Step03_8>(jo.ToString(), SpecifiedSubclassConversion),
            3.9 => JsonConvert.DeserializeObject<Step03_9>(jo.ToString(), SpecifiedSubclassConversion),
            4 => JsonConvert.DeserializeObject<Step04>(jo.ToString(), SpecifiedSubclassConversion),
            5 => JsonConvert.DeserializeObject<Step05>(jo.ToString(), SpecifiedSubclassConversion),
            6 => JsonConvert.DeserializeObject<Step06>(jo.ToString(), SpecifiedSubclassConversion),
            7 => JsonConvert.DeserializeObject<Step07>(jo.ToString(), SpecifiedSubclassConversion),
            8 => JsonConvert.DeserializeObject<Step08>(jo.ToString(), SpecifiedSubclassConversion),
            9 => JsonConvert.DeserializeObject<Step09>(jo.ToString(), SpecifiedSubclassConversion),
            10 => JsonConvert.DeserializeObject<Step10>(jo.ToString(), SpecifiedSubclassConversion),
            11 => JsonConvert.DeserializeObject<Step11>(jo.ToString(), SpecifiedSubclassConversion),
            12 => JsonConvert.DeserializeObject<Step12>(jo.ToString(), SpecifiedSubclassConversion),
            13 => JsonConvert.DeserializeObject<Step13>(jo.ToString(), SpecifiedSubclassConversion),
            14 => JsonConvert.DeserializeObject<Step14>(jo.ToString(), SpecifiedSubclassConversion),
            15 => JsonConvert.DeserializeObject<Step15>(jo.ToString(), SpecifiedSubclassConversion),
            16 => JsonConvert.DeserializeObject<Step16>(jo.ToString(), SpecifiedSubclassConversion),
            17 => JsonConvert.DeserializeObject<Step17>(jo.ToString(), SpecifiedSubclassConversion),
            18 => JsonConvert.DeserializeObject<Step18>(jo.ToString(), SpecifiedSubclassConversion),
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
        if (typeof(Step).IsAssignableFrom(objectType) && !objectType.IsAbstract)
            return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
        return base.ResolveContractConverter(objectType);
    }
}
