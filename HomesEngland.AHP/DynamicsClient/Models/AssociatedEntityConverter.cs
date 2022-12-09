using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

public class AssociatedEntityConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(AssociatedEntity);
	}

	public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		throw new NotImplementedException();
	}

	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
		if (value is AssociatedEntity associatedEntity)
		{
			//writer.WriteRaw($"\"{associatedEntity.FieldName}@odata.bind\":");
			//writer.WriteRaw($"\"/{associatedEntity.TableName}({associatedEntity.Id})\"");

			//writer.WritePropertyName($"{associatedEntity.FieldName}@odata.bind");
			writer.WriteValue($"/{associatedEntity.TableName}({associatedEntity.Id})");
		}
	}
}
