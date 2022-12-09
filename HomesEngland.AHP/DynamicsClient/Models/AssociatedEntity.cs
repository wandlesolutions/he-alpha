using Newtonsoft.Json;

namespace HomesEngland.AHP.DynamicsClient.Models;

[JsonConverter(typeof(AssociatedEntityConverter))]
public class AssociatedEntity
{
	public AssociatedEntity(Guid id, string tableName)
	{
		Id = id;
		TableName = tableName;
	}

	public Guid Id { get; set; }

	public string TableName { get; set; }
}
