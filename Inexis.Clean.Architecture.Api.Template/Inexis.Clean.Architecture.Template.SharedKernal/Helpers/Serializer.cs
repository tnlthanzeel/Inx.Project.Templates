using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Inexis.Clean.Architecture.Template.SharedKernal.Helpers;

public static class Serializer
{
    public static string Serialize(object instance)
    {
        var serializedData = JsonConvert.SerializeObject(instance, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Converters = new JsonConverter[] { new StringEnumConverter() }
        });

        return serializedData;
    }
}
